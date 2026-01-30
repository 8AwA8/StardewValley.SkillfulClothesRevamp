using System;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Types
{
	// Token: 0x0200001F RID: 31
	public class ExtendItem
	{
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00002AD7 File Offset: 0x00000CD7
		public static ExtendItem With
		{
			get
			{
				return new ExtendItem();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00002ADE File Offset: 0x00000CDE
		public ExtendItem And
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00002AE1 File Offset: 0x00000CE1
		public ExtendItem Description(string newDescription)
		{
			this.newItemDescription = newDescription;
			return this;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00002AEB File Offset: 0x00000CEB
		public ExtendItem Effect(params IEffect[] effects)
		{
			if (effects.Length == 1)
			{
				this.effect = effects[0];
			}
			else if (effects.Length > 1)
			{
				this.effect = EffectSet.Of(effects);
			}
			else
			{
				this.effect = null;
			}
			return this;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00002B1A File Offset: 0x00000D1A
		public ExtendItem SoldBy(Shop shop, int price, SellingCondition sellingCondition = SellingCondition.None)
		{
			this.soldBy = shop;
			this.price = price;
			this.sellingCondition = sellingCondition;
			return this;
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x00002B32 File Offset: 0x00000D32
		public ExtendItem CannotBeCrafted
		{
			get
			{
				this.cannotCraft = true;
				return this;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00002B3C File Offset: 0x00000D3C
		public static implicit operator ExtItemInfo(ExtendItem item)
		{
			return new ExtItemInfo(item.newItemDescription, item.cannotCraft, item.effect, item.soldBy, item.price, item.sellingCondition);
		}

		// Token: 0x0400004E RID: 78
		private bool cannotCraft;

		// Token: 0x0400004F RID: 79
		private string newItemDescription;

		// Token: 0x04000050 RID: 80
		private IEffect effect;

		// Token: 0x04000051 RID: 81
		private Shop soldBy = Shop.None;

		// Token: 0x04000052 RID: 82
		private int price;

		// Token: 0x04000053 RID: 83
		private SellingCondition sellingCondition;
	}
}
