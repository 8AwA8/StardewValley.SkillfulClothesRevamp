using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;

namespace SkillfulClothes.Configuration
{
	// Token: 0x02000069 RID: 105
	internal class EffectJsonConverter : JsonConverter<IEffect>
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000239 RID: 569 RVA: 0x000038CE File Offset: 0x00001ACE
		private EffectLibrary EffectLibrary { get; }

		// Token: 0x0600023A RID: 570 RVA: 0x000038D6 File Offset: 0x00001AD6
		public EffectJsonConverter(EffectLibrary effectLibrary)
		{
			this.EffectLibrary = effectLibrary;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000CB30 File Offset: 0x0000AD30
		public override IEffect ReadJson(JsonReader reader, Type objectType, [AllowNull] IEffect existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JToken token = JToken.ReadFrom(reader);
			return this.ParseJsonEffectDefinition(token, serializer);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x0000CB50 File Offset: 0x0000AD50
		public override void WriteJson(JsonWriter writer, [AllowNull] IEffect effect, JsonSerializer serializer)
		{
			EffectSet effectSet = effect as EffectSet;
			if (effectSet != null)
			{
				writer.WriteStartArray();
				foreach (IEffect childEffect in effectSet.Effects)
				{
					this.WriteJson(writer, childEffect, serializer);
				}
				writer.WriteEndArray();
				return;
			}
			ICustomizableEffect customizableEffect = effect as ICustomizableEffect;
			if (customizableEffect != null && !(customizableEffect.ParameterObject is NoEffectParameters))
			{
				writer.WriteStartObject();
				writer.WritePropertyName(this.GetEffectName(effect));
				JToken parameterToken = JToken.FromObject(customizableEffect.ParameterObject, serializer);
				parameterToken.WriteTo(writer, Array.Empty<JsonConverter>());
				writer.WriteEndObject();
				return;
			}
			writer.WriteValue(this.GetEffectName(effect));
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0000CBF4 File Offset: 0x0000ADF4
		private string GetEffectName(IEffect effect)
		{
			string name = effect.GetType().Name;
			if (name.ToLower().EndsWith("effect"))
			{
				return name.Substring(0, name.Length - "effect".Length);
			}
			return name;
		}

		// Token: 0x0600023E RID: 574 RVA: 0x0000CC3C File Offset: 0x0000AE3C
		public IEffect ParseJsonEffectDefinition(JToken token, JsonSerializer serializer)
		{
			JTokenType type = token.Type;
			switch (type)
			{
			case (JTokenType)1:
				return this.ParseJsonEffectObject(Extensions.Value<JProperty>(Extensions.Value<JObject>(token).First), serializer);
			case (JTokenType)2:
				return this.ParseJsonEffectSet(token, serializer);
			case (JTokenType)3:
				break;
			case (JTokenType)4:
				return this.ParseJsonEffectObject(Extensions.Value<JProperty>(token), serializer);
			default:
				if (type == (JTokenType)8)
				{
					return this.EffectLibrary.CreateEffectInstance(token.ToObject<string>());
				}
				break;
			}
			Logger.Error("Unexpected value: " + token.ToString());
			return new NullEffect();
		}

		// Token: 0x0600023F RID: 575 RVA: 0x0000CCC8 File Offset: 0x0000AEC8
		private EffectSet ParseJsonEffectSet(JToken arrayToken, JsonSerializer serializer)
		{
			if (arrayToken.Type != (JTokenType)2)
			{
				throw new ArgumentException("The specified token is not a JSON array", "arrayToken");
			}
			List<IEffect> effects = new List<IEffect>();
			foreach (JToken child in Extensions.Values(arrayToken))
			{
				effects.Add(this.ParseJsonEffectDefinition(child, serializer));
			}
			return EffectSet.Of(effects.ToArray());
		}

		// Token: 0x06000240 RID: 576 RVA: 0x0000CD48 File Offset: 0x0000AF48
		private IEffect ParseJsonEffectObject(JProperty jproperty, JsonSerializer serializer)
		{
			try
			{
				string effectName = jproperty.Name;
				IEffect effect = this.EffectLibrary.CreateEffectInstance(effectName);
				ICustomizableEffect customizableEffect = effect as ICustomizableEffect;
				if (customizableEffect != null)
				{
					JToken parameterDefinition = jproperty.Value;
					IEffectParameters parameters = parameterDefinition.ToObject(customizableEffect.ParameterType, serializer) as IEffectParameters;
					customizableEffect.ParameterObject = parameters;
				}
				return effect;
			}
			catch (Exception)
			{
				Logger.Error("Encountered an invalid effect definition at " + jproperty.Path);
			}
			return new NullEffect();
		}
	}
}
