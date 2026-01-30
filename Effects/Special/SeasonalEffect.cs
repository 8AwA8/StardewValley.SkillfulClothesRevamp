using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000050 RID: 80
	internal class SeasonalEffect : CustomizableEffect<SeasonalEffectParameters>
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x00003393 File Offset: 0x00001593
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x0000339B File Offset: 0x0000159B
		// (set) Token: 0x060001A8 RID: 424 RVA: 0x000033A3 File Offset: 0x000015A3
		private Item SourceItem { get; set; }

		// Token: 0x060001A9 RID: 425 RVA: 0x000033AC File Offset: 0x000015AC
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.Season.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000033DA File Offset: 0x000015DA
		public SeasonalEffect(SeasonalEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000033EE File Offset: 0x000015EE
		public SeasonalEffect(Season season, IEffect actualEffect) : base(SeasonalEffectParameters.With(season, actualEffect))
		{
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000AF5C File Offset: 0x0000915C
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00003408 File Offset: 0x00001608
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000AFC4 File Offset: 0x000091C4
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.Season.IsActive())
			{
				if (!this.isApplied.Value)
				{
					if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts && this.SourceItem != null && (reason == EffectChangeReason.Reset || (reason == EffectChangeReason.DayStart && Game1.dayOfMonth == 1)))
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
						defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-EFXB"));
						defaultInterpolatedStringHandler.AppendFormatted<Item>(this.SourceItem);
						defaultInterpolatedStringHandler.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-Active"));
						Game1.addHUDMessage(new CustomHUDMessage(defaultInterpolatedStringHandler.ToStringAndClear(), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
					}
					this.isApplied.Value = true;
					base.Parameters.Effect.Apply(sourceItem, reason);
					return;
				}
			}
			else if (this.isApplied.Value)
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(23, 1);
					defaultInterpolatedStringHandler2.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-EFXB"));
					defaultInterpolatedStringHandler2.AppendFormatted<Item>(this.SourceItem);
					defaultInterpolatedStringHandler2.AppendLiteral(EffectHelper.ModHelper.Translation.Get("Base-Wore"));
					Game1.addHUDMessage(new CustomHUDMessage(defaultInterpolatedStringHandler2.ToStringAndClear(), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				this.isApplied.Value = false;
				base.Parameters.Effect.Remove(sourceItem, reason);
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000346B File Offset: 0x0000166B
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(null, EffectChangeReason.Reset);
		}

		// Token: 0x04000232 RID: 562
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x04000233 RID: 563
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
