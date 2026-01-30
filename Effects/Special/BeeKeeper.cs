using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009A RID: 154
	internal class BeeKeeper : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600037B RID: 891 RVA: 0x00004934 File Offset: 0x00002B34
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFarming, EffectHelper.ModHelper.Translation.Get("Spec-BK"));
		}

		// Token: 0x0600037C RID: 892 RVA: 0x000031B2 File Offset: 0x000013B2
		public BeeKeeper() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600037D RID: 893 RVA: 0x000108E4 File Offset: 0x0000EAE4
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x00010934 File Offset: 0x0000EB34
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			foreach (Item item in e.Added)
			{
				if (item != null && item.ItemId == "340" && !item.Name.EndsWith(" C"))
				{
					Item item2 = item;
					item2.Name += " C";
					double num = Game1.random.NextDouble();
					if (item.Name.StartsWith("Tulip"))
					{
						if (num < 0.6 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							break;
						}
						if (num < 0.8 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("427", 3 * item.Stack, 0, false), null, false);
							break;
						}
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("591", (int)((float)item.Stack * MathF.Ceiling(((float)Game1.player.FarmingLevel + (float)Game1.player.ForagingLevel) / 12f)), 0, false), null, false);
						break;
					}
					else if (item.Name.StartsWith("Blue Jazz"))
					{
						if (num < 0.6 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							break;
						}
						if (num < 0.8 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("429", 3 * item.Stack, 0, false), null, false);
							break;
						}
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("597", (int)((float)item.Stack * MathF.Ceiling(((float)Game1.player.FarmingLevel + (float)Game1.player.ForagingLevel) / 12f)), 0, false), null, false);
						break;
					}
					else if (item.Name.StartsWith("Summer Spangle"))
					{
						if (num < 0.6 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							break;
						}
						if (num < 0.8 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("455", 3 * item.Stack, 0, false), null, false);
							break;
						}
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("593", (int)((float)item.Stack * MathF.Ceiling(((float)Game1.player.FarmingLevel + (float)Game1.player.ForagingLevel) / 12f)), 0, false), null, false);
						break;
					}
					else if (item.Name.StartsWith("Poppy"))
					{
						if (num < 0.6 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							break;
						}
						if (num < 0.8 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("453", 3 * item.Stack, 0, false), null, false);
							break;
						}
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("376", (int)((float)item.Stack * MathF.Ceiling(((float)Game1.player.FarmingLevel + (float)Game1.player.ForagingLevel) / 12f)), 0, false), null, false);
						break;
					}
					else if (item.Name.StartsWith("Sunflower"))
					{
						if (num < 0.6 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							break;
						}
						if (num < 0.8 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("431", 3 * item.Stack, 0, false), null, false);
							break;
						}
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("421", (int)((float)item.Stack * MathF.Ceiling(((float)Game1.player.FarmingLevel + (float)Game1.player.ForagingLevel) / 12f)), 0, false), null, false);
						break;
					}
					else if (item.Name.StartsWith("Fairy Rose"))
					{
						if (num < 0.6 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							break;
						}
						if (num < 0.8 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("425", 3 * item.Stack, 0, false), null, false);
							break;
						}
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("595", (int)((float)item.Stack * MathF.Ceiling(((float)Game1.player.FarmingLevel + (float)Game1.player.ForagingLevel) / 12f)), 0, false), null, false);
						break;
					}
					else
					{
						if (num < 0.6 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							break;
						}
						if (num < 0.8 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1.15 : 1.0))
						{
							Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("771", 3 * item.Stack, 0, false), null, false);
							break;
						}
						if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.addItemByMenuIfNecessary(ItemRegistry.Create("885", 3 * (int)((float)item.Stack * MathF.Ceiling(((float)Game1.player.FarmingLevel + (float)Game1.player.ForagingLevel) / 12f)), 0, false), null, false);
						break;
					}
				}
			}
		}

		// Token: 0x0600037F RID: 895 RVA: 0x00004956 File Offset: 0x00002B56
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
		}
	}
}
