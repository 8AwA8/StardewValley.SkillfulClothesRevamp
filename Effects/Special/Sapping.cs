using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008F RID: 143
	internal class Sapping : SingleEffect<SappingParameters>
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000333 RID: 819 RVA: 0x000044B5 File Offset: 0x000026B5
		// (set) Token: 0x06000334 RID: 820 RVA: 0x000044BD File Offset: 0x000026BD
		private Item SourceItem { get; set; }

		// Token: 0x06000335 RID: 821 RVA: 0x000044C6 File Offset: 0x000026C6
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillForaging, EffectHelper.ModHelper.Translation.Get("Spec-Sapping"));
		}

		// Token: 0x06000336 RID: 822 RVA: 0x000044E8 File Offset: 0x000026E8
		public Sapping(SappingParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000044FC File Offset: 0x000026FC
		public Sapping(int chance) : base(SappingParameters.With(chance))
		{
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000E658 File Offset: 0x0000C858
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.lastXp.Value = Game1.player.experiencePoints[2];
			if (Game1.player.getProfessionForSkill(2, 10) == 15)
			{
				this.tapperBuff = 1.2;
			}
			else
			{
				this.tapperBuff = 1.0;
			}
			EffectHelper.ModHelper.Events.World.TerrainFeatureListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked -= this.xpUpdate;
			EffectHelper.ModHelper.Events.World.TerrainFeatureListChanged += this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked += this.xpUpdate;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000E738 File Offset: 0x0000C938
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.World.TerrainFeatureListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked -= this.xpUpdate;
			this.SourceItem = null;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00004515 File Offset: 0x00002715
		private void xpUpdate(object sender, OneSecondUpdateTickedEventArgs e)
		{
			this.lastXp.Value = Game1.player.experiencePoints[2];
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000E78C File Offset: 0x0000C98C
		private void Events_UpdateTicking(object sender, TerrainFeatureListChangedEventArgs e)
		{
			int num = Game1.player.experiencePoints[2];
			if (num - this.lastXp.Value >= 12 && Game1.player.ActiveItem != null && Game1.player.ActiveItem.Name.EndsWith("Axe"))
			{
				this.lastXp.Value = num;
				if ((double)Game1.random.NextInt64(100L) <= (double)((long)((int)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)))) * this.tapperBuff)
				{
					long num2 = Game1.random.NextInt64(100L);
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("coin", null, 0);
					}
					if (num2 <= 50L)
					{
						Item item = ItemRegistry.Create("725", 1, 0, true);
						Game1.player.addItemToInventory(item);
						return;
					}
					if (num2 <= 75L)
					{
						Item item2 = ItemRegistry.Create("724", 1, 0, true);
						Game1.player.addItemToInventory(item2);
						return;
					}
					if (num2 <= 95L)
					{
						Item item3 = ItemRegistry.Create("726", 1, 0, true);
						Game1.player.addItemToInventory(item3);
						return;
					}
					Item item4 = ItemRegistry.Create("MysticSyrup", 1, 0, true);
					Game1.player.addItemToInventory(item4);
				}
				return;
			}
			this.lastXp.Value = Game1.player.experiencePoints[2];
		}

		// Token: 0x0400029E RID: 670
		private double tapperBuff;

		// Token: 0x0400029F RID: 671
		private PerScreen<int> lastXp = new PerScreen<int>();
	}
}
