using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004A RID: 74
	internal class IncreaseFishingTreasureChestChance : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000185 RID: 389 RVA: 0x000031B2 File Offset: 0x000013B2
		public IncreaseFishingTreasureChestChance() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
			EffectHelper.ModHelper.Events.Display.MenuChanged += this.Display_MenuChanged;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000AB00 File Offset: 0x00008D00
		private void Display_MenuChanged(object sender, MenuChangedEventArgs e)
		{
			BobberBar bobberBar = e.NewMenu as BobberBar;
			if (bobberBar != null && !Game1.isFestival())
			{
				IReflectedField<bool> field = EffectHelper.ModHelper.Reflection.GetField<bool>(bobberBar, "treasure", true);
				if (!field.GetValue() && Game1.random.Next(0, 6) <= (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1 : 2))
				{
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
					}
					Logger.Debug("Added treasure");
					EffectHelper.ModHelper.Reflection.GetField<float>(bobberBar, "treasureAppearTimer", true).SetValue((float)Game1.random.Next(1000, 3000));
					field.SetValue(true);
				}
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000031BF File Offset: 0x000013BF
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000031E1 File Offset: 0x000013E1
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.TreasureChest, EffectHelper.ModHelper.Translation.Get("Spec-TreasChance"));
		}
	}
}
