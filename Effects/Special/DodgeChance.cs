using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000080 RID: 128
	internal class DodgeChance : SingleEffect<DodgeChanceParameters>
	{
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x00003F2B File Offset: 0x0000212B
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x00003F33 File Offset: 0x00002133
		private Item SourceItem { get; set; }

		// Token: 0x060002DA RID: 730 RVA: 0x0000D954 File Offset: 0x0000BB54
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Immunity, EffectHelper.ModHelper.Translation.Get("Spec-GainA") + (int)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) + EffectHelper.ModHelper.Translation.Get("Spec-DodgeC"));
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00003F3C File Offset: 0x0000213C
		public DodgeChance(DodgeChanceParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00003F50 File Offset: 0x00002150
		public DodgeChance(int chance) : base(DodgeChanceParameters.With(chance))
		{
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00003F69 File Offset: 0x00002169
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			EffectHelper.Events.FarmerDamaged += this.Events_UpdateTicking;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00003FA6 File Offset: 0x000021A6
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.FarmerDamaged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000D9DC File Offset: 0x0000BBDC
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (Game1.player.health >= this.playerHealth.Value)
			{
				this.playerHealth.Value = Game1.player.health;
				return;
			}
			if (Game1.random.Next(0, 10) < (int)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) / 10)
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.addHUDMessage(new CustomHUDMessage("Dodge!", this.SourceItem, Color.Gold, TimeSpan.FromSeconds(2.0)));
				}
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("yoba", null, 0);
				}
				Game1.player.health = Math.Min(this.playerHealth.Value, Game1.player.maxHealth);
				return;
			}
			this.playerHealth.Value = Game1.player.health;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00003FC5 File Offset: 0x000021C5
		private void Events_UpdateTicking(object sender, FarmerDamagedEventArgs e)
		{
			if (e.Farmer == Game1.player)
			{
				this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
			}
		}

		// Token: 0x04000289 RID: 649
		private PerScreen<int> playerHealth = new PerScreen<int>();
	}
}
