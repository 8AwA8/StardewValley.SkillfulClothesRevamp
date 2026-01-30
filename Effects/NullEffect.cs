using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003D RID: 61
	internal class NullEffect : IEffect
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00002F4F File Offset: 0x0000114F
		public List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return new List<EffectDescriptionLine>
				{
					new EffectDescriptionLine(EffectIcon.None, "Does nothing")
				};
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600014E RID: 334 RVA: 0x00002E6F File Offset: 0x0000106F
		public string EffectId
		{
			get
			{
				return EffectHelper.GetEffectId(this);
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00002EB0 File Offset: 0x000010B0
		public void Apply(Item sourceItem, EffectChangeReason reason)
		{
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00002EB0 File Offset: 0x000010B0
		public void Remove(Item sourceItem, EffectChangeReason reason)
		{
		}
	}
}
