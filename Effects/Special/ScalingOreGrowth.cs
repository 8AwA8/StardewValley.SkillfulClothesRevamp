using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000090 RID: 144
	internal class ScalingOreGrowth : SingleEffect<NoEffectParameters>
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600033C RID: 828 RVA: 0x00004532 File Offset: 0x00002732
		// (set) Token: 0x0600033D RID: 829 RVA: 0x0000453A File Offset: 0x0000273A
		private Item SourceItem { get; set; }

		// Token: 0x0600033E RID: 830 RVA: 0x00004543 File Offset: 0x00002743
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillMining, EffectHelper.ModHelper.Translation.Get("Spec-SOG"));
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00004565 File Offset: 0x00002765
		public ScalingOreGrowth() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0000E920 File Offset: 0x0000CB20
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.rocks.Value = (int)Game1.player.stats.RocksCrushed;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking += this.Events_UpdateTicking;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00004588 File Offset: 0x00002788
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000E990 File Offset: 0x0000CB90
		private void Events_UpdateTicking(object sender, OneSecondUpdateTickingEventArgs e)
		{
			int rocksCrushed = (int)Game1.player.stats.RocksCrushed;
			if (rocksCrushed > this.rocks.Value)
			{
				this.count.Value += rocksCrushed - this.rocks.Value;
				this.rocks.Value = rocksCrushed;
				if (this.count.Value >= (int)(5f * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? (1f / EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1f)))
				{
					this.count.Value = 0;
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("coin", null, 0);
					}
					MineShaft mineShaft = Game1.player.currentLocation as MineShaft;
					if (mineShaft != null)
					{
						bool minesV = Game1.netWorldState.Value.MinesDifficulty > 0 && mineShaft.mineLevel < 120;
						bool skullV = Game1.netWorldState.Value.SkullCavesDifficulty > 0 && mineShaft.mineLevel > 119;
						if ((minesV || skullV) && Game1.random.NextDouble() < 0.33)
						{
							Item item = ItemRegistry.Create("909", 1, 0, true);
							Game1.player.addItemToInventory(item);
						}
						
						if (mineShaft.mineLevel < 40)
						{
							Item item = ItemRegistry.Create("378", 1, 0, true);
							Game1.player.addItemToInventory(item);
						}
						else if (mineShaft.mineLevel < 70)
						{
							Item item2 = ItemRegistry.Create("380", 1, 0, true);
							Game1.player.addItemToInventory(item2);
						}
						else if (mineShaft.mineLevel < 120)
						{
							Item item3 = ItemRegistry.Create("384", 1, 0, true);
							Game1.player.addItemToInventory(item3);
						}
						else if (mineShaft.mineLevel < 160)
						{
							Item item4 = ItemRegistry.Create("382", 1, 0, true);
							Game1.player.addItemToInventory(item4);
						}
						else if (mineShaft.mineLevel < 220)
						{
							Item item5 = ItemRegistry.Create("386", 1, 0, true);
							Game1.player.addItemToInventory(item5);
						}
						else
						{
							Item item6 = ItemRegistry.Create("337", 1, 0, true);
							Game1.player.addItemToInventory(item6);
						}
					}
					else if (Game1.player.currentLocation is VolcanoDungeon)
					{
						Item item7 = ItemRegistry.Create("848", 1, 0, true);
						Game1.player.addItemToInventory(item7);
					}
					else
					{
						Item item8 = ItemRegistry.Create("330", 1, 0, true);
						Game1.player.addItemToInventory(item8);
					}
				}
			}
			this.rocks.Value = rocksCrushed;
		}

		// Token: 0x040002A1 RID: 673
		private PerScreen<int> rocks = new PerScreen<int>();

		// Token: 0x040002A2 RID: 674
		private PerScreen<int> count = new PerScreen<int>();
	}
}
