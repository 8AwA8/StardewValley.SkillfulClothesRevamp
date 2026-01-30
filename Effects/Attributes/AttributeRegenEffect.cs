using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x0200005E RID: 94
	internal abstract class AttributeRegenEffect : SingleEffect<AttributeRegenParameters>
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001F2 RID: 498
		protected abstract string AttributeName { get; }

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x00003698 File Offset: 0x00001898
		public virtual EffectIcon Icon
		{
			get
			{
				return EffectIcon.None;
			}
		}

		// Token: 0x060001F4 RID: 500
		protected abstract int GetMaxValue(Farmer farmer);

		// Token: 0x060001F5 RID: 501
		protected abstract int GetCurrentValue(Farmer farmer);

		// Token: 0x060001F6 RID: 502
		protected abstract void SetCurrentValue(Farmer farmer, int newValue);

		// Token: 0x060001F7 RID: 503 RVA: 0x0000C0CC File Offset: 0x0000A2CC
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			if (base.Parameters.SecondsToStandStill != 0)
			{
				return new EffectDescriptionLine(this.Icon, EffectHelper.ModHelper.Translation.Get("Attribute-Base") + this.AttributeName + EffectHelper.ModHelper.Translation.Get("Attribute-Still"));
			}
			return new EffectDescriptionLine(this.Icon, EffectHelper.ModHelper.Translation.Get("Attribute-Base") + this.AttributeName + EffectHelper.ModHelper.Translation.Get("Attribute-Con"));
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000369B File Offset: 0x0000189B
		public AttributeRegenEffect(AttributeRegenParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000C178 File Offset: 0x0000A378
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked -= this.GameLoop_OneSecondUpdateTicked;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked += this.GameLoop_OneSecondUpdateTicked;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000C1C8 File Offset: 0x0000A3C8
		private void GameLoop_OneSecondUpdateTicked(object sender, OneSecondUpdateTickedEventArgs e)
		{
			if (base.Parameters.SecondsToStandStill == 0 && (this.standingStillForSeconds - base.Parameters.SecondsToStandStill) % base.Parameters.RegenIntervalSeconds == 0)
			{
				int currentValue = this.GetCurrentValue(Game1.player);
				int maxValue = this.GetMaxValue(Game1.player);
				if (!Game1.player.isGlowing && currentValue < maxValue)
				{
					Game1.player.startGlowing(base.Parameters.GlowColor, false, 0.0166666675f);
				}
				if (currentValue < maxValue)
				{
					this.SetCurrentValue(Game1.player, Math.Min(currentValue + (int)((float)base.Parameters.RegenAmount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), maxValue));
				}
				if (currentValue >= maxValue && Game1.player.isGlowing && Game1.player.glowingColor == base.Parameters.GlowColor)
				{
					Game1.player.stopGlowing();
					return;
				}
			}
			if (this.previousLocation == null)
			{
				this.previousLocation = new Vector2?(Game1.player.getStandingPosition());
				return;
			}
			if (this.previousLocation.Value.Equals(Game1.player.getStandingPosition()))
			{
				if (Context.IsPlayerFree)
				{
					this.standingStillForSeconds++;
					this.previousLocation = new Vector2?(Game1.player.getStandingPosition());
					if (this.standingStillForSeconds >= base.Parameters.SecondsToStandStill && (this.standingStillForSeconds - base.Parameters.SecondsToStandStill) % base.Parameters.RegenIntervalSeconds == 0)
					{
						int currentValue2 = this.GetCurrentValue(Game1.player);
						int maxValue2 = this.GetMaxValue(Game1.player);
						if (!Game1.player.isGlowing && currentValue2 < maxValue2)
						{
							Game1.player.startGlowing(base.Parameters.GlowColor, false, 0.0166666675f);
						}
						if (currentValue2 < maxValue2)
						{
							this.SetCurrentValue(Game1.player, Math.Min(currentValue2 + base.Parameters.RegenAmount, maxValue2));
						}
						if (currentValue2 >= maxValue2 && Game1.player.isGlowing && Game1.player.glowingColor == base.Parameters.GlowColor)
						{
							Game1.player.stopGlowing();
							return;
						}
					}
				}
			}
			else
			{
				if (this.standingStillForSeconds > 0 && Game1.player.isGlowing && Game1.player.glowingColor == base.Parameters.GlowColor)
				{
					Game1.player.stopGlowing();
				}
				this.standingStillForSeconds = 0;
				this.previousLocation = new Vector2?(Game1.player.getStandingPosition());
			}
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000036A4 File Offset: 0x000018A4
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicked -= this.GameLoop_OneSecondUpdateTicked;
		}

		// Token: 0x04000241 RID: 577
		private int standingStillForSeconds;

		// Token: 0x04000242 RID: 578
		private Vector2? previousLocation;
	}
}
