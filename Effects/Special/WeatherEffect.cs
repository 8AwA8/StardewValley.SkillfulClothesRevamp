using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B7 RID: 183
	internal class WeatherEffect : SingleEffect<WeatherEffectParameters>
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00005192 File Offset: 0x00003392
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x0000519A File Offset: 0x0000339A
		// (set) Token: 0x0600043F RID: 1087 RVA: 0x000051A2 File Offset: 0x000033A2
		private Item SourceItem { get; set; }

		// Token: 0x06000440 RID: 1088 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x000051AB File Offset: 0x000033AB
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.Weather.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x000051D9 File Offset: 0x000033D9
		public WeatherEffect(WeatherEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x000051ED File Offset: 0x000033ED
		public WeatherEffect(WeatherGroup weather, IEffect actualEffect) : base(WeatherEffectParameters.With(weather, actualEffect))
		{
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00015DAC File Offset: 0x00013FAC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, EffectChangeReason.Reset);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00015E14 File Offset: 0x00014014
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00015E68 File Offset: 0x00014068
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.Weather.IsActive(Game1.player.currentLocation))
			{
				if (!this.isApplied.Value)
				{
					if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
					{
						Game1.addHUDMessage(new CustomHUDMessage(EffectHelper.ModHelper.Translation.Get("Base-EFXB") + this.SourceItem.DisplayName + EffectHelper.ModHelper.Translation.Get("Base-Active"), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
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
					Game1.addHUDMessage(new CustomHUDMessage(EffectHelper.ModHelper.Translation.Get("Base-EFXB") + this.SourceItem.DisplayName + EffectHelper.ModHelper.Translation.Get("Base-Wore"), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				this.isApplied.Value = false;
				base.Parameters.Effect.Remove(sourceItem, reason);
			}
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x0000522F File Offset: 0x0000342F
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002F0 RID: 752
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002F1 RID: 753
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
