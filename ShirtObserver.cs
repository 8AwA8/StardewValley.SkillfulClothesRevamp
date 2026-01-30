using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Objects;

namespace SkillfulClothes
{
	// Token: 0x0200000F RID: 15
	internal class ShirtObserver : EquippedClothingItemObserver<Shirt>
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00002287 File Offset: 0x00000487
		protected override string GetCurrentItemId(Farmer farmer)
		{
			Clothing value = farmer.shirtItem.Value;
			return ((value != null) ? value.ItemId : null) ?? null;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000022A5 File Offset: 0x000004A5
		protected override Item GetCurrentItem(Farmer farmer)
		{
			return farmer.shirtItem.Value;
		}
	}
}
