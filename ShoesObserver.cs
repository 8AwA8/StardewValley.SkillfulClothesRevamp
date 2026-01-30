using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Objects;

namespace SkillfulClothes
{
	// Token: 0x020000BD RID: 189
	internal class ShoesObserver : EquippedClothingItemObserver<Shoes>
	{
		// Token: 0x06000463 RID: 1123 RVA: 0x00016644 File Offset: 0x00014844
		protected override string GetCurrentItemId(Farmer farmer)
		{
			Boots value = farmer.boots.Value;
			return ((value != null) ? value.ItemId : null) ?? null;
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0000537C File Offset: 0x0000357C
		protected override Item GetCurrentItem(Farmer farmer)
		{
			return farmer.boots.Value;
		}
	}
}
