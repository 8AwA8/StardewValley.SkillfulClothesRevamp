using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000089 RID: 137
	public class OnKillParameters : IEffectParameters
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000311 RID: 785 RVA: 0x000042DF File Offset: 0x000024DF
		// (set) Token: 0x06000312 RID: 786 RVA: 0x000042E7 File Offset: 0x000024E7
		public int UniqueEff { get; set; }

		// Token: 0x06000313 RID: 787 RVA: 0x000042F0 File Offset: 0x000024F0
		public static OnKillParameters With(int effectCode, int amount)
		{
			return new OnKillParameters
			{
				UniqueEff = effectCode,
				Amount = amount
			};
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000314 RID: 788 RVA: 0x00004305 File Offset: 0x00002505
		// (set) Token: 0x06000315 RID: 789 RVA: 0x0000430D File Offset: 0x0000250D
		public int Amount { get; set; }
	}
}
