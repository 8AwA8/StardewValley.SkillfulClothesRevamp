using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;

namespace SkillfulClothes.Patches
{
	// Token: 0x020000A6 RID: 166
	internal class TranslationPatches
	{
		// Token: 0x060003CD RID: 973 RVA: 0x00012324 File Offset: 0x00010524
		public static void Apply(IModHelper modHelper, IMonitor monitor)
		{
			string currentLanguageString = LocalizedContentManager.CurrentLanguageString;
			string text = "BASE";
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (currentLanguageString == "fr-FR")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/fr.json");
				text = "fr";
			}
			if (currentLanguageString == "ru-RU")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/ru.json");
				text = "ru";
			}
			if (currentLanguageString == "it-IT")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/it.json");
				text = "it";
			}
			if (currentLanguageString == "hu-HU")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/hu.json");
				text = "hu";
			}
			if (currentLanguageString == "tr-TR")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/tr.json");
				text = "tr";
			}
			if (currentLanguageString == "es-ES")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/es.json");
				text = "es";
			}
			if (currentLanguageString == "ja-JP")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/ja.json");
				text = "ja";
			}
			if (currentLanguageString == "pt-BR")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/pt.json");
				text = "pt";
			}
			if (currentLanguageString == "zh-CN")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/zh.json");
				text = "zh";
			}
			if (currentLanguageString == "ko-KR")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/ko.json");
				text = "ko";
			}
			if (currentLanguageString == "de-DE")
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/de.json");
				text = "de";
			}
			if (dictionary == null || dictionary.Count < 10)
			{
				dictionary = modHelper.Data.ReadJsonFile<Dictionary<string, string>>("i18n/BASE.json");
				text = "BASE";
			}
			modHelper.Data.WriteJsonFile<Dictionary<string, string>>("i18n/default.json", dictionary);
			monitor.Log(string.Concat(new string[]
			{
				"SKILLFULCLOTHES LANGUAGE SET TO: ",
				currentLanguageString,
				", read as ",
				text,
				". If this is a new language, RELOAD"
			}), (StardewModdingAPI.LogLevel)2);
		}
	}
}
