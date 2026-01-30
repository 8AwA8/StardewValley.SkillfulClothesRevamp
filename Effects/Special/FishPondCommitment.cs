using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008D RID: 141
	internal class FishPondCommitment : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600032A RID: 810 RVA: 0x00004452 File Offset: 0x00002652
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFishing, EffectHelper.ModHelper.Translation.Get("Spec-FPC"));
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000031B2 File Offset: 0x000013B2
		public FishPondCommitment() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000E4F8 File Offset: 0x0000C6F8
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;

			if (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				return;
			Buff buff = new Buff("Nature.1011108.FPC" + sourceItem.QualifiedItemId, EffectHelper.ModHelper.Translation.Get("Base-SCName"), EffectHelper.ModHelper.Translation.Get("Base-SCName"), Buff.ENDLESS, Game1.content.Load<Texture2D>("TileSheets\\BuffsIcons"), 1, null, new bool?(false), EffectHelper.ModHelper.Translation.Get("Spec-FPC"), null);
			Game1.player.applyBuff(buff);
			this.isApplied.Value = true;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000E548 File Offset: 0x0000C748
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			foreach (Item item in e.Added)
			{
				if (item != null && item.QualifiedItemId == "(O)812")
				{
					ColoredObject coloredObject = new ColoredObject("447",
						item.Stack * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes
							? 1
							: 2), TailoringMenu.GetDyeColor(item) ?? Color.Orange)
					{
						Name = "Efficiently Aged " + item.Name,
						preserve = {Value = new StardewValley.Object.PreserveType?(StardewValley.Object.PreserveType.AgedRoe)},
						preservedParentSheetIndex = { Value = ((StardewValley.Object)item).preservedParentSheetIndex.Value },
						Price = (int)((double)((float)item.salePrice(false)) * (double)((float)Game1.player.FishingLevel / 7f) * (double)Game1.player.difficultyModifier)
					};
					coloredObject.Quality = 2;
					Game1.player.removeItemFromInventory(item);
					Game1.player.addItemToInventory(coloredObject);
				}
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00004474 File Offset: 0x00002674
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			
			Game1.player.buffs.Remove("Nature.1011108.FPC" + sourceItem.QualifiedItemId);
			isApplied.Value = false;
		}
		
		// Token: 0x040002C5 RID: 709
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
