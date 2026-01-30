using System;
using StardewValley;

namespace SkillfulClothes.Types
{
	// Token: 0x02000072 RID: 114
	public static class healthGroupExtensions
	{
		// Token: 0x06000289 RID: 649 RVA: 0x0000D0C8 File Offset: 0x0000B2C8
		public static string GetEffectDescriptionSuffix(this healthGroup health)
		{
			if (health == healthGroup.Half)
			{
				return EffectHelper.ModHelper.Translation.Get("HG-Half");
			}
			if (health == healthGroup.Low)
			{
				return EffectHelper.ModHelper.Translation.Get("HG-Low");
			}
			if (health == healthGroup.Critical)
			{
				return EffectHelper.ModHelper.Translation.Get("HG-Crit");
			}
			if (health == healthGroup.healthy)
			{
				return EffectHelper.ModHelper.Translation.Get("HG-Health");
			}
			return "";
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000D154 File Offset: 0x0000B354
		public static bool IsActive(this healthGroup health)
		{
			if (health == healthGroup.Half)
			{
				return Game1.player.health < Game1.player.maxHealth / 2;
			}
			if (health == healthGroup.Low)
			{
				return Game1.player.health < Game1.player.maxHealth / 3;
			}
			if (health == healthGroup.Critical)
			{
				return Game1.player.health < Game1.player.maxHealth / 5;
			}
			return health == healthGroup.healthy && Game1.player.health > Game1.player.maxHealth * 9 / 10;
		}
	}
}
