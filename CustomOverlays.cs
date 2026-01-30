using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.BellsAndWhistles;

namespace SkillfulClothes
{
	// Token: 0x02000006 RID: 6
	internal class CustomOverlays
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00005880 File Offset: 0x00003A80
		public CustomOverlays(IModHelper modHelper)
		{
			modHelper.Events.Display.RenderedActiveMenu += this.Display_RenderedActiveMenu;
			modHelper.Events.GameLoop.UpdateTicked += this.GameLoop_UpdateTicked;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000208E File Offset: 0x0000028E
		public void AddSparklingText(SparklingText text, Vector2 position)
		{
			this.sparklingTexts.Add(Tuple.Create<SparklingText, Vector2>(text, position));
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000058D8 File Offset: 0x00003AD8
		private void GameLoop_UpdateTicked(object sender, UpdateTickedEventArgs e)
		{
			for (int i = this.sparklingTexts.Count - 1; i >= 0; i--)
			{
				if (this.sparklingTexts[i].Item1.update(Game1.currentGameTime))
				{
					this.sparklingTexts.RemoveAt(i);
				}
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00005928 File Offset: 0x00003B28
		private void Display_RenderedActiveMenu(object sender, RenderedActiveMenuEventArgs e)
		{
			foreach (Tuple<SparklingText, Vector2> text in this.sparklingTexts)
			{
				text.Item1.draw(e.SpriteBatch, text.Item2);
			}
		}

		// Token: 0x04000007 RID: 7
		private List<Tuple<SparklingText, Vector2>> sparklingTexts = new List<Tuple<SparklingText, Vector2>>();
	}
}
