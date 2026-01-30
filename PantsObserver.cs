using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Objects;

namespace SkillfulClothes
{
	// Token: 0x02000010 RID: 16
	internal class PantsObserver : EquippedClothingItemObserver<Pants>
	{
		// Token: 0x06000052 RID: 82 RVA: 0x000022BA File Offset: 0x000004BA
		protected override string GetCurrentItemId(Farmer farmer)
		{
			Clothing value = farmer.pantsItem.Value;
			return ((value != null) ? value.ItemId : null) ?? null;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000022D8 File Offset: 0x000004D8
		protected override Item GetCurrentItem(Farmer farmer)
		{
			return farmer.pantsItem.Value;
		}
	}
}
