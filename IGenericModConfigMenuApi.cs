using System;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace SkillfulClothes
{
	// Token: 0x020000A0 RID: 160
	public interface IGenericModConfigMenuApi
	{
		// Token: 0x060003A9 RID: 937
		void Register(IManifest mod, Action reset, Action save, bool titleScreenOnly = false);

		// Token: 0x060003AA RID: 938
		void AddBoolOption(IManifest mod, Func<bool> getValue, Action<bool> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);

		// Token: 0x060003AB RID: 939
		void Unregister(IManifest mod);

		// Token: 0x060003AC RID: 940
		void AddKeybindList(IManifest mod, Func<KeybindList> getValue, Action<KeybindList> setValue, Func<string> name, Func<string> tooltip = null, string fieldId = null);

		// Token: 0x060003AD RID: 941
		void AddNumberOption(IManifest mod, Func<float> getValue, Action<float> setValue, Func<string> name, Func<string> tooltip = null, float? min = null, float? max = null, float? interval = null, Func<float, string> formatValue = null, string fieldId = null);
	}
}
