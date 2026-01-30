using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008A RID: 138
	internal class OnKill : SingleEffect<OnKillParameters>
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000316 RID: 790 RVA: 0x00004316 File Offset: 0x00002516
		// (set) Token: 0x06000317 RID: 791 RVA: 0x0000431E File Offset: 0x0000251E
		private Item SourceItem { get; set; }

		// Token: 0x06000318 RID: 792 RVA: 0x0000DFA4 File Offset: 0x0000C1A4
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			if (base.Parameters.UniqueEff == 0)
			{
				return new EffectDescriptionLine(EffectIcon.SaveFromDeath, EffectHelper.ModHelper.Translation.Get("OK-Gain") + MathF.Round((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f), 2) + EffectHelper.ModHelper.Translation.Get("OK-EN"));
			}
			return new EffectDescriptionLine(EffectIcon.SaveFromDeath, EffectHelper.ModHelper.Translation.Get("OK-Gain") + MathF.Round((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f), 2) + EffectHelper.ModHelper.Translation.Get("OK-HP"));
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00004327 File Offset: 0x00002527
		public OnKill(OnKillParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000433B File Offset: 0x0000253B
		public OnKill(int UniqueEff, int amount) : base(OnKillParameters.With(UniqueEff, amount))
		{
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000E0BC File Offset: 0x0000C2BC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.World.NpcListChanged += this.Events_UpdateTicking;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00004355 File Offset: 0x00002555
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000E12C File Offset: 0x0000C32C
		private void Events_UpdateTicking(object sender, NpcListChangedEventArgs e)
		{
			if (!e.IsCurrentLocation)
			{
				return;
			}
			if (this.monstersSlain.Value < (int)Game1.player.stats.MonstersKilled)
			{
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("healSound", null, 0);
				}
				if (base.Parameters.UniqueEff == 0)
				{
					if (Game1.player.stamina + (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) < (float)Game1.player.MaxStamina)
					{
						Game1.player.stamina += (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
					}
					else
					{
						Game1.player.stamina = (float)Game1.player.MaxStamina;
					}
				}
				else if (Game1.player.health + (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) < Game1.player.maxHealth)
				{
					Game1.player.health += (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f));
				}
				else
				{
					Game1.player.health = Game1.player.maxHealth;
				}
				this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			}
		}

		// Token: 0x04000296 RID: 662
		private PerScreen<int> monstersSlain = new PerScreen<int>();
	}
}
