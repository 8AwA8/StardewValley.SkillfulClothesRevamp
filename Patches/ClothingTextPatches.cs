using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace SkillfulClothes.Patches
{
	// Token: 0x02000032 RID: 50
	internal static class ClothingTextPatches
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00002D69 File Offset: 0x00000F69
		public static void Apply(IModHelper helper)
		{
			helper.Events.Content.AssetRequested += ClothingTextPatches.Content_AssetRequested;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00002D87 File Offset: 0x00000F87
		private static void Content_AssetRequested(object sender, AssetRequestedEventArgs e)
		{
			if (ClothingTextPatches.CanEdit(e.NameWithoutLocale.BaseName))
			{
				e.Edit(delegate(IAssetData assetData)
				{
					ClothingTextPatches.EditAsset(assetData);
				}, 0, null);
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00002DC2 File Offset: 0x00000FC2
		private static bool CanEdit(string assetNameWithoutLocale)
		{
			return assetNameWithoutLocale == "Data/ClothingInformation" || assetNameWithoutLocale == "Data/Hats";
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00009164 File Offset: 0x00007364
		private static void EditAsset(IAssetData asset)
		{
			IDictionary<int, string> data = asset.AsDictionary<int, string>().Data;
			if (asset.NameWithoutLocale.IsEquivalentTo("Data/ClothingInformation", false))
			{
				ClothingTextPatches.UpdateTexts<Shirt>(ItemDefinitions.ShirtEffects, data, 2);
				ClothingTextPatches.UpdateTexts<Pants>(ItemDefinitions.PantsEffects, data, 2);
				return;
			}
			ClothingTextPatches.UpdateTexts<Hat>(ItemDefinitions.HatEffects, data, 1);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000091B8 File Offset: 0x000073B8
		private static void UpdateTexts<T>(Dictionary<T, ExtItemInfo> itemDefinitions, IDictionary<int, string> dict, int descriptionIndex)
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an Enum");
			}
			foreach (KeyValuePair<T, ExtItemInfo> keyValuePair in itemDefinitions)
			{
				int key = Convert.ToInt32(keyValuePair.Key);
				string text;
				if (keyValuePair.Value.ShouldDescriptionBePatched && dict.TryGetValue(key, out text))
				{
					string[] array = text.Split('/', StringSplitOptions.None);
					array[descriptionIndex] = keyValuePair.Value.NewItemDescription;
					dict[key] = string.Join("/", array);
				}
			}
		}

		// Token: 0x040001D0 RID: 464
		private const string clothingAssetName = "Data/ClothingInformation";

		// Token: 0x040001D1 RID: 465
		private const string hatAssetName = "Data/Hats";
	}
}
