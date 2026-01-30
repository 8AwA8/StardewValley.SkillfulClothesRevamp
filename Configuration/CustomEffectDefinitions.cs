using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;

namespace SkillfulClothes.Configuration
{
	// Token: 0x02000068 RID: 104
	internal class CustomEffectDefinitions
	{
		// Token: 0x06000234 RID: 564 RVA: 0x0000C880 File Offset: 0x0000AA80
		public static void LoadCustomEffectDefinitions()
		{
			if (EffectHelper.Config.EnableShirtEffects)
			{
				CustomEffectDefinitions.HandleCustomEffectDefinitions<Shirt>("custom_shirts.json", ItemDefinitions.ShirtEffects);
			}
			if (EffectHelper.Config.EnablePantsEffects)
			{
				CustomEffectDefinitions.HandleCustomEffectDefinitions<Pants>("custom_pants.json", ItemDefinitions.PantsEffects);
			}
			if (EffectHelper.Config.EnableHatEffects)
			{
				CustomEffectDefinitions.HandleCustomEffectDefinitions<Hat>("custom_hats.json", ItemDefinitions.HatEffects);
			}
			CustomEffectDefinitions.HandleCustomEffectDefinitions<Shoes>("custom_shoes.json", ItemDefinitions.ShoesEffects);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000C8F0 File Offset: 0x0000AAF0
		private static void HandleCustomEffectDefinitions<TItem>(string filename, Dictionary<TItem, ExtItemInfo> target) where TItem : AlphanumericItemId
		{
			string text = Path.Combine(EffectHelper.ModHelper.DirectoryPath, filename);
			if (File.Exists(text))
			{
				Logger.Info("Loading custom effect definitions from " + filename);
				target.Clear();
				CustomEffectDefinitions.ReadItemDefinitions<TItem>(text, target);
				return;
			}
			CustomEffectDefinitions.WriteItemDefinitions<TItem>(text, target);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000C93C File Offset: 0x0000AB3C
		private static void ReadItemDefinitions<TItem>(string filepath, Dictionary<TItem, ExtItemInfo> target) where TItem : AlphanumericItemId
		{
			CustomEffectConfigurationParser customEffectConfigurationParser = new CustomEffectConfigurationParser();
			List<CustomEffectItemDefinition> list;
			using (FileStream fileStream = new FileStream(filepath, FileMode.Open))
			{
				try
				{
					list = customEffectConfigurationParser.Parse(fileStream);
				}
				catch (Exception ex)
				{
					Logger.Error("Unable to read " + filepath + ": " + ex.Message);
					return;
				}
			}
			foreach (CustomEffectItemDefinition customEffectItemDefinition in list)
			{
				TItem knownItemById = ItemDefinitions.GetKnownItemById<TItem>(customEffectItemDefinition.ItemIdentifier);
				target.Add(knownItemById, ExtendItem.With.Effect(new IEffect[]
				{
					customEffectItemDefinition.Effect
				}));
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000CA14 File Offset: 0x0000AC14
		private static void WriteItemDefinitions<TItem>(string filepath, Dictionary<TItem, ExtItemInfo> source) where TItem : AlphanumericItemId
		{
			Dictionary<string, IEffect> dictionary = new Dictionary<string, IEffect>();
			foreach (KeyValuePair<TItem, ExtItemInfo> keyValuePair in source)
			{
				string key = keyValuePair.Key.ItemId;
				if (!string.IsNullOrEmpty(keyValuePair.Key.ItemName))
				{
					key = keyValuePair.Key.ItemName;
				}
				dictionary.Add(key, keyValuePair.Value.Effect);
			}
			JsonSerializer jsonSerializer = new JsonSerializer();
			jsonSerializer.Formatting = (Formatting)1;
			jsonSerializer.Converters.Add(new EnumJsonConverter());
			jsonSerializer.Converters.Add(new EffectJsonConverter(null));
			using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
			{
				using (StreamWriter streamWriter = new StreamWriter(fileStream))
				{
					jsonSerializer.Serialize(streamWriter, dictionary);
				}
			}
		}
	}
}
