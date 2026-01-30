using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;

using Object = StardewValley.Object;

namespace SkillfulClothes.Patches
{
	// Token: 0x020000AF RID: 175
	internal class WardrobeCheck
	{
		// Token: 0x06000407 RID: 1031 RVA: 0x00012FF4 File Offset: 0x000111F4
		public static void Apply(IModHelper modHelper)
		{
			modHelper.Events.GameLoop.Saving += WardrobeCheck.SavingEvent;
			modHelper.Events.GameLoop.DayStarted += WardrobeCheck.DayStarted;
			modHelper.Events.Input.ButtonPressed += WardrobeCheck.UpdateTicking;
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00013058 File Offset: 0x00011258
		private static bool FindItem(Item item)
		{
			if (item == null || (item.TypeDefinitionId != "(H)" && item.TypeDefinitionId != "(S)" && item.TypeDefinitionId != "(P)"))
			{
				return true;
			}
			if (WardrobeCheck.HasItemOfType(item.TypeDefinitionId) && WardrobeCheck.ItemOfType(item.TypeDefinitionId).QualifiedItemId == item.QualifiedItemId)
			{
				return true;
			}
			foreach (Item item2 in Game1.player.netItems.Value)
			{
				if (item2 != null && item2.QualifiedItemId == item.QualifiedItemId)
				{
					Item item3 = item2;
					Game1.player.removeItemFromInventory(item2);
					if (WardrobeCheck.HasItemOfType(item3.TypeDefinitionId) && WardrobeCheck.ItemOfType(item3.TypeDefinitionId) != null)
					{
						Game1.player.addItemToInventory(WardrobeCheck.ItemOfType(item3.TypeDefinitionId));
					}
					WardrobeCheck.AddItem(item3);
					return true;
				}
			}
			foreach (Furniture furniture in Game1.player.currentLocation.furniture)
			{
				StorageFurniture storageFurniture = furniture as StorageFurniture;
				if (storageFurniture != null)
				{
					foreach (Item item4 in storageFurniture.heldItems)
					{
						if (item4.QualifiedItemId == item.QualifiedItemId)
						{
							Item item5 = item4;
							storageFurniture.heldItems.Remove(item4);
							if (WardrobeCheck.HasItemOfType(item5.TypeDefinitionId) && WardrobeCheck.ItemOfType(item5.TypeDefinitionId) != null)
							{
								storageFurniture.heldItems.Add(WardrobeCheck.ItemOfType(item5.TypeDefinitionId));
							}
							WardrobeCheck.AddItem(item5);
							return true;
						}
					}
				}
			}
			foreach (KeyValuePair<Vector2, Object> keyValuePair in Game1.player.currentLocation.objects.Pairs)
			{
				Vector2 vector;
				Object @object;
				keyValuePair.Deconstruct(out vector, out @object);
				Chest chest = @object as Chest;
				if (chest != null)
				{
					foreach (Item item6 in chest.netItems.Value)
					{
						if (item6.QualifiedItemId == item.QualifiedItemId)
						{
							Item item7 = item6;
							chest.netItems.Value.Remove(item6);
							if (WardrobeCheck.HasItemOfType(item7.TypeDefinitionId) && WardrobeCheck.ItemOfType(item7.TypeDefinitionId) != null)
							{
								chest.netItems.Value.Add(WardrobeCheck.ItemOfType(item7.TypeDefinitionId));
							}
							WardrobeCheck.AddItem(item7);
							return true;
						}
					}
				}
				Mannequin mannequin = @object as Mannequin;
				if (mannequin != null)
				{
					if (item.TypeDefinitionId == "(H)" && mannequin.hat.Value != null && mannequin.hat.Value.QualifiedItemId == item.QualifiedItemId)
					{
						Item value = mannequin.hat.Value;
						mannequin.hat.Value = null;
						if (WardrobeCheck.HasItemOfType(value.TypeDefinitionId) && WardrobeCheck.ItemOfType(value.TypeDefinitionId) != null)
						{
							mannequin.hat.Value = (WardrobeCheck.ItemOfType(value.TypeDefinitionId) as Hat);
						}
						WardrobeCheck.AddItem(value);
						return true;
					}
					if (item.TypeDefinitionId == "(S)" && mannequin.shirt.Value != null && mannequin.shirt.Value.QualifiedItemId == item.QualifiedItemId)
					{
						Item value2 = mannequin.shirt.Value;
						mannequin.shirt.Value = null;
						if (WardrobeCheck.HasItemOfType(value2.TypeDefinitionId) && WardrobeCheck.ItemOfType(value2.TypeDefinitionId) != null)
						{
							mannequin.shirt.Value = (WardrobeCheck.ItemOfType(value2.TypeDefinitionId) as Clothing);
						}
						WardrobeCheck.AddItem(value2);
						return true;
					}
					if (item.TypeDefinitionId == "(P)" && mannequin.pants.Value != null && mannequin.pants.Value.QualifiedItemId == item.QualifiedItemId)
					{
						Item value3 = mannequin.pants.Value;
						mannequin.pants.Value = null;
						if (WardrobeCheck.HasItemOfType(value3.TypeDefinitionId) && WardrobeCheck.ItemOfType(value3.TypeDefinitionId) != null)
						{
							mannequin.pants.Value = (WardrobeCheck.ItemOfType(value3.TypeDefinitionId) as Clothing);
						}
						WardrobeCheck.AddItem(value3);
						return true;
					}
				}
			}
			if (!EffectHelper.Config.GlobalFarmWardrobe)
			{
				return false;
			}
			if (Game1.getLocationFromName(Game1.player.homeLocation.Value) != null)
			{
				foreach (KeyValuePair<Vector2, Object> keyValuePair2 in Game1.getLocationFromName(Game1.player.homeLocation.Value).objects.Pairs)
				{
					Vector2 vector2;
					Object object2;
					keyValuePair2.Deconstruct(out vector2, out object2);
					Chest chest2 = object2 as Chest;
					if (chest2 != null)
					{
						foreach (Item item8 in chest2.netItems.Value)
						{
							if (item8 != null && item8.QualifiedItemId == item.QualifiedItemId)
							{
								Item item9 = item8;
								chest2.netItems.Value.Remove(item8);
								if (WardrobeCheck.HasItemOfType(item9.TypeDefinitionId) && WardrobeCheck.ItemOfType(item9.TypeDefinitionId) != null)
								{
									chest2.netItems.Value.Add(WardrobeCheck.ItemOfType(item9.TypeDefinitionId));
								}
								WardrobeCheck.AddItem(item9);
								return true;
							}
						}
					}
					Mannequin mannequin2 = object2 as Mannequin;
					if (mannequin2 != null)
					{
						if (item.TypeDefinitionId == "(H)" && mannequin2.hat.Value != null && mannequin2.hat.Value.QualifiedItemId == item.QualifiedItemId)
						{
							Item value4 = mannequin2.hat.Value;
							mannequin2.hat.Value = null;
							if (WardrobeCheck.HasItemOfType(value4.TypeDefinitionId) && WardrobeCheck.ItemOfType(value4.TypeDefinitionId) != null)
							{
								mannequin2.hat.Value = (WardrobeCheck.ItemOfType(value4.TypeDefinitionId) as Hat);
							}
							WardrobeCheck.AddItem(value4);
							return true;
						}
						if (item.TypeDefinitionId == "(S)" && mannequin2.shirt.Value != null && mannequin2.shirt.Value.QualifiedItemId == item.QualifiedItemId)
						{
							Item value5 = mannequin2.shirt.Value;
							mannequin2.shirt.Value = null;
							if (WardrobeCheck.HasItemOfType(value5.TypeDefinitionId) && WardrobeCheck.ItemOfType(value5.TypeDefinitionId) != null)
							{
								mannequin2.shirt.Value = (WardrobeCheck.ItemOfType(value5.TypeDefinitionId) as Clothing);
							}
							WardrobeCheck.AddItem(value5);
							return true;
						}
						if (item.TypeDefinitionId == "(P)" && mannequin2.pants.Value != null && mannequin2.pants.Value.QualifiedItemId == item.QualifiedItemId)
						{
							Item value6 = mannequin2.pants.Value;
							mannequin2.pants.Value = null;
							if (WardrobeCheck.HasItemOfType(value6.TypeDefinitionId) && WardrobeCheck.ItemOfType(value6.TypeDefinitionId) != null)
							{
								mannequin2.pants.Value = (WardrobeCheck.ItemOfType(value6.TypeDefinitionId) as Clothing);
							}
							WardrobeCheck.AddItem(value6);
							return true;
						}
					}
					foreach (Furniture furniture2 in Game1.getLocationFromName(Game1.player.homeLocation.Value).furniture)
					{
						StorageFurniture storageFurniture2 = furniture2 as StorageFurniture;
						if (storageFurniture2 != null)
						{
							foreach (Item item10 in storageFurniture2.heldItems)
							{
								if (item10.QualifiedItemId == item.QualifiedItemId)
								{
									Item item11 = item10;
									storageFurniture2.heldItems.Remove(item10);
									if (WardrobeCheck.HasItemOfType(item11.TypeDefinitionId) && WardrobeCheck.ItemOfType(item11.TypeDefinitionId) != null)
									{
										storageFurniture2.heldItems.Add(WardrobeCheck.ItemOfType(item11.TypeDefinitionId));
									}
									WardrobeCheck.AddItem(item11);
									return true;
								}
							}
						}
					}
				}
			}
			GameLocation farm = Game1.getFarm();
			if (farm != null)
			{
				foreach (KeyValuePair<Vector2, Object> keyValuePair3 in farm.objects.Pairs)
				{
					Vector2 vector3;
					Object object3;
					keyValuePair3.Deconstruct(out vector3, out object3);
					Chest chest3 = object3 as Chest;
					if (chest3 != null)
					{
						foreach (Item item12 in chest3.netItems.Value)
						{
							if (item12 != null && item12.QualifiedItemId == item.QualifiedItemId)
							{
								Item item13 = item12;
								chest3.netItems.Value.Remove(item12);
								if (WardrobeCheck.HasItemOfType(item13.TypeDefinitionId) && WardrobeCheck.ItemOfType(item13.TypeDefinitionId) != null)
								{
									chest3.netItems.Value.Add(WardrobeCheck.ItemOfType(item13.TypeDefinitionId));
								}
								WardrobeCheck.AddItem(item13);
								return true;
							}
						}
					}
					Mannequin mannequin3 = object3 as Mannequin;
					if (mannequin3 != null)
					{
						if (item.TypeDefinitionId == "(H)" && mannequin3.hat.Value != null && mannequin3.hat.Value.QualifiedItemId == item.QualifiedItemId)
						{
							Item value7 = mannequin3.hat.Value;
							mannequin3.hat.Value = null;
							if (WardrobeCheck.HasItemOfType(value7.TypeDefinitionId) && WardrobeCheck.ItemOfType(value7.TypeDefinitionId) != null)
							{
								mannequin3.hat.Value = (WardrobeCheck.ItemOfType(value7.TypeDefinitionId) as Hat);
							}
							WardrobeCheck.AddItem(value7);
							return true;
						}
						if (item.TypeDefinitionId == "(S)" && mannequin3.shirt.Value != null && mannequin3.shirt.Value.QualifiedItemId == item.QualifiedItemId)
						{
							Item value8 = mannequin3.shirt.Value;
							mannequin3.shirt.Value = null;
							if (WardrobeCheck.HasItemOfType(value8.TypeDefinitionId) && WardrobeCheck.ItemOfType(value8.TypeDefinitionId) != null)
							{
								mannequin3.shirt.Value = (WardrobeCheck.ItemOfType(value8.TypeDefinitionId) as Clothing);
							}
							WardrobeCheck.AddItem(value8);
							return true;
						}
						if (item.TypeDefinitionId == "(P)" && mannequin3.pants.Value != null && mannequin3.pants.Value.QualifiedItemId == item.QualifiedItemId)
						{
							Item value9 = mannequin3.pants.Value;
							mannequin3.pants.Value = null;
							if (WardrobeCheck.HasItemOfType(value9.TypeDefinitionId) && WardrobeCheck.ItemOfType(value9.TypeDefinitionId) != null)
							{
								mannequin3.pants.Value = (WardrobeCheck.ItemOfType(value9.TypeDefinitionId) as Clothing);
							}
							WardrobeCheck.AddItem(value9);
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00013DA4 File Offset: 0x00011FA4
		private static void AddItem(Item item)
		{
			string typeDefinitionId = item.TypeDefinitionId;
			if (typeDefinitionId == "(H)")
			{
				Game1.player.Equip<Hat>(item as Hat, Game1.player.hat);
				return;
			}
			if (typeDefinitionId == "(S)")
			{
				Game1.player.Equip<Clothing>(item as Clothing, Game1.player.shirtItem);
				return;
			}
			if (!(typeDefinitionId == "(P)"))
			{
				return;
			}
			Game1.player.Equip<Clothing>(item as Clothing, Game1.player.pantsItem);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x00013E34 File Offset: 0x00012034
		private static bool HasItemOfType(string type)
		{
			if (type == "(H)")
			{
				return Game1.player.hat.Value != null;
			}
			if (!(type == "(S)"))
			{
				return type == "(P)" && Game1.player.pantsItem.Value != null;
			}
			return Game1.player.shirtItem.Value != null;
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x00013EA4 File Offset: 0x000120A4
		private static Item ItemOfType(string type)
		{
			if (type == "(H)")
			{
				return Game1.player.hat.Value;
			}
			if (type == "(S)")
			{
				return Game1.player.shirtItem.Value;
			}
			if (!(type == "(P)"))
			{
				return null;
			}
			return Game1.player.pantsItem.Value;
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00013F0C File Offset: 0x0001210C
		private static void DayStarted(object sender, DayStartedEventArgs eventArgs)
		{
			Dictionary<int, List<string>> dictionary = EffectHelper.ModHelper.Data.ReadJsonFile<Dictionary<int, List<string>>>(string.Concat(new object[]
			{
				"Data/SetPref",
				Game1.MasterPlayer.UniqueMultiplayerID,
				".json"
			}));
			Dictionary<int, string> dictionary2 = EffectHelper.ModHelper.Data.ReadJsonFile<Dictionary<int, string>>(string.Concat(new object[]
			{
				"Data/SetPref",
				Game1.MasterPlayer.UniqueMultiplayerID,
				"Names.json"
			}));
			if (dictionary != null && dictionary.Count > 1)
			{
				WardrobeCheck.savedClothingSets = WardrobeCheck.StringToItemList(dictionary);
				WardrobeCheck.savedClothingSetNames = dictionary2;
				return;
			}
			if (WardrobeCheck.savedClothingSets == null)
			{
				WardrobeCheck.savedClothingSets = new Dictionary<int, List<Item>>();
			}
			if (WardrobeCheck.savedClothingSetNames == null)
			{
				WardrobeCheck.savedClothingSetNames = new Dictionary<int, string>();
			}
			for (int i = 1; i < 7; i++)
			{
				if (!WardrobeCheck.savedClothingSets.ContainsKey(i))
				{
					WardrobeCheck.savedClothingSets.Add(i, new List<Item>
					{
						ItemRegistry.Create("(FL)0", 1, 0, false),
						ItemRegistry.Create("(FL)0", 1, 0, false),
						ItemRegistry.Create("(FL)0", 1, 0, false)
					});
				}
				if (!WardrobeCheck.savedClothingSetNames.ContainsKey(i))
				{
					WardrobeCheck.savedClothingSetNames.Add(i, "Set " + i);
				}
			}
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00014064 File Offset: 0x00012264
		private static void SavingEvent(object sender, SavingEventArgs eventArgs)
		{
			EffectHelper.ModHelper.Data.WriteJsonFile<Dictionary<int, List<string>>>(string.Concat(new object[]
			{
				"Data/SetPref",
				Game1.MasterPlayer.UniqueMultiplayerID,
				".json"
			}), WardrobeCheck.ItemToStringList(WardrobeCheck.savedClothingSets));
			EffectHelper.ModHelper.Data.WriteJsonFile<Dictionary<int, string>>(string.Concat(new object[]
			{
				"Data/SetPref",
				Game1.MasterPlayer.UniqueMultiplayerID,
				"Names.json"
			}), WardrobeCheck.savedClothingSetNames);
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x000140F8 File Offset: 0x000122F8
		private static Dictionary<int, List<string>> ItemToStringList(Dictionary<int, List<Item>> usedDict)
		{
			Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
			for (int i = 1; i < 7; i++)
			{
				List<string> list = new List<string>();
				for (int j = 0; j < 3; j++)
				{
					list.Add(usedDict[i][j].QualifiedItemId);
				}
				dictionary.Add(i, list);
			}
			return dictionary;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0001414C File Offset: 0x0001234C
		private static Dictionary<int, List<Item>> StringToItemList(Dictionary<int, List<string>> usedDict)
		{
			Dictionary<int, List<Item>> dictionary = new Dictionary<int, List<Item>>();
			for (int i = 1; i < 7; i++)
			{
				List<Item> list = new List<Item>();
				for (int j = 0; j < 3; j++)
				{
					list.Add(ItemRegistry.Create(usedDict[i][j], 1, 0, false));
				}
				dictionary.Add(i, list);
			}
			return dictionary;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000141A4 File Offset: 0x000123A4
		private static void SetSet(string name)
		{
			Item item = ItemRegistry.Create("(FL)0", 1, 0, false);
			Item item2 = ItemRegistry.Create("(FL)0", 1, 0, false);
			Item item3 = ItemRegistry.Create("(FL)0", 1, 0, false);
			if (Game1.player.hat.Value != null)
			{
				item = Game1.player.hat.Value;
			}
			if (Game1.player.shirtItem.Value != null)
			{
				item2 = Game1.player.shirtItem.Value;
			}
			if (Game1.player.pantsItem.Value != null)
			{
				item3 = Game1.player.pantsItem.Value;
			}
			List<Item> value = new List<Item>
			{
				item,
				item2,
				item3
			};
			WardrobeCheck.savedClothingSets[WardrobeCheck.editing] = value;
			WardrobeCheck.savedClothingSetNames[WardrobeCheck.editing] = name;
			Game1.exitActiveMenu();
			Game1.activeClickableMenu = new WardrobePage(WardrobeCheck.savedClothingSets, WardrobeCheck.savedClothingSetNames);
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00014294 File Offset: 0x00012494
		private static void UpdateTicking(object sender, ButtonPressedEventArgs e)
		{
			if (Context.IsPlayerFree && EffectHelper.Config.KeysForWardrobeOpening.IsDown())
			{
				Game1.activeClickableMenu = new WardrobePage(WardrobeCheck.savedClothingSets, WardrobeCheck.savedClothingSetNames);
			}
			WardrobePage wardrobePage = Game1.activeClickableMenu as WardrobePage;
			if (wardrobePage == null)
			{
				return;
			}
			if (EffectHelper.Config.KeyForWardrobeSetOne.IsDown())
			{
				if (EffectHelper.Config.ToggleForWardrobeSetReplace.IsDown())
				{
					WardrobeCheck.editing = 1;
					Game1.activeClickableMenu = new NamingMenu(new NamingMenu.doneNamingBehavior(WardrobeCheck.SetSet), EffectHelper.ModHelper.Translation.Get("Menuing17"), "Set " + 1);
					return;
				}
				List<Item> list = new List<Item>();
				WardrobeCheck.savedClothingSets.TryGetValue(1, out list);
				if (WardrobeCheck.FindItem(list[0]) && WardrobeCheck.FindItem(list[1]) && WardrobeCheck.FindItem(list[2]) && (list[0].ItemId != "(FL)0" || list[1].ItemId != "(FL)0" || list[2].ItemId != "(FL)0"))
				{
					if (!EffectHelper.Config.DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("secret1", null, 0);
					}
					Game1.exitActiveMenu();
					return;
				}
			}
			else if (EffectHelper.Config.KeyForWardrobeSetTwo.IsDown())
			{
				if (EffectHelper.Config.ToggleForWardrobeSetReplace.IsDown())
				{
					WardrobeCheck.editing = 2;
					Game1.activeClickableMenu = new NamingMenu(new NamingMenu.doneNamingBehavior(WardrobeCheck.SetSet), EffectHelper.ModHelper.Translation.Get("Menuing17"), "Set " + 2);
					return;
				}
				List<Item> list2 = new List<Item>();
				WardrobeCheck.savedClothingSets.TryGetValue(2, out list2);
				if (WardrobeCheck.FindItem(list2[0]) && WardrobeCheck.FindItem(list2[1]) && WardrobeCheck.FindItem(list2[2]) && (list2[0].QualifiedItemId != "(FL)0" || list2[1].QualifiedItemId != "(FL)0" || list2[2].QualifiedItemId != "(FL)0"))
				{
					if (!EffectHelper.Config.DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("secret1", null, 0);
					}
					Game1.exitActiveMenu();
					return;
				}
			}
			else if (EffectHelper.Config.KeyForWardrobeSetThree.IsDown())
			{
				if (EffectHelper.Config.ToggleForWardrobeSetReplace.IsDown())
				{
					WardrobeCheck.editing = 3;
					Game1.activeClickableMenu = new NamingMenu(new NamingMenu.doneNamingBehavior(WardrobeCheck.SetSet), EffectHelper.ModHelper.Translation.Get("Menuing17"), "Set " + 3);
					return;
				}
				List<Item> list3 = new List<Item>();
				WardrobeCheck.savedClothingSets.TryGetValue(3, out list3);
				if (WardrobeCheck.FindItem(list3[0]) && WardrobeCheck.FindItem(list3[1]) && WardrobeCheck.FindItem(list3[2]) && (list3[0].QualifiedItemId != "(FL)0" || list3[1].QualifiedItemId != "(FL)0" || list3[2].QualifiedItemId != "(FL)0"))
				{
					if (!EffectHelper.Config.DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("secret1", null, 0);
					}
					Game1.exitActiveMenu();
					return;
				}
			}
			else if (EffectHelper.Config.KeyForWardrobeSetFour.IsDown())
			{
				if (EffectHelper.Config.ToggleForWardrobeSetReplace.IsDown())
				{
					WardrobeCheck.editing = 4;
					Game1.activeClickableMenu = new NamingMenu(new NamingMenu.doneNamingBehavior(WardrobeCheck.SetSet), EffectHelper.ModHelper.Translation.Get("Menuing17"), "Set " + 4);
					return;
				}
				List<Item> list4 = new List<Item>();
				WardrobeCheck.savedClothingSets.TryGetValue(4, out list4);
				if (WardrobeCheck.FindItem(list4[0]) && WardrobeCheck.FindItem(list4[1]) && WardrobeCheck.FindItem(list4[2]) && (list4[0].QualifiedItemId != "(FL)0" || list4[1].QualifiedItemId != "(FL)0" || list4[2].QualifiedItemId != "(FL)0"))
				{
					if (!EffectHelper.Config.DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("secret1", null, 0);
					}
					Game1.exitActiveMenu();
					return;
				}
			}
			else if (EffectHelper.Config.KeyForWardrobeSetFive.IsDown())
			{
				if (EffectHelper.Config.ToggleForWardrobeSetReplace.IsDown())
				{
					WardrobeCheck.editing = 5;
					Game1.activeClickableMenu = new NamingMenu(new NamingMenu.doneNamingBehavior(WardrobeCheck.SetSet), EffectHelper.ModHelper.Translation.Get("Menuing17"), "Set " + 5);
					return;
				}
				List<Item> list5 = new List<Item>();
				WardrobeCheck.savedClothingSets.TryGetValue(5, out list5);
				if (WardrobeCheck.FindItem(list5[0]) && WardrobeCheck.FindItem(list5[1]) && WardrobeCheck.FindItem(list5[2]) && (list5[0].QualifiedItemId != "(FL)0" || list5[1].QualifiedItemId != "(FL)0" || list5[2].QualifiedItemId != "(FL)0"))
				{
					if (!EffectHelper.Config.DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("secret1", null, 0);
					}
					Game1.exitActiveMenu();
					return;
				}
			}
			else if (EffectHelper.Config.KeyForWardrobeSetSix.IsDown())
			{
				if (EffectHelper.Config.ToggleForWardrobeSetReplace.IsDown())
				{
					WardrobeCheck.editing = 6;
					Game1.activeClickableMenu = new NamingMenu(new NamingMenu.doneNamingBehavior(WardrobeCheck.SetSet), EffectHelper.ModHelper.Translation.Get("Menuing17"), "Set " + 6);
					return;
				}
				List<Item> list6 = new List<Item>();
				WardrobeCheck.savedClothingSets.TryGetValue(6, out list6);
				if (WardrobeCheck.FindItem(list6[0]) && WardrobeCheck.FindItem(list6[1]) && WardrobeCheck.FindItem(list6[2]) && (list6[0].QualifiedItemId != "(FL)0" || list6[1].QualifiedItemId != "(FL)0" || list6[2].QualifiedItemId != "(FL)0"))
				{
					if (!EffectHelper.Config.DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("secret1", null, 0);
					}
					Game1.exitActiveMenu();
					return;
				}
			}
			else if (EffectHelper.ModHelper.Input.IsDown((StardewModdingAPI.SButton)1000) || EffectHelper.ModHelper.Input.IsDown((StardewModdingAPI.SButton)6096))
			{
				foreach (ClickableComponent clickableComponent in wardrobePage.allClickableComponents)
				{
					if (clickableComponent.containsPoint((int)((float)Game1.getMouseX() * Game1.options.zoomLevel * (1f / Game1.options.uiScale)), (int)((float)Game1.getMouseY() * Game1.options.zoomLevel * (1f / Game1.options.uiScale))))
					{
						if (clickableComponent.name.Contains("Edit"))
						{
							int num = 1;
							int.TryParse(clickableComponent.name.Replace("Edit", ""), out num);
							WardrobeCheck.editing = num;
							Game1.activeClickableMenu = new NamingMenu(new NamingMenu.doneNamingBehavior(WardrobeCheck.SetSet), EffectHelper.ModHelper.Translation.Get("Menuing17"), "Set " + num);
							break;
						}
						if (clickableComponent.name.Contains("Select"))
						{
							int key = 1;
							int.TryParse(clickableComponent.name.Replace("Select", ""), out key);
							List<Item> list7 = new List<Item>();
							WardrobeCheck.savedClothingSets.TryGetValue(key, out list7);
							if (WardrobeCheck.FindItem(list7[0]) && WardrobeCheck.FindItem(list7[1]) && WardrobeCheck.FindItem(list7[2]) && (list7[0].QualifiedItemId != "(FL)0" || list7[1].QualifiedItemId != "(FL)0" || list7[2].QualifiedItemId != "(FL)0"))
							{
								if (!EffectHelper.Config.DisableEffectSFX)
								{
									Game1.player.playNearbySoundLocal("secret1", null, 0);
								}
								Game1.exitActiveMenu();
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x040002E0 RID: 736
		private static Dictionary<int, List<Item>> savedClothingSets;

		// Token: 0x040002E1 RID: 737
		private static Dictionary<int, string> savedClothingSetNames;

		// Token: 0x040002E2 RID: 738
		private static int editing;
	}
}
