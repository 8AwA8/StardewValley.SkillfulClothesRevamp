using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004F RID: 79
	public class MultiplyExperienceParameters : IEffectParameters
	{
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x00003349 File Offset: 0x00001549
		// (set) Token: 0x060001A1 RID: 417 RVA: 0x00003351 File Offset: 0x00001551
		public Skill Skill { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x0000335A File Offset: 0x0000155A
		// (set) Token: 0x060001A3 RID: 419 RVA: 0x00003362 File Offset: 0x00001562
		public float Multiplier { get; set; } = 1.2f;

		// Token: 0x060001A4 RID: 420 RVA: 0x0000336B File Offset: 0x0000156B
		public static MultiplyExperienceParameters With(Skill skill, float multiplier)
		{
			return new MultiplyExperienceParameters
			{
				Skill = skill,
				Multiplier = multiplier
			};
		}
	}
}
