using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects;
using StardewModdingAPI;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x02000007 RID: 7
	internal static class EffectHelper
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000020A2 File Offset: 0x000002A2
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000020A9 File Offset: 0x000002A9
		public static IModHelper ModHelper { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000020B1 File Offset: 0x000002B1
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000020B8 File Offset: 0x000002B8
		public static SkillfulClothesConfig Config { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000020C0 File Offset: 0x000002C0
		// (set) Token: 0x06000015 RID: 21 RVA: 0x000020C7 File Offset: 0x000002C7
		public static CustomOverlays Overlays { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000020CF File Offset: 0x000002CF
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000020D6 File Offset: 0x000002D6
		public static ClothingObserver ClothingObserver { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000020DE File Offset: 0x000002DE
		public static Random Random { get; } = new Random();

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000020E5 File Offset: 0x000002E5
		public static EffectHelperEvents Events { get; } = new EffectHelperEvents();

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000020EC File Offset: 0x000002EC
		public static ModTextures Textures { get; } = new ModTextures();

		// Token: 0x0600001B RID: 27 RVA: 0x000020F3 File Offset: 0x000002F3
		public static void Init(IModHelper modHelper, SkillfulClothesConfig config)
		{
			EffectHelper.ModHelper = modHelper;
			EffectHelper.Config = config;
			EffectHelper.Textures.Init();
			EffectHelper.ClothingObserver = new ClothingObserver();
			EffectHelper.Overlays = new CustomOverlays(modHelper);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000598C File Offset: 0x00003B8C
		public static string GetEffectId(IEffect effect)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted(effect.GetType().Name);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted<int>(effect.GetHashCode());
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000059D4 File Offset: 0x00003BD4
		public static void drawTooltip(IEffect effect, SpriteBatch spriteBatch, ref int x, ref int y, SpriteFont font, float alpha, StringBuilder overrideText)
		{
			y -= 6;
			foreach (EffectDescriptionLine effectDescriptionLine in effect.EffectDescription)
			{
				effectDescriptionLine.Icon.Draw(spriteBatch, new Vector2((float)(x + 16 + 4), (float)(y + 16 + 4 + 2)));
				Utility.drawTextWithShadow(spriteBatch, effectDescriptionLine.Text, font, new Vector2((float)(x + 16 + 52 - 10), (float)(y + 16 + 7)), Game1.textColor * 0.9f * alpha, 1f, -1f, -1, -1, 1f, 3);
				y += (int)Math.Max(font.MeasureString("TT").Y, 36f);
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00005AC0 File Offset: 0x00003CC0
		public static Point getExtraSpaceNeededForTooltipSpecialIcons(IEffect effect, SpriteFont font, int minWidth, int horizontalBuffer, int startingHeight, StringBuilder descriptionText, string boldTitleText, int moneyAmountToDisplayAtBottom)
		{
			Point result = new Point(0, startingHeight);
			List<EffectDescriptionLine> effectDescription = effect.EffectDescription;
			int count = effectDescription.Count;
			result.X = (int)Math.Max((float)minWidth, effectDescription.Max((EffectDescriptionLine line) => font.MeasureString(line.Text).X + (float)horizontalBuffer));
			result.Y += count * Math.Max((int)font.MeasureString("TT").Y, 36);
			return result;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002120 File Offset: 0x00000320
		public static int getDescriptionWidth(IEffect effect)
		{
			return 52 + (int)effect.EffectDescription.Max((EffectDescriptionLine x) => Game1.dialogueFont.MeasureString(x.Text).X);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00005B48 File Offset: 0x00003D48
		public static Point getExtraSpaceNeededForTooltipSpecialIconsBootsOnlyFix(IEffect effect, SpriteFont font, int minWidth, int horizontalBuffer, int startingHeight, StringBuilder descriptionText, string boldTitleText, int moneyAmountToDisplayAtBottom)
		{
			Point result = new Point(0, startingHeight);
			List<EffectDescriptionLine> effectDescription = effect.EffectDescription;
			int num = effectDescription.Count + 1;
			result.X = (int)Math.Max((float)minWidth, effectDescription.Max((EffectDescriptionLine line) => font.MeasureString(line.Text).X + (float)horizontalBuffer));
			result.Y += num * Math.Max((int)font.MeasureString("TT").Y, 36);
			return result;
		}

		// Token: 0x04000008 RID: 8
		public const int toolTipBottomPadding = 6;

		// Token: 0x04000009 RID: 9
		public const int iconSpace = 52;
	}
}
