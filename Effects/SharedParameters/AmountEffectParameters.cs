using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.SharedParameters
{
	// Token: 0x0200005D RID: 93
	public class AmountEffectParameters : IEffectParameters
	{
		// Token: 0x060001EF RID: 495 RVA: 0x00003679 File Offset: 0x00001879
		public static AmountEffectParameters With(int amount)
		{
			return new AmountEffectParameters
			{
				Amount = amount
			};
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00003687 File Offset: 0x00001887
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x0000368F File Offset: 0x0000188F
		public int Amount { get; set; } = 1;
	}
}
