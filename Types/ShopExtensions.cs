using System;
using StardewValley;
using StardewValley.Menus;

namespace SkillfulClothes.Types
{
	// Token: 0x0200002F RID: 47
	public static class ShopExtensions
	{
		// Token: 0x0600010C RID: 268 RVA: 0x00008C3C File Offset: 0x00006E3C
		public static string GetShopReferral(this Shop shop)
		{
			if (shop <= Shop.Pierre)
			{
				if (shop <= Shop.Willy)
				{
					if (shop == Shop.Clint)
					{
						return "Clint";
					}
					if (shop == Shop.Willy)
					{
						return "Willy";
					}
				}
				else
				{
					if (shop == Shop.Marnie)
					{
						return "Marnie";
					}
					if (shop == Shop.Pierre)
					{
						return "Pierre";
					}
				}
			}
			else if (shop <= Shop.Dwarf)
			{
				if (shop == Shop.Robin)
				{
					return "Robin";
				}
				if (shop == Shop.Dwarf)
				{
					return "the dwarf";
				}
			}
			else
			{
				if (shop == Shop.Sandy)
				{
					return "Sandy";
				}
				if (shop == Shop.BookSeller)
				{
					return "BookSeller";
				}
				if (shop == Shop.Gus)
				{
					return "Gus";
				}
				if (shop == Shop.Mouse)
				{
					return "Mouse";
				}
				if (shop == Shop.TravellingCart)
				{
					return "Cart";
				}
				if (shop == Shop.Krobus)
				{
					return "Krobus";
				}
				if (shop == Shop.JojaMarket)
				{
					return EffectHelper.ModHelper.Translation.Get("Shop-Joja");
				}
				if (shop == Shop.AdventureGuild)
				{
					return EffectHelper.ModHelper.Translation.Get("Shop-Guild");
				}
			}
			return EffectHelper.ModHelper.Translation.Get("Shop-Someone");
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00002D0B File Offset: 0x00000F0B
		public static string GetNpcName(this Shop shop)
		{
			if (shop - Shop.JojaMarket <= 1)
			{
				return null;
			}
			return shop.ToString();
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00008D50 File Offset: 0x00006F50
		public static Shop GetShop(this ShopMenu shopMenu)
		{
			string text = shopMenu.ShopId.ToLower();
			if (text == null)
			{
				return Shop.None;
			}
			if (text == "hatmouse")
			{
				return Shop.Mouse;
			}
			if (text == "saloon")
			{
				return Shop.Gus;
			}
			if (text == "traveler")
			{
				return Shop.TravellingCart;
			}
			if (text == "bookseller")
			{
				return Shop.BookSeller;
			}
			if (text == "shadowshop")
			{
				return Shop.Krobus;
			}
			switch (text.Length)
			{
			case 4:
				if (!(text == "joja"))
				{
					return Shop.None;
				}
				return Shop.JojaMarket;
			case 5:
				if (text == "dwarf")
				{
					return Shop.Dwarf;
				}
				if (text == "sandy")
				{
					return Shop.Sandy;
				}
				return Shop.None;
			case 6:
			case 7:
			case 11:
				return Shop.None;
			case 8:
			{
				char c = text[0];
				if (c != 'f')
				{
					if (c != 's')
					{
						return Shop.None;
					}
					if (!(text == "seedshop"))
					{
						return Shop.None;
					}
					return Shop.Pierre;
				}
				else
				{
					if (!(text == "fishshop"))
					{
						return Shop.None;
					}
					return Shop.Willy;
				}
				break;
			}
			case 9:
				if (!(text == "carpenter"))
				{
					return Shop.None;
				}
				return Shop.Robin;
			case 10:
			{
				char c2 = text[0];
				if (c2 != 'a')
				{
					if (c2 != 'b')
					{
						return Shop.None;
					}
					if (!(text == "blacksmith"))
					{
						return Shop.None;
					}
				}
				else
				{
					if (!(text == "animalshop"))
					{
						return Shop.None;
					}
					return Shop.Marnie;
				}
				break;
			}
			case 12:
				if (!(text == "clintupgrade"))
				{
					return Shop.None;
				}
				break;
			case 13:
				if (!(text == "adventureshop"))
				{
					return Shop.None;
				}
				return Shop.AdventureGuild;
			default:
				return Shop.None;
			}
			return Shop.Clint;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00002D26 File Offset: 0x00000F26
		public static Skill GetCorrespondingSkill(this Shop atShop)
		{
			if (atShop <= Shop.Marnie)
			{
				if (atShop == Shop.Clint)
				{
					return Skill.Mining;
				}
				if (atShop == Shop.Willy)
				{
					return Skill.Fishing;
				}
				if (atShop == Shop.Marnie)
				{
					return Skill.Foraging;
				}
			}
			else
			{
				if (atShop == Shop.Pierre)
				{
					return Skill.Farming;
				}
				if (atShop == Shop.Dwarf)
				{
					return Skill.Combat;
				}
				if (atShop == Shop.AdventureGuild)
				{
					return Skill.Combat;
				}
			}
			return Skill.Farming;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00002D59 File Offset: 0x00000F59
		public static bool CanBeAccessedByPlayer(this Shop shop)
		{
			return true;
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00008EE8 File Offset: 0x000070E8
		public static bool IsFulfilled(this SellingCondition condition, Shop atShop)
		{
			if (condition == SellingCondition.None)
			{
				return true;
			}
			foreach (object obj in Enum.GetValues(typeof(SellingCondition)))
			{
				SellingCondition sellingCondition = (SellingCondition)obj;
				if (sellingCondition != SellingCondition.None && condition.HasFlag(sellingCondition) && !ShopExtensions.CheckSingleCondition(sellingCondition, atShop))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00008F70 File Offset: 0x00007170
		private static bool CheckSingleCondition(SellingCondition condition, Shop atShop)
		{
			if (condition <= SellingCondition.FriendshipHearts_2)
			{
				if (condition <= SellingCondition.SkillLevel_8)
				{
					switch (condition)
					{
					case SellingCondition.SkillLevel_2:
						return ShopExtensions.GetCorrespondingSkillLevel(atShop) >= 2;
					case SellingCondition.SkillLevel_4:
						return ShopExtensions.GetCorrespondingSkillLevel(atShop) >= 4;
					case SellingCondition.SkillLevel_2 | SellingCondition.SkillLevel_4:
						break;
					case SellingCondition.SkillLevel_6:
						return ShopExtensions.GetCorrespondingSkillLevel(atShop) >= 6;
					default:
						if (condition == SellingCondition.SkillLevel_8)
						{
							return ShopExtensions.GetCorrespondingSkillLevel(atShop) >= 8;
						}
						break;
					}
				}
				else
				{
					if (condition == SellingCondition.SkillLevel_10)
					{
						return ShopExtensions.GetCorrespondingSkillLevel(atShop) >= 10;
					}
					if (condition == SellingCondition.FriendshipHearts_2)
					{
						return ShopExtensions.GetCorrespondingFriendshipLevel(atShop) >= 2;
					}
				}
			}
			else if (condition <= SellingCondition.FriendshipHearts_6)
			{
				if (condition == SellingCondition.FriendshipHearts_4)
				{
					return ShopExtensions.GetCorrespondingFriendshipLevel(atShop) >= 4;
				}
				if (condition == SellingCondition.FriendshipHearts_6)
				{
					return ShopExtensions.GetCorrespondingFriendshipLevel(atShop) >= 6;
				}
			}
			else
			{
				if (condition == SellingCondition.FriendshipHearts_8)
				{
					return ShopExtensions.GetCorrespondingFriendshipLevel(atShop) >= 8;
				}
				if (condition == SellingCondition.FriendshipHearts_10)
				{
					return ShopExtensions.GetCorrespondingFriendshipLevel(atShop) >= 10;
				}
			}
			return false;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00002D5C File Offset: 0x00000F5C
		private static int GetCorrespondingSkillLevel(Shop atShop)
		{
			return atShop.GetCorrespondingSkill().GetCurrentLevel();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000905C File Offset: 0x0000725C
		private static int GetCorrespondingFriendshipLevel(Shop atShop)
		{
			string npcName = atShop.GetNpcName();
			if (string.IsNullOrEmpty(npcName))
			{
				return 0;
			}
			return Game1.player.getFriendshipHeartLevelForNPC(npcName);
		}
	}
}
