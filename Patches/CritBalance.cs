using System;
using SkillfulClothes.Effects.Skills;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace SkillfulClothes.Patches
{
	// Token: 0x020000B1 RID: 177
	internal class CritBalance
	{
		// Token: 0x06000415 RID: 1045 RVA: 0x00004FAB File Offset: 0x000031AB
		public static void Apply(IModHelper modHelper)
		{
			modHelper.Events.GameLoop.DayStarted += CritBalance.DayStart;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x00004FC9 File Offset: 0x000031C9
		private static void DayStart(object sender, DayStartedEventArgs e)
		{
			new IncreaseCritDamage(-25).Apply(null, EffectChangeReason.DayStart);
		}
	}
}
