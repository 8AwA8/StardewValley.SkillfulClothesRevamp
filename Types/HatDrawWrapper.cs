using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Effects;
using StardewValley;
using HatS = StardewValley.Objects.Hat;

namespace SkillfulClothes.Types
{
	// Token: 0x02000023 RID: 35
	internal class HatDrawWrapper : HatS
	{
	// Token: 0x17000020 RID: 32
	// (get) Token: 0x060000EF RID: 239 RVA: 0x00002BB9 File Offset: 0x00000DB9
	// (set) Token: 0x060000F0 RID: 240 RVA: 0x00002BC1 File Offset: 0x00000DC1
	public IEffect Effect { get; private set; }

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060000F1 RID: 241 RVA: 0x00002BCA File Offset: 0x00000DCA
	// (set) Token: 0x060000F2 RID: 242 RVA: 0x00002BD2 File Offset: 0x00000DD2
	public HatS WrappedItem { get; private set; }

	// Token: 0x060000F3 RID: 243 RVA: 0x00002BDB File Offset: 0x00000DDB
	public void Assign(HatS hat, IEffect effect)
	{
		if (this.WrappedItem == hat)
		{
			return;
		}

		this.Effect = effect;
		this.GetOneCopyFrom(hat);
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00002BF5 File Offset: 0x00000DF5
	public override void drawTooltip(SpriteBatch spriteBatch, ref int x, ref int y, SpriteFont font, float alpha,
		StringBuilder overrideText)
	{
		base.drawTooltip(spriteBatch, ref x, ref y, font, alpha, overrideText);
		if (this.Effect != null)
		{
			EffectHelper.drawTooltip(this.Effect, spriteBatch, ref x, ref y, font, alpha, overrideText);
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x000078A0 File Offset: 0x00005AA0
	public override Point getExtraSpaceNeededForTooltipSpecialIcons(SpriteFont font, int minWidth, int horizontalBuffer,
		int startingHeight, StringBuilder descriptionText, string boldTitleText, int moneyAmountToDisplayAtBottom)
	{
		Point p = base.getExtraSpaceNeededForTooltipSpecialIcons(font, minWidth, horizontalBuffer, startingHeight,
			descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
		if (this.Effect != null)
		{
			Point newP = EffectHelper.getExtraSpaceNeededForTooltipSpecialIcons(this.Effect, font, minWidth,
				horizontalBuffer, startingHeight, descriptionText, boldTitleText, moneyAmountToDisplayAtBottom);
			newP.X = Math.Max(p.X, newP.X);
			newP.Y = Math.Max(p.Y, newP.Y);
			return newP;
		}

		return p;
	}
	}
}
