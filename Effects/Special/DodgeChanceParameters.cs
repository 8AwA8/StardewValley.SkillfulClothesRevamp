using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200007F RID: 127
	public class DodgeChanceParameters : IEffectParameters
	{
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00003F0C File Offset: 0x0000210C
		// (set) Token: 0x060002D5 RID: 725 RVA: 0x00003F14 File Offset: 0x00002114
		public int Chance { get; set; }

		// Token: 0x060002D6 RID: 726 RVA: 0x00003F1D File Offset: 0x0000211D
		public static DodgeChanceParameters With(int chance)
		{
			return new DodgeChanceParameters
			{
				Chance = chance
			};
		}
	}
}
