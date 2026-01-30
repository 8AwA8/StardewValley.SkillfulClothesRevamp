using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000073 RID: 115
	public class healthEffectParameters : IEffectParameters
	{
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00003BED File Offset: 0x00001DED
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00003BF5 File Offset: 0x00001DF5
		public healthGroup health { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600028D RID: 653 RVA: 0x00003BFE File Offset: 0x00001DFE
		// (set) Token: 0x0600028E RID: 654 RVA: 0x00003C06 File Offset: 0x00001E06
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x0600028F RID: 655 RVA: 0x00003C0F File Offset: 0x00001E0F
		public static healthEffectParameters With(healthGroup health, IEffect actualEffect)
		{
			return new healthEffectParameters
			{
				health = health,
				Effect = actualEffect
			};
		}
	}
}
