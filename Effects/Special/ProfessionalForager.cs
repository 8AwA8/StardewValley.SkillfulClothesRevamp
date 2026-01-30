using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000091 RID: 145
	internal class ProfessionalForager : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000343 RID: 835 RVA: 0x000045B1 File Offset: 0x000027B1
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillForaging, EffectHelper.ModHelper.Translation.Get("Spec-ProfFor"));
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000045D3 File Offset: 0x000027D3
		public ProfessionalForager() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000EBC8 File Offset: 0x0000CDC8
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.lastxp.Value = Game1.player.experiencePoints[2];
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
			
			if (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				return;
			Buff buff = new Buff("Nature.1011108.FOR" + sourceItem.QualifiedItemId, EffectHelper.ModHelper.Translation.Get("Base-SCName"), EffectHelper.ModHelper.Translation.Get("Base-SCName"), Buff.ENDLESS, Game1.content.Load<Texture2D>("TileSheets\\BuffsIcons"), 5, null, new bool?(false), EffectHelper.ModHelper.Translation.Get("Spec-ProfFor"), null);
			Game1.player.applyBuff(buff);
			this.isApplied.Value = true;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000EC30 File Offset: 0x0000CE30
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			int num = Game1.player.experiencePoints[2];
			if (this.lastxp.Value < num)
			{
				this.lastxp.Value = num;
				using (IEnumerator<Item> enumerator = e.Added.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Item item = enumerator.Current;
						if (item != null && ((item.Category > -82 && item.Category < -78 && item.ItemId != "430") || item.ItemId == "259"))
						{
							if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
							{
								Game1.player.playNearbySoundLocal("moneyDial", null, 0);
							}
							Game1.player.Money += (int)((double)((float)item.salePrice(false)) * (double)(1f + (float)Game1.player.ForagingLevel / 10f) * (double)((float)item.Stack) * (double)Game1.MasterPlayer.difficultyModifier * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0) * (double)((float)(1.0 + (double)item.Quality * 0.25)));
							Game1.player.removeItemFromInventory(item);
						}
					}
					return;
				}
			}
			this.lastxp.Value = num;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x000045EB File Offset: 0x000027EB
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			
			Game1.player.buffs.Remove("Nature.1011108.FOR" + sourceItem.QualifiedItemId);
			isApplied.Value = false;
		}
		
		// Token: 0x040002C5 RID: 709
		private PerScreen<bool> isApplied = new PerScreen<bool>();

		// Token: 0x040002A3 RID: 675
		private PerScreen<int> lastxp = new PerScreen<int>();
	}
}
