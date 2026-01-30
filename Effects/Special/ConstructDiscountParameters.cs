using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000047 RID: 71
	public class ConstructDiscountParameters : IEffectParameters
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000170 RID: 368 RVA: 0x000030D8 File Offset: 0x000012D8
		// (set) Token: 0x06000171 RID: 369 RVA: 0x000030E0 File Offset: 0x000012E0
		public double Discount { get; set; }

		// Token: 0x06000172 RID: 370 RVA: 0x000030E9 File Offset: 0x000012E9
		public static ConstructDiscountParameters With(double discount)
		{
			return new ConstructDiscountParameters
			{
				Discount = discount
			};
		}
	}
}
