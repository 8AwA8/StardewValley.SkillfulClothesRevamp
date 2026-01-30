using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000044 RID: 68
	internal class AutoRevive : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000161 RID: 353 RVA: 0x0000300B File Offset: 0x0000120B
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SaveFromDeath, EffectHelper.ModHelper.Translation.Get("Spec-AR"));
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000302D File Offset: 0x0000122D
		public AutoRevive() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00003045 File Offset: 0x00001245
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.FarmerDamaged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00003073 File Offset: 0x00001273
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00009FA8 File Offset: 0x000081A8
		private void GameLoop_UpdateTicking(object sender, FarmerDamagedEventArgs e)
		{
			if (e.Farmer != Game1.player)
			{
				return;
			}
			if (Game1.player.health <= 0 && this.day.Value != Game1.dayOfMonth && (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes || (this.day.Value != Game1.dayOfMonth - 1 && this.day.Value != 31 && Game1.dayOfMonth != 1)))
			{
				this.day.Value = Game1.dayOfMonth;
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("cowboy_explosion", null, 0);
				}
				Game1.currentLocation.explode(Game1.player.Tile, 5, Game1.player, false, 5, false);
				Game1.player.health = Game1.player.maxHealth / 2;
			}
		}

		// Token: 0x0400021C RID: 540
		private PerScreen<int> day = new PerScreen<int>();
	}
}
