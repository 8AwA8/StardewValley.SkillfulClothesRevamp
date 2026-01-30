using System;
using System.Runtime.CompilerServices;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000058 RID: 88
	internal class IncreaseFishingBarByCaughtFish : SingleEffect<NoEffectParameters>
	{
		// Token: 0x060001D5 RID: 469 RVA: 0x000031B2 File Offset: 0x000013B2
		public IncreaseFishingBarByCaughtFish() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000B7C0 File Offset: 0x000099C0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
			EffectHelper.ModHelper.Events.Display.MenuChanged += this.Display_MenuChanged;
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x0000B810 File Offset: 0x00009A10
		protected bool IsRealFish(string fishId)
		{
			int num;
			if (int.TryParse(fishId, out num))
			{
				if (num == 152 || num == 153 || num == 157)
				{
					return false;
				}
				if (num == 715 || num == 717 || num == 723 || num == 372 || num == 720)
				{
					return false;
				}
				if (num == 718 || num == 719 || num == 721 || num == 716 || num == 722)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000B898 File Offset: 0x00009A98
		private void Display_MenuChanged(object sender, MenuChangedEventArgs e)
		{
			BobberBar bobberBar = e.NewMenu as BobberBar;
			if (bobberBar != null)
			{
				Farmer player = Game1.player;
				IReflectedField<int> field = EffectHelper.ModHelper.Reflection.GetField<int>(bobberBar, "bobberBarHeight", true);
				int value = field.GetValue();
				int num = 0;
				foreach (string text in player.fishCaught.Keys)
				{
					if (this.IsRealFish(text))
					{
						int[] array = player.fishCaught[text];
						if (array != null && array.Length != 0)
						{
							num += array[0];
						}
					}
				}
				int num2 = (int)Math.Min(Math.Atan((double)num / 500.0) * 100.0, 120.0);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Current luck: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(player.LuckLevel);
				defaultInterpolatedStringHandler.AppendLiteral(", Daily luck: ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(player.DailyLuck);
				Logger.Debug(defaultInterpolatedStringHandler.ToStringAndClear());
				double num3 = Math.Min(0.800000011920929, (double)player.LuckLevel / 10.0);
				num3 = Math.Max(0.0, Math.Min(1.0, num3 + player.DailyLuck));
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
				defaultInterpolatedStringHandler.AppendLiteral("max increase: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				defaultInterpolatedStringHandler.AppendLiteral(", luck effect -> ");
				defaultInterpolatedStringHandler.AppendFormatted<double>(num3);
				Logger.Debug(defaultInterpolatedStringHandler.ToStringAndClear());
				int num4 = EffectHelper.Random.Next((int)((double)num2 * num3), num2);
				int num5 = Math.Min(value + (int)((float)num4 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), 450);
				field.SetValue(num5);
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(48, 4);
				defaultInterpolatedStringHandler.AppendLiteral("increased bobberBarHeight from ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral(" to ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num5);
				defaultInterpolatedStringHandler.AppendLiteral(" (+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
				defaultInterpolatedStringHandler.AppendLiteral(", #fish: ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				Logger.Debug(defaultInterpolatedStringHandler.ToStringAndClear());
				EffectHelper.ModHelper.Reflection.GetField<int>(bobberBar, "bobberBarPos", true).SetValue(568 - num5);
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x000035A2 File Offset: 0x000017A2
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFishing, EffectHelper.ModHelper.Translation.Get("Skills-BarBoost"));
		}

		// Token: 0x060001DA RID: 474 RVA: 0x000035C4 File Offset: 0x000017C4
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.Display.MenuChanged -= this.Display_MenuChanged;
		}

		// Token: 0x0400023A RID: 570
		private const int bobberBarSlotTop = 568;

		// Token: 0x0400023B RID: 571
		private const int maxBobberBarHeight = 450;

		// Token: 0x0400023C RID: 572
		private const int maxIncrease = 120;

		// Token: 0x0400023D RID: 573
		private const int maxAffectingLuck = 10;

		// Token: 0x0400023E RID: 574
		private const float maxLowerBoundRation = 0.8f;
	}
}
