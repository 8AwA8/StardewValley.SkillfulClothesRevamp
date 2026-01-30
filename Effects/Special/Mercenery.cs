using System;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000093 RID: 147
	internal class Mercenery : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600034D RID: 845 RVA: 0x00004650 File Offset: 0x00002850
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillCombat, EffectHelper.ModHelper.Translation.Get("Spec-Mercen"));
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00004672 File Offset: 0x00002872
		public Mercenery() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000EF34 File Offset: 0x0000D134
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.lastkills.Value = (int)Game1.player.stats.MonstersKilled;
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
			
			if (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				return;
			Buff buff = new Buff("Nature.1011108.MERC" + sourceItem.QualifiedItemId, EffectHelper.ModHelper.Translation.Get("Base-SCName"), EffectHelper.ModHelper.Translation.Get("Base-SCName"), Buff.ENDLESS, Game1.content.Load<Texture2D>("TileSheets\\BuffsIcons"), 20, null, new bool?(false), EffectHelper.ModHelper.Translation.Get("Spec-Mercen"), null);
			Game1.player.applyBuff(buff);
			this.isApplied.Value = true;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000EF9C File Offset: 0x0000D19C
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			int monstersKilled = (int)Game1.player.stats.MonstersKilled;
			if (this.lastkills.Value < monstersKilled)
			{
				foreach (Item item in e.Added)
				{
					if (item != null && (item.Category == -28 || item.ItemId == "413" || item.ItemId == "437" || item.ItemId == "439" || item.ItemId == "680" || item.ItemId == "766" || item.ItemId == "857"))
					{
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("moneyDial", null, 0);
						}
						Game1.player.Money += (int)((float)item.salePrice(false) * (float)item.Stack * Game1.MasterPlayer.difficultyModifier * Math.Max(2.5f, 2.5f + (float)Game1.player.CombatLevel / 7f) * 0.5f * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f));
						Game1.player.removeItemFromInventory(item);
					}
				}
			}
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000468A File Offset: 0x0000288A
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			
			Game1.player.buffs.Remove("Nature.1011108.MERC" + sourceItem.QualifiedItemId);
			isApplied.Value = false;
		}
		
		// Token: 0x040002C5 RID: 709
		private PerScreen<bool> isApplied = new PerScreen<bool>();

		// Token: 0x040002A4 RID: 676
		private PerScreen<int> lastkills = new PerScreen<int>();
	}
}
