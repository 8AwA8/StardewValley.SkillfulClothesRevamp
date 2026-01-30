using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Menus;

namespace SkillfulClothes.Patches
{
	// Token: 0x020000B0 RID: 176
	public class WardrobePage : IClickableMenu
	{
		// Token: 0x06000413 RID: 1043 RVA: 0x00014C34 File Offset: 0x00012E34
		public override void draw(SpriteBatch b)
		{
			b.Draw(Game1.fadeToBlackRect, Game1.graphics.GraphicsDevice.Viewport.Bounds, Color.Black * 0.75f);
			SpriteText.drawStringWithScrollCenteredAt(b, this.title, this.xPositionOnScreen + this.width / 2, this.yPositionOnScreen - 64, "", 1f, null, 0, 0.88f, false);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 373, 18, 18), this.xPositionOnScreen, this.yPositionOnScreen, this.width, this.height, Color.White, 4f, true, -1f);
			for (int i = 1; i < this.count; i++)
			{
				base.drawHorizontalPartition(b, this.yPositionOnScreen - 30 + this.height / this.count * i, false, -1, -1, -1);
			}
			this.populateClickableComponentList();
			this.allClickableComponents.Clear();
			for (int j = 0; j < this.count; j++)
			{
				List<Item> list = new List<Item>();
				string text = "A";
				this.items.TryGetValue(j + 1, out list);
				this.names.TryGetValue(j + 1, out text);
				SpriteText.drawStringWithScrollCenteredAt(b, text, this.xPositionOnScreen + 40 + this.width / 5, this.yPositionOnScreen + 23 + ((j == 0) ? 7 : 0) + this.height / this.count * j, "", 1f, null, 0, 0.88f, false);
				new ClickableTextureComponent("Edit" + (j + 1).ToString(), new Rectangle(this.xPositionOnScreen + 5 + (int)((float)this.width * 6.25f / 8f), this.yPositionOnScreen + 24 + this.height / this.count * j, this.width / 14, this.height / 8), "", "EditButton", Game1.mouseCursors, new Rectangle(366, 373, 18, 18), 4f, true).draw(b);
				ClickableComponent item = new ClickableComponent(new Rectangle(new Point(this.xPositionOnScreen + 5 + (int)((float)this.width * 6.25f / 8f), this.yPositionOnScreen + 12 + j * 4 + this.height / this.count * j), new Point(this.width / 14, this.height / 10)), "Edit" + (j + 1).ToString(), "Edit Set");
				new ClickableTextureComponent("Select" + (j + 1).ToString(), new Rectangle(new Point(this.xPositionOnScreen + 5 + (int)((float)this.width * 7f / 8f), this.yPositionOnScreen + 20 + this.height / this.count * j), new Point(this.width / 14, this.height / 8)), "", "", Game1.mouseCursors, new Rectangle(174, 378, 18, 18), 4f, true).draw(b);
				ClickableComponent item2 = new ClickableComponent(new Rectangle(new Point(this.xPositionOnScreen + 15 + (int)((float)this.width * 7f / 8f), this.yPositionOnScreen + 12 + j * 4 + this.height / this.count * j), new Point(this.width / 14, this.height / 10)), "Select" + (j + 1).ToString(), "Select Set");
				new ClickableTextureComponent("testTexture", new Rectangle(new Point(this.xPositionOnScreen + (int)((float)this.width * 3.5f / 8f), this.yPositionOnScreen + 16 + this.height / this.count * j), new Point(this.width, this.height / 8)), "", "", Game1.mouseCursors, new Rectangle(192, 386, 18, 18), 4f, true).draw(b);
				if (list[0] != null && list[0].TypeDefinitionId == "(H)")
				{
					list[0].drawInMenu(b, new Vector2((float)(this.xPositionOnScreen + 9 + (int)((float)this.width * 3.5f / 8f)), (float)(this.yPositionOnScreen + 29 + this.height / this.count * j)), 0.9f, 1f, 5f, 0, Color.White, true);
				}
				new ClickableTextureComponent("testTexture", new Rectangle(new Point(this.xPositionOnScreen + (int)((float)this.width * 4.5f / 8f), this.yPositionOnScreen + 16 + this.height / this.count * j), new Point(this.width, this.height / 8)), "", "", Game1.mouseCursors, new Rectangle(192, 386, 18, 18), 4f, true).draw(b);
				if (list[1] != null && list[1].TypeDefinitionId == "(S)")
				{
					list[1].drawInMenu(b, new Vector2((float)(this.xPositionOnScreen + 9 + (int)((float)this.width * 4.5f / 8f)), (float)(this.yPositionOnScreen + 25 + this.height / this.count * j)), 0.95f, 1f, 5f, 0, Color.White, true);
				}
				new ClickableTextureComponent("testTexture", new Rectangle(new Point(this.xPositionOnScreen + (int)((float)this.width * 5.5f / 8f), this.yPositionOnScreen + 16 + this.height / this.count * j), new Point(this.width, this.height / 8)), "", "", Game1.mouseCursors, new Rectangle(192, 386, 18, 18), 4f, true).draw(b);
				if (list[2] != null && list[2].TypeDefinitionId == "(P)")
				{
					list[2].drawInMenu(b, new Vector2((float)(this.xPositionOnScreen + 9 + (int)((float)this.width * 5.5f / 8f)), (float)(this.yPositionOnScreen + 29 + this.height / this.count * j)), 0.9f, 1f, 5f, 0, Color.White, true);
				}
				this.allClickableComponents.Add(item);
				this.allClickableComponents.Add(item2);
			}
			Game1.mouseCursorTransparency = 1f;
			base.drawMouse(b, false, -1);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00015360 File Offset: 0x00013560
		public WardrobePage(Dictionary<int, List<Item>> newItems, Dictionary<int, string> newNames)
		{
			this.items = newItems;
			this.names = newNames;
			this.title = EffectHelper.ModHelper.Translation.Get("Menuing16");
			this.width = 960;
			this.height = 640;
			Vector2 topLeftPositionForCenteringOnScreen = Utility.getTopLeftPositionForCenteringOnScreen(this.width, this.height, 0, 0);
			this.xPositionOnScreen = (int)topLeftPositionForCenteringOnScreen.X;
			this.yPositionOnScreen = (int)topLeftPositionForCenteringOnScreen.Y;
		}

		// Token: 0x040002E3 RID: 739
		private string title;

		// Token: 0x040002E4 RID: 740
		private int count = 6;

		// Token: 0x040002E5 RID: 741
		private Dictionary<int, List<Item>> items = new Dictionary<int, List<Item>>();

		// Token: 0x040002E6 RID: 742
		private Dictionary<int, string> names = new Dictionary<int, string>();

		// Token: 0x040002E7 RID: 743
		private List<ClickableTextureComponent> clickableTextures = new List<ClickableTextureComponent>();
	}
}
