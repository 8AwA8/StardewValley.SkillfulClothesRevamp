using System;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Types
{
	// Token: 0x0200001E RID: 30
	public class ExtItemInfo
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00002A59 File Offset: 0x00000C59
		public bool ShouldDescriptionBePatched
		{
			get
			{
				return !string.IsNullOrEmpty(this.NewItemDescription);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00002A69 File Offset: 0x00000C69
		public string NewItemDescription { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00002A71 File Offset: 0x00000C71
		public bool IsCraftingDisabled { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00002A79 File Offset: 0x00000C79
		public Shop SoldBy { get; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00002A81 File Offset: 0x00000C81
		public int Price { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00002A89 File Offset: 0x00000C89
		public SellingCondition SellingCondition { get; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00002A91 File Offset: 0x00000C91
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00002A99 File Offset: 0x00000C99
		public IEffect Effect { get; private set; }

		// Token: 0x060000DE RID: 222 RVA: 0x00002AA2 File Offset: 0x00000CA2
		internal ExtItemInfo(string newDescription, bool disableCrafting, IEffect effect, Shop soldBy, int price, SellingCondition sellingCondition)
		{
			this.NewItemDescription = newDescription;
			this.IsCraftingDisabled = disableCrafting;
			this.Effect = effect;
			this.SoldBy = soldBy;
			this.Price = price;
			this.SellingCondition = sellingCondition;
		}
	}
}
