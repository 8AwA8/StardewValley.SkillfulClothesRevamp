using System;
using System.Collections.Generic;
using SkillfulClothes.Configuration;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

using Object = StardewValley.Object;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000092 RID: 146
	internal class Recycler : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000348 RID: 840 RVA: 0x0000460D File Offset: 0x0000280D
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Popularity, EffectHelper.ModHelper.Translation.Get("Spec-Recyler"));
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000031B2 File Offset: 0x000013B2
		public Recycler() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000EDCC File Offset: 0x0000CFCC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.InventoryChanged += this.GameLoop_UpdateTicking;
			
			if (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				return;
			Buff buff = new Buff("Nature.1011108.REC" + sourceItem.QualifiedItemId, EffectHelper.ModHelper.Translation.Get("Base-SCName"), EffectHelper.ModHelper.Translation.Get("Base-SCName"), Buff.ENDLESS, Game1.content.Load<Texture2D>("TileSheets\\BuffsIcons"), 22, null, new bool?(false), EffectHelper.ModHelper.Translation.Get("Spec-Recyler"), null);
			Game1.player.applyBuff(buff);
			this.isApplied.Value = true;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000EE1C File Offset: 0x0000D01C
		private void GameLoop_UpdateTicking(object sender, InventoryChangedEventArgs e)
		{
			foreach (Item item in e.Added)
			{
				if (item != null && item.Category == -20)
				{
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
					{
						Game1.player.playNearbySoundLocal("moneyDial", null, 0);
					}
					Game1.player.Money += (int)((float)((20 + 6 * Game1.player.fishingLevel.Value) * item.Stack) * Game1.player.difficultyModifier * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f));
					Object @object = new Object("DeluxeBait", item.Stack, false, -1, 0);
					Game1.player.removeItemFromInventory(item);
					Game1.player.addItemToInventory(@object);
				}
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000462E File Offset: 0x0000282E
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Player.InventoryChanged -= this.GameLoop_UpdateTicking;
			
			Game1.player.buffs.Remove("Nature.1011108.REC" + sourceItem.QualifiedItemId);
			isApplied.Value = false;
		}
		
		// Token: 0x040002C5 RID: 709
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
