using System;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004B RID: 75
	internal class KeepTreasureChestWhenFishEscapes : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600018A RID: 394 RVA: 0x000031B2 File Offset: 0x000013B2
		public KeepTreasureChestWhenFishEscapes() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000ABDC File Offset: 0x00008DDC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
			EffectHelper.ModHelper.Events.Display.MenuChanged += this.Display_MenuChanged;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000AC2C File Offset: 0x00008E2C
		private void Display_MenuChanged(object sender, MenuChangedEventArgs e)
		{
			BobberBar bobberBar = e.OldMenu as BobberBar;
			if (bobberBar != null)
			{
				FishingRod fishingRod = Game1.player.CurrentTool as FishingRod;
				if (fishingRod != null)
				{
					IReflectedField<float> field = EffectHelper.ModHelper.Reflection.GetField<float>(bobberBar, "distanceFromCatching", true);
					IReflectedField<bool> field2 = EffectHelper.ModHelper.Reflection.GetField<bool>(bobberBar, "treasureCaught", true);
					if ((double)field.GetValue() < 0.1 && field2.GetValue())
					{
						fishingRod.treasureCaught = true;
						fishingRod.openTreasureMenuEndFunction(0);
					}
				}
			}
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00003203 File Offset: 0x00001403
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00003225 File Offset: 0x00001425
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.TreasureChest, EffectHelper.ModHelper.Translation.Get("Spec-TreasKeep"));
		}
	}
}
