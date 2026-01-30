using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Menus;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000052 RID: 82
	internal class ShopDiscount : SingleEffect<ShopDiscountParameters>
	{
		// Token: 0x060001B7 RID: 439 RVA: 0x000034BF File Offset: 0x000016BF
		public ShopDiscount(ShopDiscountParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000034D3 File Offset: 0x000016D3
		public ShopDiscount(Shop shop, double discount) : base(ShopDiscountParameters.With(shop, discount))
		{
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000B1A0 File Offset: 0x000093A0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
			EffectHelper.ModHelper.Events.Display.MenuChanged += this.Display_MenuChanged;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000B1F0 File Offset: 0x000093F0
		private void Display_MenuChanged(object sender, MenuChangedEventArgs e)
		{
			ShopMenu shopMenu = e.NewMenu as ShopMenu;
			if (shopMenu != null && this.oldMenu.Value != null)
			{
				foreach (ISalable key in this.oldMenu.Value.itemPriceAndStock.Keys.ToList<ISalable>())
				{
					if (shopMenu.itemPriceAndStock.ContainsKey(key) && shopMenu.itemPriceAndStock[key].Price == this.oldMenu.Value.itemPriceAndStock[key].Price)
					{
						return;
					}
				}
			}
			if (shopMenu != null && shopMenu.GetShop() == base.Parameters.Shop)
			{
				foreach (ISalable key2 in shopMenu.itemPriceAndStock.Keys.ToList<ISalable>())
				{
					shopMenu.itemPriceAndStock[key2].Price = (int)Math.Max(0.0, (double)shopMenu.itemPriceAndStock[key2].Price * (1.0 - base.Parameters.Discount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0)));
				}
				this.oldMenu.Value = shopMenu;
				CustomOverlays overlays = EffectHelper.Overlays;
				SpriteFont dialogueFont = Game1.dialogueFont;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 1);
				defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Shop-Popup"));
				defaultInterpolatedStringHandler.AppendFormatted<double>(base.Parameters.Discount * 100.0 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0), "0.#");
				defaultInterpolatedStringHandler.AppendLiteral("%)");
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					overlays.AddSparklingText(new SparklingText(dialogueFont, defaultInterpolatedStringHandler.ToStringAndClear(), Color.LimeGreen, Color.Azure, false, 0.1, 2500, -1, 500, 1f), new Vector2(64f, (float)(Game1.uiViewport.Height - 64)));
				}
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000034ED File Offset: 0x000016ED
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000B490 File Offset: 0x00009690
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			EffectIcon icon = EffectIcon.Red;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 2);
			defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Spec-ShopDisc1"));
			defaultInterpolatedStringHandler.AppendFormatted(base.Parameters.Shop.GetShopReferral());
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted<double>(base.Parameters.Discount * 100.0 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? ((double)EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1.0), "0.#");
			defaultInterpolatedStringHandler.AppendLiteral("%)");
			return new EffectDescriptionLine(icon, defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x04000236 RID: 566
		public PerScreen<ShopMenu> oldMenu = new PerScreen<ShopMenu>();
	}
}
