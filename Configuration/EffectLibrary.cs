using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;

namespace SkillfulClothes.Configuration
{
	// Token: 0x0200006A RID: 106
	public class EffectLibrary
	{
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000241 RID: 577 RVA: 0x000038E5 File Offset: 0x00001AE5
		public static EffectLibrary Empty { get; } = new EffectLibrary(false);

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000038EC File Offset: 0x00001AEC
		public static EffectLibrary Default
		{
			get
			{
				if (EffectLibrary.defaultInstance == null)
				{
					EffectLibrary.defaultInstance = new EffectLibrary(true);
				}
				return EffectLibrary.defaultInstance;
			}
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000CDCC File Offset: 0x0000AFCC
		protected void DiscoverEffects()
		{
			IEnumerable<Type> lst = from x in Assembly.GetExecutingAssembly().GetTypes()
			where x.IsAssignableTo(typeof(IEffect)) && !x.IsAbstract && !x.IsInterface
			select x;
			foreach (Type type in lst)
			{
				if (type != typeof(EffectSet))
				{
					this.availableEffects.Add(type.Name.ToLower(), type);
				}
			}
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00003905 File Offset: 0x00001B05
		private EffectLibrary(bool discover)
		{
			if (discover)
			{
				this.DiscoverEffects();
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00003921 File Offset: 0x00001B21
		public bool TryGetEffectType(string effectName, out Type effectType)
		{
			effectName = effectName.ToLower();
			return this.availableEffects.TryGetValue(effectName, out effectType) || this.availableEffects.TryGetValue(effectName + "effect", out effectType);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000CE68 File Offset: 0x0000B068
		public IEffect CreateEffectInstance(string effectName)
		{
			Type effectType;
			if (!this.TryGetEffectType(effectName, out effectType))
			{
				Logger.Error("Unknown effect: " + effectName);
				return new NullEffect();
			}
			ConstructorInfo constr = (from x in effectType.GetConstructors()
			where x.GetParameters().Count<ParameterInfo>() == 1 && x.GetParameters().First<ParameterInfo>().ParameterType.IsAssignableTo(typeof(IEffectParameters))
			select x).FirstOrDefault<ConstructorInfo>();
			if (constr == null)
			{
				return (IEffect)Activator.CreateInstance(effectType);
			}
			return (IEffect)constr.Invoke(new object[1]);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00003953 File Offset: 0x00001B53
		public List<string> GetAllEffectNames()
		{
			return this.availableEffects.Keys.ToList<string>();
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00003965 File Offset: 0x00001B65
		public List<Type> GetAllEffectTypes()
		{
			return this.availableEffects.Values.ToList<Type>();
		}

		// Token: 0x04000250 RID: 592
		private static EffectLibrary defaultInstance;

		// Token: 0x04000251 RID: 593
		private Dictionary<string, Type> availableEffects = new Dictionary<string, Type>();
	}
}
