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
	// Token: 0x02000074 RID: 116
	internal class healthEffect : SingleEffect<healthEffectParameters>
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000291 RID: 657 RVA: 0x00003C37 File Offset: 0x00001E37
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00003C3F File Offset: 0x00001E3F
		// (set) Token: 0x06000293 RID: 659 RVA: 0x00003C47 File Offset: 0x00001E47
		private Item SourceItem { get; set; }

		// Token: 0x06000294 RID: 660 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00003C53 File Offset: 0x00001E53
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + base.Parameters.health.GetEffectDescriptionSuffix())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00003C81 File Offset: 0x00001E81
		public healthEffect(healthEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00003C95 File Offset: 0x00001E95
		public healthEffect(healthGroup health, IEffect actualEffect) : base(healthEffectParameters.With(health, actualEffect))
		{
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000D1DC File Offset: 0x0000B3DC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_OneSecondUpdateTicks;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking += this.Events_OneSecondUpdateTicks;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00003CAF File Offset: 0x00001EAF
		private void Events_OneSecondUpdateTicks(object sender, OneSecondUpdateTickingEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00003CBE File Offset: 0x00001EBE
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.Events_OneSecondUpdateTicks;
			this.SourceItem = null;
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000D244 File Offset: 0x0000B444
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.health.IsActive())
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

		// Token: 0x0400027E RID: 638
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x0400027F RID: 639
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
