using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000097 RID: 151
	internal class LovingRancher : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000369 RID: 873 RVA: 0x0000484D File Offset: 0x00002A4D
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Animal_Cow, EffectHelper.ModHelper.Translation.Get("Spec-Rancher"));
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000F3A8 File Offset: 0x0000D5A8
		public LovingRancher() : base(NoEffectParameters.Default)
		{
			this.itemsOp = new List<string>
			{
				"(O)174",
				"(O)176",
				"(O)928",
				"(O)180",
				"(O)182",
				"(O)442",
				"(O)444",
				"(O)107",
				"(O)289",
				"(O)305",
				"(O)446",
				"(O)440",
				"(O)184",
				"(O)186",
				"(O)436",
				"(O)438"
			};
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000F4C0 File Offset: 0x0000D6C0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.xp.Value = Game1.player.experiencePoints[0];
			this.farmingBuff = 0.9f + (float)Game1.player.FarmingLevel / 120f;
			if (Game1.player.getProfessionForSkill(0, 5) == 0)
			{
				this.rancherBuff = 1.1f;
			}
			else
			{
				this.rancherBuff = 1f;
			}
			if (Game1.player.getProfessionForSkill(0, 10) == 2)
			{
				this.coopBuff = 1.2f;
			}
			else
			{
				this.coopBuff = 1f;
			}
			if (Game1.player.getProfessionForSkill(0, 10) == 3)
			{
				this.sheepBuff = 1.2f;
			}
			else
			{
				this.sheepBuff = 1f;
			}
			this.balanceBuff = (EffectHelper.Config.LessImpactfulClothes ? EffectHelper.Config.TypicalClothesMultiple : 1f) * 0.9f * EffectHelper.Config.LovingRancherRate;
			if (!EffectHelper.Config.DisableWhenActiveAlerts)
			{
				Game1.addHUDMessage(new CustomHUDMessage("Current Buff: " + MathF.Round(this.rancherBuff * this.farmingBuff * MathF.Max(this.sheepBuff, this.coopBuff), 4), null, Color.Gold, TimeSpan.FromSeconds(2.0)));
			}
			foreach (FarmAnimal farmAnimal in Game1.getFarm().getAllFarmAnimals())
			{
				if ((double)farmAnimal.friendshipTowardFarmer.Value >= 950.0)
				{
					farmAnimal.produceQuality.Value = 4;
				}
			}
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.XpUpdate;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.XpUpdate;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			foreach (Item item in e.Added)
			{
				if (Game1.player.FarmingLevel > 13 && item != null && this.itemsOp.Contains(item.QualifiedItemId))
				{
					item.Quality = 4;
				}
			}
			int num = Game1.player.experiencePoints[0];
			if (this.xp.Value < num)
			{
				this.xp.Value = Game1.player.experiencePoints[0];
				double num2 = Game1.random.NextDouble();
				if (num2 <= 0.14 * (double)this.farmingBuff * (double)this.balanceBuff * (double)this.rancherBuff)
				{
					List<Item> list = new List<Item>();
					Item item2 = ItemRegistry.Create("802", 1, 0, false);
					if (e.QuantityChanged.Count<ItemStackSizeChange>() > 0)
					{
						item2 = e.QuantityChanged.ElementAt(0).Item;
					}
					List<Item> list2 = e.Added.ToList<Item>();
					list2.Add(item2);
					double num3 = (double)this.farmingBuff * (double)this.balanceBuff * (double)this.rancherBuff * (double)this.sheepBuff;
					double num4 = (double)this.farmingBuff * (double)this.balanceBuff * (double)this.rancherBuff * (double)this.coopBuff;
					foreach (Item item3 in list2)
					{
						if (item3.ItemId == "184" || item3.ItemId == "186")
						{
							list.Add(ItemRegistry.Create("186", 1, 4, true));
							if (num2 <= 0.008 * num3)
							{
								if (Game1.random.NextDouble() < 0.7)
								{
									list.Add(ItemRegistry.Create("72", 3, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.012 * num3)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("GoldenAnimalCracker", 1, 0, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("417", 1, 4, true));
								}
							}
							else if (num2 <= 0.06 * num3)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("454", 2, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("268", 3, 4, true));
								}
							}
							else if (num2 <= 0.09 * num3)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("424", 1, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("197", 3, 0, true));
								}
							}
						}
						else if (item3.ItemId == "436" || item3.ItemId == "438")
						{
							list.Add(ItemRegistry.Create("438", 1, 4, true));
							if (num2 <= 0.01 * num3)
							{
								if (Game1.random.NextDouble() < 0.65)
								{
									list.Add(ItemRegistry.Create("72", 3, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.017 * num3)
							{
								if (Game1.random.NextDouble() < 0.7)
								{
									list.Add(ItemRegistry.Create("BlueGrassStarter", 5, 0, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("GoldenAnimalCracker", 1, 0, true));
								}
							}
							else if (num2 <= 0.08 * num3)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("178", 100, 0, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("297", 50, 0, true));
								}
							}
							else if (num2 <= 0.1 * num3)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("426", 1, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("426", 3, 0, true));
								}
							}
						}
						else if (Game1.player.ActiveItem != null && Game1.player.ActiveItem.ItemId == "(T)Shears" && item3.ItemId == "440")
						{
							list.Add(ItemRegistry.Create("440", 1, 4, true));
							if (num2 <= 0.01 * num3)
							{
								if (Game1.random.NextDouble() < 0.65)
								{
									list.Add(ItemRegistry.Create("72", 3, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.015 * num3)
							{
								if (Game1.random.NextDouble() < 0.7)
								{
									list.Add(ItemRegistry.Create("BlueGrassStarter", 5, 0, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("GoldenAnimalCracker", 1, 0, true));
								}
							}
							else if (num2 <= 0.07 * num3)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("428", 2, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("428", 5, 0, true));
								}
							}
							else if (num2 <= 0.1 * num3)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("428", 1, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("428", 3, 0, true));
								}
							}
						}
						else if (item3.ItemId == "174" || item3.ItemId == "176" || item3.ItemId == "180" || item3.ItemId == "182")
						{
							list.Add(ItemRegistry.Create("174", 1, 4, true));
							if (num2 <= 0.007 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("289", 1, 3, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.025 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("306", 2, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("306", 3, 4, true));
								}
							}
							if (num2 <= 0.06 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("305", 2, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("195", 4, 0, true));
								}
							}
							else if (num2 <= 0.075 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("182", 1, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("194", 4, 0, true));
								}
							}
						}
						else if (item3.ItemId == "305")
						{
							list.Add(ItemRegistry.Create("305", 1, 4, true));
							if (num2 <= 0.025 * num4)
							{
								if (Game1.random.NextDouble() < 0.7)
								{
									list.Add(ItemRegistry.Create("337", 3, 0, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.045 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("308", 2, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("565", 10, 4, true));
								}
							}
							else if (num2 <= 0.065 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("308", 3, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("795", 5, 4, true));
								}
							}
							else if (num2 <= 0.09 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("308", 2, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("769", 45, 0, true));
								}
							}
						}
						else if (item3.ItemId == "442" || item3.ItemId == "444")
						{
							list.Add(ItemRegistry.Create("442", 1, 4, true));
							if (num2 <= 0.012 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("289", 1, 3, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.035 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("373", 1, 0, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("StardropTea", 1, 0, true));
								}
							}
							else if (num2 <= 0.065 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("307", 2, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("307", 5, 0, true));
								}
							}
							else if (num2 <= 0.095 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("444", 1, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("444", 4, 0, true));
								}
							}
						}
						else if (item3.ItemId == "107")
						{
							list.Add(ItemRegistry.Create("807", 1, 2, true));
							if (num2 <= 0.04 * num4)
							{
								if (Game1.random.NextDouble() < 0.7)
								{
									list.Add(ItemRegistry.Create("807", 5, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.06 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("807", 3, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("807", 4, 4, true));
								}
							}
							else if (num2 <= 0.08 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("807", 2, 3, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("807", 3, 3, true));
								}
							}
							else if (num2 <= 0.09 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("807", 1, 2, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("807", 2, 2, true));
								}
							}
						}
						else if (item3.ItemId == "289")
						{
							list.Add(ItemRegistry.Create("289", 1, 4, true));
							if (num2 <= 0.04 * num4 * (double)this.sheepBuff)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("GoldenAnimalCracker", 2, 0, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("Stardroptea", 3, 0, true));
								}
							}
							else if (num2 <= 0.07 * num4 * (double)this.sheepBuff)
							{
								list.Add(ItemRegistry.Create("GoldenAnimalCracker", 1, 0, true));
							}
							else if (num2 <= 0.08 * num4 * (double)this.sheepBuff)
							{
								if (Game1.random.NextDouble() < 0.75)
								{
									list.Add(ItemRegistry.Create("306", 15, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 4, true));
								}
							}
							else if (num2 <= 0.095 * num4 * (double)this.sheepBuff)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("306", 15, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("StardropTea", 1, 0, true));
								}
							}
						}
						else if (item3.ItemId == "446" || (item3.ItemId == "440" && (Game1.player.ActiveItem == null || Game1.player.ActiveItem.ItemId != "(T)Shears")))
						{
							list.Add(ItemRegistry.Create("440", 1, 4, true));
							if (num2 <= 0.02 * num4)
							{
								if (Game1.random.NextDouble() < 0.7)
								{
									list.Add(ItemRegistry.Create("72", 3, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("74", 1, 0, true));
								}
							}
							else if (num2 <= 0.04 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("446", 1, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("446", 2, 0, true));
								}
							}
							else if (num2 <= 0.065 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("428", 2, 2, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("428", 3, 0, true));
								}
							}
							else if (num2 <= 0.95 * num4)
							{
								if (Game1.random.NextDouble() < 0.5)
								{
									list.Add(ItemRegistry.Create("440", 1, 4, true));
								}
								else
								{
									list.Add(ItemRegistry.Create("440", 3, 0, true));
								}
							}
						}
					}
					if (list.Count != 0)
					{
						Game1.activeClickableMenu = new ItemGrabMenu(list, this).setEssential(true, false);
						if (!EffectHelper.Config.DisableEffectSFX)
						{
							Game1.player.playNearbySoundLocal("discoverMineral", null, 0);
						}
						Game1.player.completelyStopAnimatingOrDoingAction();
					}
				}
			}
			this.xp.Value = num;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00010770 File Offset: 0x0000E970
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.XpUpdate;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000486F File Offset: 0x00002A6F
		private void XpUpdate(object sender, TimeChangedEventArgs eventArgs)
		{
			this.xp.Value = Game1.player.experiencePoints[0];
		}

		// Token: 0x040002AF RID: 687
		private List<string> itemsOp;

		// Token: 0x040002B0 RID: 688
		private float farmingBuff = 1f;

		// Token: 0x040002B1 RID: 689
		private float coopBuff = 1f;

		// Token: 0x040002B2 RID: 690
		private float sheepBuff = 1f;

		// Token: 0x040002B3 RID: 691
		private float rancherBuff = 1f;

		// Token: 0x040002B4 RID: 692
		private float balanceBuff = 1f;

		// Token: 0x040002B5 RID: 693
		private PerScreen<int> xp = new PerScreen<int>();
	}
}
