using System;
using System.Collections.Generic;
using System.Linq;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000039 RID: 57
	public class EffectSet : IEffect
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00002EEB File Offset: 0x000010EB
		public IEffect[] Effects { get; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00002EF3 File Offset: 0x000010F3
		List<EffectDescriptionLine> IEffect.EffectDescription
		{
			get
			{
				return this.Effects.SelectMany((IEffect x) => x.EffectDescription).ToList<EffectDescriptionLine>();
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00002E6F File Offset: 0x0000106F
		public string EffectId
		{
			get
			{
				return EffectHelper.GetEffectId(this);
			}
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00002F24 File Offset: 0x00001124
		private EffectSet(params IEffect[] effects)
		{
			this.Effects = effects;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00002F33 File Offset: 0x00001133
		public static EffectSet Of(params IEffect[] effects)
		{
			return new EffectSet(effects);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00009D94 File Offset: 0x00007F94
		public void Apply(Item sourceItem, EffectChangeReason reason)
		{
			foreach (IEffect effect in this.Effects)
			{
				effect.Apply(sourceItem, reason);
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00009DC4 File Offset: 0x00007FC4
		public void Remove(Item sourceItem, EffectChangeReason reason)
		{
			foreach (IEffect effect in this.Effects)
			{
				effect.Remove(sourceItem, reason);
			}
		}
	}
}
