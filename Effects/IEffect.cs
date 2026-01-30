using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003C RID: 60
	public interface IEffect
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000149 RID: 329
		string EffectId { get; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600014A RID: 330
		List<EffectDescriptionLine> EffectDescription { get; }

		// Token: 0x0600014B RID: 331
		void Apply(Item sourceItem, EffectChangeReason reason);

		// Token: 0x0600014C RID: 332
		void Remove(Item sourceItem, EffectChangeReason reason);
	}
}
