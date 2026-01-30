using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Objects;

namespace SkillfulClothes
{
	// Token: 0x02000011 RID: 17
	internal class HatObserver : EquippedClothingItemObserver<Types.Hat>
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000022ED File Offset: 0x000004ED
		protected override string GetCurrentItemId(Farmer farmer)
		{
			StardewValley.Objects.Hat value = farmer.hat.Value;
			return ((value != null) ? value.ItemId : null) ?? null;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000230B File Offset: 0x0000050B
		protected override Item GetCurrentItem(Farmer farmer)
		{
			return farmer.hat.Value;
		}
	}
}
