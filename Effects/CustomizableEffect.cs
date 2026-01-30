using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000035 RID: 53
	public abstract class CustomizableEffect<TParameters> : IEffect, ICustomizableEffect where TParameters : IEffectParameters, new()
	{
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00002E6F File Offset: 0x0000106F
		public string EffectId
		{
			get
			{
				return EffectHelper.GetEffectId(this);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00002E77 File Offset: 0x00001077
		public Type ParameterType
		{
			get
			{
				return typeof(TParameters);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00002E83 File Offset: 0x00001083
		// (set) Token: 0x0600012D RID: 301 RVA: 0x000095C8 File Offset: 0x000077C8
		public object ParameterObject
		{
			get
			{
				return this.Parameters;
			}
			set
			{
				if (value is TParameters)
				{
					TParameters parameters = (TParameters)((object)value);
					this.SetParameters(parameters);
					return;
				}
				string str = "Effect ";
				string name = base.GetType().Name;
				string str2 = " received wrong parameter type ";
				string text;
				if (value == null)
				{
					text = null;
				}
				else
				{
					Type type = value.GetType();
					text = ((type != null) ? type.Name : null);
				}
				throw new Exception(str + name + str2 + (text ?? "none"));
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00002E90 File Offset: 0x00001090
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00002E98 File Offset: 0x00001098
		public TParameters Parameters { get; private set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000130 RID: 304
		public abstract List<EffectDescriptionLine> EffectDescription { get; }

		// Token: 0x06000131 RID: 305 RVA: 0x00002EA1 File Offset: 0x000010A1
		public void SetParameters(TParameters parameters)
		{
			this.Parameters = parameters;
			this.ReloadParameters();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002EB0 File Offset: 0x000010B0
		public virtual void ReloadParameters()
		{
		}

		// Token: 0x06000133 RID: 307 RVA: 0x0000962C File Offset: 0x0000782C
		public CustomizableEffect(TParameters parameters)
		{
			this.SetParameters((parameters != null) ? parameters : Activator.CreateInstance<TParameters>());
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00002EB2 File Offset: 0x000010B2
		public CustomizableEffect()
		{
			this.SetParameters(Activator.CreateInstance<TParameters>());
		}

		// Token: 0x06000135 RID: 309
		public abstract void Apply(Item sourceItem, EffectChangeReason reason);

		// Token: 0x06000136 RID: 310
		public abstract void Remove(Item sourceItem, EffectChangeReason reason);
	}
}
