using System;
using SkillfulClothes.Effects.SharedParameters;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200005B RID: 91
	public class IncreaseSkillLevelParameters : AmountEffectParameters
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000361D File Offset: 0x0000181D
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x00003625 File Offset: 0x00001825
		public Skill Skill { get; set; }

		// Token: 0x060001E7 RID: 487 RVA: 0x0000362E File Offset: 0x0000182E
		public static IncreaseSkillLevelParameters With(Skill skill, int amount)
		{
			return new IncreaseSkillLevelParameters
			{
				Skill = skill,
				Amount = amount
			};
		}
	}
}
