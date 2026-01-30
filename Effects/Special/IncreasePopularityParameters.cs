using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B4 RID: 180
	public class IncreasePopularityParameters : IEffectParameters
	{
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000426 RID: 1062 RVA: 0x0000503D File Offset: 0x0000323D
		// (set) Token: 0x06000427 RID: 1063 RVA: 0x00005045 File Offset: 0x00003245
		public int Amount { get; set; }

		// Token: 0x06000428 RID: 1064 RVA: 0x0000504E File Offset: 0x0000324E
		public static IncreasePopularityParameters With(int Amount)
		{
			return new IncreasePopularityParameters
			{
				Amount = Amount
			};
		}
	}
}
