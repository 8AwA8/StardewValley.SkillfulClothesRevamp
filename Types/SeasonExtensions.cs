using System;
using StardewValley;

namespace SkillfulClothes.Types
{
	// Token: 0x02000029 RID: 41
	public static class SeasonExtensions
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00002C6D File Offset: 0x00000E6D
		public static string GetEffectDescriptionSuffix(this Season season)
		{
			return EffectHelper.ModHelper.Translation.Get("Seas-" + season.ToString());
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00002C9A File Offset: 0x00000E9A
		public static bool IsActive(this Season season)
		{
			return Game1.season.ToString().ToLower() == season.ToString().ToLower();
		}
	}
}
