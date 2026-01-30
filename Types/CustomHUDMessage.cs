using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Extensions;

namespace SkillfulClothes.Types
{
	// Token: 0x0200001A RID: 26
	internal class CustomHUDMessage : HUDMessage
	{
		// Token: 0x060000D2 RID: 210 RVA: 0x00002A28 File Offset: 0x00000C28
		public CustomHUDMessage(string message, Item forItem, Color itemColor, TimeSpan displayDuration) : base(message)
		{
			this.drawForItem = forItem;
			this.itemColor = itemColor;
			this.timeLeft = (float)displayDuration.TotalMilliseconds;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00007234 File Offset: 0x00005434
		public override void draw(SpriteBatch b, int i, ref int heightUsed)
		{
			base.draw(b, i, ref heightUsed);
			Rectangle tsarea = FrameworkExtensions.GetTitleSafeArea(Game1.graphics.GraphicsDevice.Viewport);
			Vector2 itemBoxPosition = new Vector2((float)(tsarea.Left + 16), (float)(tsarea.Bottom - (i + 1f) * 64 * 7f / 4f - 64f));
			if (Game1.isOutdoorMapSmallerThanViewport())
			{
				itemBoxPosition.X = (float)Math.Max(tsarea.Left + 16, -Game1.uiViewport.X + 16);
			}
			if (Game1.uiViewport.Width < 1400)
			{
				itemBoxPosition.Y -= 48f;
			}
			itemBoxPosition.X += 16f;
			itemBoxPosition.Y += 16f;
			Item item = this.drawForItem;
			if (item == null)
			{
				return;
			}
			item.drawInMenu(b, itemBoxPosition, 1f + Math.Max(0f, (this.timeLeft - 3000f) / 900f), this.transparency, 1f, 0, this.itemColor, true);
		}

		// Token: 0x0400003F RID: 63
		private Color itemColor;

		// Token: 0x04000040 RID: 64
		private Item drawForItem;
	}
}
