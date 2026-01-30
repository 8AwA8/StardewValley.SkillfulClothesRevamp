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
	// Token: 0x020000B6 RID: 182
	internal class LocationalEffect : SingleEffect<LocationalEffectParameters>
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x000050AB File Offset: 0x000032AB
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000432 RID: 1074 RVA: 0x000050B3 File Offset: 0x000032B3
		// (set) Token: 0x06000433 RID: 1075 RVA: 0x000050BB File Offset: 0x000032BB
		private Item SourceItem { get; set; }

		// Token: 0x06000434 RID: 1076 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x000050C4 File Offset: 0x000032C4
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.Location.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x000050F2 File Offset: 0x000032F2
		public LocationalEffect(LocationalEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00005106 File Offset: 0x00003306
		public LocationalEffect(LocationGroup location, IEffect actualEffect) : base(LocationalEffectParameters.With(location, actualEffect))
		{
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00015BBC File Offset: 0x00013DBC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00005120 File Offset: 0x00003320
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00015C24 File Offset: 0x00013E24
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.Location.IsActive(Game1.player))
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

		// Token: 0x0600043C RID: 1084 RVA: 0x00005183 File Offset: 0x00003383
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002ED RID: 749
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002EE RID: 750
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
