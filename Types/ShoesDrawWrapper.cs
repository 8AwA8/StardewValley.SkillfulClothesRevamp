using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Effects;
using StardewValley.Objects;

namespace SkillfulClothes.Types
{
	// Token: 0x020000C0 RID: 192
	internal class ShoesDrawWrapper : Boots
	{
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x000053B4 File Offset: 0x000035B4
		// (set) Token: 0x0600046C RID: 1132 RVA: 0x000053BC File Offset: 0x000035BC
		public IEffect Effect { get; private set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600046D RID: 1133 RVA: 0x000053C5 File Offset: 0x000035C5
		// (set) Token: 0x0600046E RID: 1134 RVA: 0x000053CD File Offset: 0x000035CD
		public Boots WrappedItem { get; private set; }

		// Token: 0x0600046F RID: 1135 RVA: 0x000053D6 File Offset: 0x000035D6
		public void Assign(Boots hat, IEffect effect)
		{
			if (this.WrappedItem == hat)
			{
				return;
			}
			this.Effect = effect;
			this.GetOneCopyFrom(hat);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x000053F0 File Offset: 0x000035F0
		public override void drawTooltip(SpriteBatch spriteBatch, ref int x, ref int y, SpriteFont font, float alpha, StringBuilder overrideText)
		{
			base.drawTooltip(spriteBatch, ref x, ref y, font, alpha, overrideText);
			if (this.Effect != null)
			{
				EffectHelper.drawTooltip(this.Effect, spriteBatch, ref x, ref y, font, alpha, overrideText);
			}
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00016884 File Offset: 0x00014A84
		public override Point getExtraSpaceNeededForTooltipSpecialIcons(SpriteFont font, int minWidth, int horizontalBuffer, int startingHeight, StringBuilder descriptionText, string boldTitleText, int moneyAmountToDisplayAtBottom)
		{
			Point extraSpaceNeededForTooltipSpecialIcons = base.getExtraSpaceNeededForTooltipSpecialIcons(font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
			if (this.Effect != null)
			{
				Point extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix = EffectHelper.getExtraSpaceNeededForTooltipSpecialIconsBootsOnlyFix(this.Effect, font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
				if (this.immunityBonus.Value == 0)
				{
					extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.Y -= Math.Max((int)font.MeasureString("TT").Y, 36);
				}
				extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.X = Math.Max(extraSpaceNeededForTooltipSpecialIcons.X, extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.X);
				extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.Y = Math.Max(extraSpaceNeededForTooltipSpecialIcons.Y, extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix.Y);
				return extraSpaceNeededForTooltipSpecialIconsBootsOnlyFix;
			}
			return extraSpaceNeededForTooltipSpecialIcons;
		}
	}
}
