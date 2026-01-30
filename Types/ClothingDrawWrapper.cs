using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Effects;
using StardewValley.Objects;

namespace SkillfulClothes.Types
{
	// Token: 0x02000018 RID: 24
	internal class ClothingDrawWrapper : Clothing
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000CA RID: 202 RVA: 0x000029A1 File Offset: 0x00000BA1
		// (set) Token: 0x060000CB RID: 203 RVA: 0x000029A9 File Offset: 0x00000BA9
		public IEffect Effect { get; private set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000029B2 File Offset: 0x00000BB2
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000029BA File Offset: 0x00000BBA
		public Clothing WrappedItem { get; private set; }

		// Token: 0x060000CE RID: 206 RVA: 0x000029C3 File Offset: 0x00000BC3
		public void Assign(Clothing clothing, IEffect effect)
		{
			if (this.WrappedItem == clothing)
			{
				return;
			}
			this.Effect = effect;
			this.GetOneCopyFrom(clothing);
			this.clothesColor.Value = clothing.clothesColor.Value;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000029F3 File Offset: 0x00000BF3
		public override void drawTooltip(SpriteBatch spriteBatch, ref int x, ref int y, SpriteFont font, float alpha, StringBuilder overrideText)
		{
			base.drawTooltip(spriteBatch, ref x, ref y, font, alpha, overrideText);
			if (this.Effect != null)
			{
				EffectHelper.drawTooltip(this.Effect, spriteBatch, ref x, ref y, font, alpha, overrideText);
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000071C0 File Offset: 0x000053C0
		public override Point getExtraSpaceNeededForTooltipSpecialIcons(SpriteFont font, int minWidth, int horizontalBuffer, int startingHeight, StringBuilder descriptionText, string boldTitleText, int moneyAmountToDisplayAtBottom)
		{
			Point p = base.getExtraSpaceNeededForTooltipSpecialIcons(font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
			if (this.Effect != null)
			{
				Point newP = EffectHelper.getExtraSpaceNeededForTooltipSpecialIcons(this.Effect, font, minWidth, horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
				newP.X = Math.Max(p.X, newP.X);
				newP.Y = Math.Max(p.Y, newP.Y);
				return newP;
			}
			return p;
		}
	}
}
