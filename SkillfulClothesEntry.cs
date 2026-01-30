using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Patches;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;

namespace SkillfulClothes
{
	// Token: 0x02000015 RID: 21
	public class SkillfulClothesEntry : Mod
	{
		// Token: 0x0600006C RID: 108 RVA: 0x00006608 File Offset: 0x00004808
		public override void Entry(IModHelper helper)
		{
			SkillfulClothesConfig skillfulClothesConfig = helper.ReadConfig<SkillfulClothesConfig>();
			this.helper = helper;
			this.Config = skillfulClothesConfig;
			TranslationPatches.Apply(this.helper, base.Monitor);
			bool verboseLogging = skillfulClothesConfig.verboseLogging;
			Logger.Init(base.Monitor, verboseLogging);
			EffectHelper.Init(helper, skillfulClothesConfig);
			CustomEffectDefinitions.LoadCustomEffectDefinitions();
			HarmonyPatches.Apply("Nature.1011108");
			ForgePatches.Apply(helper);
			WardrobeCheck.Apply(helper);
			if (EffectHelper.Config.CritDamageBalanceActive)
			{
				CritBalance.Apply(helper);
			}
			this.clothingObserver = EffectHelper.ClothingObserver;
			helper.Events.GameLoop.GameLaunched += this.GameLoop_GameLaunched;
			helper.Events.GameLoop.UpdateTicked += this.FirstUpdateTicked;
			helper.Events.GameLoop.DayStarted += this.GameLoop_DayStarted;
			helper.Events.GameLoop.DayEnding += this.GameLoop_DayEnding;
			helper.Events.GameLoop.ReturnedToTitle += this.GameLoop_ReturnedToTitle;
			helper.Events.Content.LocaleChanged += this.On_LocaleChanged;
			helper.Events.Player.Warped += this.warped;
			GameLocation.RegisterTileAction("NatSkillRev", new Func<GameLocation, string[], Farmer, Point, bool>(this.ReturnHome));
			EffectHelper.Events.ClothingChanged += this.GameLoop_UpdateTicked;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00006780 File Offset: 0x00004980
		private void GameLoop_GameLaunched(object sender, GameLaunchedEventArgs e)
		{
			IGenericModConfigMenuApi api = base.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
			if (api == null)
			{
				return;
			}
			api.Register(base.ModManifest, delegate
			{
				this.Config = new SkillfulClothesConfig();
			}, delegate
			{
				base.Helper.WriteConfig<SkillfulClothesConfig>(this.Config);
			}, false);
			api.AddBoolOption(base.ModManifest, () => this.Config.LessImpactfulClothes, delegate(bool value)
			{
				this.Config.LessImpactfulClothes = value;
			}, () => this.helper.Translation.Get("Menuing1"), () => this.helper.Translation.Get("Menuing2"), null);
			api.AddNumberOption(base.ModManifest, () => this.Config.TypicalClothesMultiple, delegate(float value)
			{
				this.Config.TypicalClothesMultiple = value;
			}, () => this.helper.Translation.Get("MenuingTypical"), () => this.helper.Translation.Get("MenuingTypicalInfo"), new float?(0.05f), new float?(0.95f), new float?(0.05f), null, null);
			api.AddNumberOption(base.ModManifest, () => this.Config.LovingRancherRate, delegate(float value)
			{
				this.Config.LovingRancherRate = value;
			}, () => this.helper.Translation.Get("MenuingRancher"), () => this.helper.Translation.Get("MenuingRancherInfo"), new float?(0.05f), new float?(1.95f), new float?(0.05f), null, null);
			api.AddBoolOption(base.ModManifest, () => this.Config.EnableClothingForge, delegate(bool value)
			{
				this.Config.EnableClothingForge = value;
			}, () => this.helper.Translation.Get("Menuing3"), () => this.helper.Translation.Get("Menuing4"), null);
			api.AddBoolOption(base.ModManifest, () => this.Config.CritDamageBalanceActive, delegate(bool value)
			{
				this.Config.CritDamageBalanceActive = value;
			}, () => this.helper.Translation.Get("Menuing19"), () => this.helper.Translation.Get("Menuing20"), null);
			api.AddBoolOption(base.ModManifest, () => this.Config.OneToOneSpeed, delegate(bool value)
			{
				this.Config.OneToOneSpeed = value;
			}, () => "1:1 Speed", () => "", null);
			api.AddBoolOption(base.ModManifest, () => this.Config.AutoWaterCanReq, delegate(bool value)
			{
				this.Config.AutoWaterCanReq = value;
			}, () => this.helper.Translation.Get("Config-WC"), () => "", null);
			api.AddBoolOption(base.ModManifest, () => this.Config.DisableWhenActiveAlerts, delegate(bool value)
			{
				this.Config.DisableWhenActiveAlerts = value;
			}, () => this.helper.Translation.Get("Menuing5"), () => this.helper.Translation.Get("Menuing6"), null);
			api.AddBoolOption(base.ModManifest, () => this.Config.DisableEffectSFX, delegate(bool value)
			{
				this.Config.DisableEffectSFX = value;
			}, () => this.helper.Translation.Get("Menuing7"), () => this.helper.Translation.Get("Menuing8"), null);
			api.AddBoolOption(base.ModManifest, () => this.Config.GlobalFarmWardrobe, delegate(bool value)
			{
				this.Config.GlobalFarmWardrobe = value;
			}, () => this.helper.Translation.Get("Menuing22"), () => this.helper.Translation.Get("Menuing21"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.KeysForWardrobeOpening, delegate(KeybindList value)
			{
				this.Config.KeysForWardrobeOpening = value;
			}, () => this.helper.Translation.Get("Menuing18"), () => this.helper.Translation.Get("Menuing18"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.KeyForWardrobeSetOne, delegate(KeybindList value)
			{
				this.Config.KeyForWardrobeSetOne = value;
			}, () => this.helper.Translation.Get("Menuing9"), () => this.helper.Translation.Get("Menuing9"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.KeyForWardrobeSetTwo, delegate(KeybindList value)
			{
				this.Config.KeyForWardrobeSetTwo = value;
			}, () => this.helper.Translation.Get("Menuing10"), () => this.helper.Translation.Get("Menuing10"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.KeyForWardrobeSetThree, delegate(KeybindList value)
			{
				this.Config.KeyForWardrobeSetThree = value;
			}, () => this.helper.Translation.Get("Menuing11"), () => this.helper.Translation.Get("Menuing11"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.KeyForWardrobeSetFour, delegate(KeybindList value)
			{
				this.Config.KeyForWardrobeSetFour = value;
			}, () => this.helper.Translation.Get("Menuing12"), () => this.helper.Translation.Get("Menuing12"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.KeyForWardrobeSetFive, delegate(KeybindList value)
			{
				this.Config.KeyForWardrobeSetFive = value;
			}, () => this.helper.Translation.Get("Menuing13"), () => this.helper.Translation.Get("Menuing13"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.KeyForWardrobeSetSix, delegate(KeybindList value)
			{
				this.Config.KeyForWardrobeSetSix = value;
			}, () => this.helper.Translation.Get("Menuing14"), () => this.helper.Translation.Get("Menuing14"), null);
			api.AddKeybindList(base.ModManifest, () => this.Config.ToggleForWardrobeSetReplace, delegate(KeybindList value)
			{
				this.Config.ToggleForWardrobeSetReplace = value;
			}, () => this.helper.Translation.Get("Menuing15"), () => this.helper.Translation.Get("Menuing15"), null);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000240B File Offset: 0x0000060B
		private void GameLoop_ReturnedToTitle(object sender, ReturnedToTitleEventArgs e)
		{
			this.clothingObserver.Reset(Game1.player);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000241D File Offset: 0x0000061D
		private void GameLoop_DayStarted(object sender, DayStartedEventArgs e)
		{
			this.clothingObserver.Restore(Game1.player, EffectChangeReason.DayStart);
			EffectHelper.Events.RaiseClothingChanged();
			this.newday = true;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002441 File Offset: 0x00000641
		private void GameLoop_DayEnding(object sender, DayEndingEventArgs e)
		{
			this.clothingObserver.Suspend(Game1.player, EffectChangeReason.DayEnd);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00002454 File Offset: 0x00000654
		private void On_LocaleChanged(object sender, LocaleChangedEventArgs eventArgs)
		{
			TranslationPatches.Apply(this.helper, base.Monitor);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00002467 File Offset: 0x00000667
		private void GameLoop_UpdateTicked(object sender, EventArgs e)
		{
			if (!Context.IsWorldReady)
			{
				return;
			}
			this.clothingObserver.Update(Game1.player);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00006E9C File Offset: 0x0000509C
		private void FirstUpdateTicked(object sender, UpdateTickedEventArgs e)
		{
			if (!Context.IsWorldReady)
			{
				return;
			}
			this.clothingObserver.Update(Game1.player);
			EffectHelper.Events.RaiseClothingChanged();
			this.helper.Events.GameLoop.UpdateTicked -= this.FirstUpdateTicked;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00006EEC File Offset: 0x000050EC
		private bool ReturnHome(GameLocation location, string[] args, Farmer player, Point point)
		{
			Utility.TryOpenShopMenu("Nature.SKillfulRev_ClothesShop", Game1.player.currentLocation, null, null, true, true, null);
			ShopMenu shopMenu = Game1.activeClickableMenu as ShopMenu;
			Dictionary<ISalable, ItemStockInformation> itemPriceAndStock = shopMenu.itemPriceAndStock;
			List<ISalable> forSale = shopMenu.forSale;
			List<string> list = new List<string>();
			itemPriceAndStock.Clear();
			forSale.Clear();
			for (int i = 0; i < 3; i++)
			{
				string text = "";
				if (Game1.currentLocation.modData.ContainsKey("NatureSkillfulClothes" + i.ToString()))
				{
					Game1.currentLocation.modData.TryGetValue("NatureSkillfulClothes" + i.ToString(), out text);
				}
				if (text != "")
				{
					list.Add(text);
				}
			}
			if ((list.Count == 0 || Game1.dayOfMonth % 7 == 0) && this.newday)
			{
				this.newday = false;
				list.Clear();
				for (int j = 0; j < 3; j++)
				{
					string item = this.itemIds[Game1.random.Next(this.itemIds.Count - 1)];
					if (list.Contains(item))
					{
						j--;
					}
					else
					{
						list.Add(item);
						Game1.currentLocation.modData["NatureSkillfulClothes" + j.ToString()] = list[j];
					}
				}
			}
			foreach (string text2 in list)
			{
				Item item2 = ItemRegistry.Create(text2, 1, 0, false);
				forSale.Add(item2);
				itemPriceAndStock.Add(item2, new ItemStockInformation(3000, int.MaxValue, null, null, 0, null, null, null, null));
			}
			shopMenu.itemPriceAndStock = itemPriceAndStock;
			return true;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000070E8 File Offset: 0x000052E8
		private void warped(object sender, WarpedEventArgs eventArgs)
		{
			if (eventArgs.NewLocation.Name == "HaleyHouse")
			{
				eventArgs.NewLocation.setTileProperty(16, 23, "Buildings", "Action", "None");
				eventArgs.NewLocation.setTileProperty(16, 23, "Buildings", "Action", "NatSkillRev");
				eventArgs.NewLocation.setTileProperty(16, 24, "Buildings", "Action", "None");
				eventArgs.NewLocation.setTileProperty(16, 24, "Buildings", "Action", "NatSkillRev");
			}
		}

		// Token: 0x0400002B RID: 43
		private ClothingObserver clothingObserver;

		// Token: 0x0400002C RID: 44
		private SkillfulClothesConfig Config;

		// Token: 0x0400002D RID: 45
		public IModHelper helper;

		// Token: 0x0400002E RID: 46
		private List<string> itemIds = new List<string>
		{
			"(H)70",
			"(H)44",
			"(H)88",
			"(H)57",
			"(H)49",
			"(H)55",
			"(H)54",
			"(H)53",
			"(H)43",
			"(H)67",
			"(H)48",
			"(H)87",
			"(S)1195",
			"(S)1265",
			"(S)1237",
			"(S)1148",
			"(S)1276",
			"(S)1247",
			"(S)1183",
			"(S)1001",
			"(S)1028",
			"(S)1225",
			"(S)1042",
			"(S)1187",
			"(S)1193",
			"(S)1200",
			"(S)1287",
			"(S)1282",
			"(S)1004",
			"(S)1014",
			"(S)1005",
			"(S)1205",
			"(S)1188",
			"(S)1194",
			"(S)1285",
			"(S)1236",
			"(S)1071",
			"(P)1",
			"(P)2",
			"(P)3",
			"(P)0",
			"(P)4",
			"(P)8",
			"(P)11"
		};

		// Token: 0x0400002F RID: 47
		private bool newday = true;
	}
}
