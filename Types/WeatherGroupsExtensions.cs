using System;
using StardewValley;

namespace SkillfulClothes.Types
{
	// Token: 0x0200006F RID: 111
	public static class WeatherGroupsExtensions
	{
		// Token: 0x06000281 RID: 641 RVA: 0x0000CFB8 File Offset: 0x0000B1B8
		public static string GetEffectDescriptionSuffix(this WeatherGroup weather)
		{
			if (weather == WeatherGroup.Sunny)
			{
				return EffectHelper.ModHelper.Translation.Get("Weather-Clear");
			}
			if (weather == WeatherGroup.Wet)
			{
				return EffectHelper.ModHelper.Translation.Get("Weather-Wet");
			}
			if (weather == WeatherGroup.Stormy)
			{
				return EffectHelper.ModHelper.Translation.Get("Weather-Storm");
			}
			if (weather == WeatherGroup.GreenRain)
			{
				return EffectHelper.ModHelper.Translation.Get("Weather-Green");
			}
			if (weather == WeatherGroup.Wedding)
			{
				return EffectHelper.ModHelper.Translation.Get("Weather-Wedding");
			}
			return "";
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000D060 File Offset: 0x0000B260
		public static bool IsActive(this WeatherGroup weather, GameLocation location)
		{
			bool flag = Game1.IsGreenRainingHere(location);
			bool flag2 = Game1.IsRainingHere(location);
			bool flag3 = Game1.IsLightningHere(location);
			bool flag4 = Game1.IsSnowingHere(location);
			bool weddingToday = Game1.weddingToday;
			if (weather == WeatherGroup.Sunny)
			{
				return !flag && !flag2 && !flag3 && !flag4;
			}
			if (weather == WeatherGroup.Wet)
			{
				return flag || flag2 || flag3 || flag4;
			}
			if (weather == WeatherGroup.GreenRain)
			{
				return flag;
			}
			if (weather == WeatherGroup.Wedding)
			{
				return weddingToday;
			}
			return weather == WeatherGroup.Stormy && (flag || flag3);
		}
	}
}
