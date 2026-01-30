using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000038 RID: 56
	internal static class EffectIconExtensions
	{
		// Token: 0x0600013A RID: 314 RVA: 0x00009658 File Offset: 0x00007858
		public static void Draw(this EffectIcon icon, SpriteBatch spriteBatch, Vector2 location)
		{
			if (icon == EffectIcon.None)
			{
				return;
			}
			Texture2D texture2D = Game1.mouseCursors;
			Rectangle? rectangle = null;
			switch (icon)
			{
			case EffectIcon.Popularity:
				Utility.drawWithShadow(spriteBatch, Game1.mouseCursors, new Vector2(location.X, location.Y + 2f), new Rectangle(157, 515, 13, 13), Color.White, 0f, Vector2.Zero, 2f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Health:
				rectangle = new Rectangle?(new Rectangle(0, 438, 10, 10));
				break;
			case EffectIcon.MaxHealth:
				texture2D = EffectHelper.Textures.LooseSprites;
				rectangle = new Rectangle?(new Rectangle(0, 0, 10, 10));
				break;
			case EffectIcon.Energy:
				rectangle = new Rectangle?(new Rectangle(0, 428, 10, 10));
				break;
			case EffectIcon.MaxEnergy:
				rectangle = new Rectangle?(new Rectangle(80, 428, 10, 10));
				break;
			case EffectIcon.Attack:
				rectangle = new Rectangle?(new Rectangle(120, 428, 10, 10));
				break;
			case EffectIcon.Defense:
				rectangle = new Rectangle?(new Rectangle(110, 428, 10, 10));
				break;
			case EffectIcon.CriticalHitRate:
				rectangle = new Rectangle?(new Rectangle(160, 428, 10, 10));
				break;
			case EffectIcon.Immunity:
				rectangle = new Rectangle?(new Rectangle(150, 428, 10, 10));
				break;
			case EffectIcon.Speed:
				rectangle = new Rectangle?(new Rectangle(130, 428, 10, 10));
				break;
			case EffectIcon.SaveFromDeath:
				rectangle = new Rectangle?(new Rectangle(140, 428, 10, 10));
				break;
			case EffectIcon.SkillFarming:
				rectangle = new Rectangle?(new Rectangle(10, 428, 10, 10));
				break;
			case EffectIcon.SkillFishing:
				rectangle = new Rectangle?(new Rectangle(20, 428, 10, 10));
				break;
			case EffectIcon.SkillForaging:
				rectangle = new Rectangle?(new Rectangle(60, 428, 10, 10));
				break;
			case EffectIcon.SkillMining:
				rectangle = new Rectangle?(new Rectangle(30, 428, 10, 10));
				break;
			case EffectIcon.SkillCombat:
				rectangle = new Rectangle?(new Rectangle(40, 428, 10, 10));
				break;
			case EffectIcon.SkillLuck:
				rectangle = new Rectangle?(new Rectangle(50, 428, 10, 10));
				break;
			case EffectIcon.Yoba:
				texture2D = EffectHelper.Textures.LooseSprites;
				rectangle = new Rectangle?(new Rectangle(10, 0, 10, 10));
				break;
			case EffectIcon.TreasureChest:
				rectangle = new Rectangle?(new Rectangle(137, 412, 10, 11));
				break;
			case EffectIcon.Animal_Chicken:
				Utility.drawWithShadow(spriteBatch, Game1.mouseCursors, new Vector2(location.X, location.Y + 5f), new Rectangle(0, 448, 32, 16), Color.White, 0f, Vector2.Zero, 1.2f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Animal_Cow:
				Utility.drawWithShadow(spriteBatch, Game1.mouseCursors, new Vector2(location.X, location.Y + 2f), new Rectangle(40, 449, 17, 14), Color.White, 0f, Vector2.Zero, 1.8f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Glow:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 63, 9, 9));
				break;
			case EffectIcon.Person_Lewis:
				Utility.drawWithShadow(spriteBatch, EffectHelper.Textures.LooseSprites, new Vector2(location.X, location.Y), new Rectangle(20, 0, 12, 13), Color.White, 0f, Vector2.Zero, 2f, false, 0.95f, -1, -1, 0.35f);
				break;
			case EffectIcon.Red:
				rectangle = new Rectangle?(new Rectangle(193, 373, 9, 9));
				break;
			case EffectIcon.Red2:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(0, 90, 9, 9));
				break;
			case EffectIcon.Blue:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 90, 9, 9));
				break;
			case EffectIcon.Yellow:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(18, 90, 9, 9));
				break;
			case EffectIcon.Fire:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(27, 90, 9, 9));
				break;
			case EffectIcon.Crown:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(108, 54, 9, 9));
				break;
			case EffectIcon.Iridium:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(99, 27, 9, 9));
				break;
			case EffectIcon.DustSprite:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 45, 9, 9));
				break;
			case EffectIcon.Stardrop:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(27, 54, 9, 9));
				break;
			case EffectIcon.Crab:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(72, 72, 9, 9));
				break;
			case EffectIcon.CandyCane:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(81, 54, 9, 9));
				break;
			case EffectIcon.Pumpkin:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(90, 54, 9, 9));
				break;
			case EffectIcon.Heart:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 27, 9, 9));
				break;
			case EffectIcon.Swirl:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(63, 27, 9, 9));
				break;
			case EffectIcon.Lightning:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(36, 63, 9, 9));
				break;
			case EffectIcon.Money:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(63, 36, 9, 9));
				break;
			case EffectIcon.Dwarf:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(9, 117, 9, 9));
				break;
			case EffectIcon.Krobus:
				texture2D = EffectHelper.Textures.Emojis;
				rectangle = new Rectangle?(new Rectangle(0, 117, 9, 9));
				break;
			default:
				if (icon == EffectIcon.Clover)
				{
					texture2D = EffectHelper.Textures.Emojis;
					rectangle = new Rectangle?(new Rectangle(72, 81, 9, 9));
				}
				break;
			}
			if (rectangle != null)
			{
				Utility.drawWithShadow(spriteBatch, texture2D, location, rectangle.Value, Color.White, 0f, Vector2.Zero, 3f, false, 0.95f, -1, -1, 0.35f);
			}
		}
	}
}
