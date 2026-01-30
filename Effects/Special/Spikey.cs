using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000086 RID: 134
	internal class Spikey : SingleEffect<SpikeyParameters>
	{
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060002FC RID: 764 RVA: 0x00004185 File Offset: 0x00002385
		// (set) Token: 0x060002FD RID: 765 RVA: 0x0000418D File Offset: 0x0000238D
		private Item SourceItem { get; set; }

		// Token: 0x060002FE RID: 766 RVA: 0x00004196 File Offset: 0x00002396
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.MaxHealth, EffectHelper.ModHelper.Translation.Get("Spec-Spikey"));
		}

		// Token: 0x060002FF RID: 767 RVA: 0x000041B7 File Offset: 0x000023B7
		public Spikey(SpikeyParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000041CB File Offset: 0x000023CB
		public Spikey(int damage) : base(SpikeyParameters.With(damage))
		{
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000041E4 File Offset: 0x000023E4
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			EffectHelper.Events.FarmerDamaged += this.Events_UpdateTicking;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00004219 File Offset: 0x00002419
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0000DDAC File Offset: 0x0000BFAC
		private void Events_UpdateTicking(object sender, FarmerDamagedEventArgs e)
		{
			if (e.Farmer != Game1.player)
			{
				return;
			}
			if (Game1.player.health >= this.playerHealth.Value)
			{
				this.playerHealth.Value = Game1.player.health;
				return;
			}
			Game1.player.currentLocation.explode(Game1.player.Tile, 1, Game1.player, false, base.Parameters.ExtraDamage + (int)((float)(this.playerHealth.Value - Game1.player.health + Game1.player.buffs.Defense) * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), false);
			this.playerHealth.Value = Game1.player.health;
		}

		// Token: 0x0400028F RID: 655
		private PerScreen<int> playerHealth = new PerScreen<int>();
	}
}
