using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000081 RID: 129
	internal class AutoWater : SingleEffect<NoEffectParameters>
	{
		// Token: 0x060002E1 RID: 737 RVA: 0x00003FE1 File Offset: 0x000021E1
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFarming, EffectHelper.ModHelper.Translation.Get("Spec-AW"));
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x000031B2 File Offset: 0x000013B2
		public AutoWater() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000DB0C File Offset: 0x0000BD0C
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000DB5C File Offset: 0x0000BD5C
		private void GameLoop_UpdateTicking(object sender, UpdateTickingEventArgs e)
		{
			if (Context.IsPlayerFree && Game1.player.currentLocation.isTileHoeDirt(Game1.player.Tile) && !Game1.player.currentLocation.GetHoeDirtAtTile(Game1.player.Tile).isWatered() && Game1.player.stamina > 0f && ((Game1.player.ActiveItem != null && Game1.player.ActiveItem is WateringCan && (Game1.player.ActiveItem as WateringCan).WaterLeft >= 1) || !EffectHelper.Config.AutoWaterCanReq))
			{
				Game1.player.currentLocation.GetHoeDirtAtTile(Game1.player.Tile).state.Value = 1;
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("wateringCan", null, 0);
				}
				Game1.player.stamina = Game1.player.stamina - Math.Max(1f - (float)Game1.player.FarmingLevel / 18f, 0f);
				if (EffectHelper.Config.AutoWaterCanReq)
				{
					(Game1.player.ActiveItem as WateringCan).WaterLeft = Math.Max(0, (Game1.player.ActiveItem as WateringCan).WaterLeft - 1);
				}
				return;
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00004003 File Offset: 0x00002203
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking -= this.GameLoop_UpdateTicking;
		}
	}
}
