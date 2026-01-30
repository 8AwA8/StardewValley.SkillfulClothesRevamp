using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000053 RID: 83
	public class ShopDiscountParameters : IEffectParameters
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0000350F File Offset: 0x0000170F
		// (set) Token: 0x060001BE RID: 446 RVA: 0x00003517 File Offset: 0x00001717
		public Shop Shop { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060001BF RID: 447 RVA: 0x00003520 File Offset: 0x00001720
		// (set) Token: 0x060001C0 RID: 448 RVA: 0x00003528 File Offset: 0x00001728
		public double Discount { get; set; }

		// Token: 0x060001C1 RID: 449 RVA: 0x00003531 File Offset: 0x00001731
		public static ShopDiscountParameters With(Shop shop, double discount)
		{
			return new ShopDiscountParameters
			{
				Shop = shop,
				Discount = discount
			};
		}
	}
}
