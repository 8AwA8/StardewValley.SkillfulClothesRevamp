using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000076 RID: 118
	internal class DepthScale : SingleEffect<DepthScalingParameters>
	{
		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00003D6B File Offset: 0x00001F6B
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x00003D73 File Offset: 0x00001F73
		// (set) Token: 0x060002A5 RID: 677 RVA: 0x00003D7B File Offset: 0x00001F7B
		private Item SourceItem { get; set; }

		// Token: 0x060002A6 RID: 678 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000D3C8 File Offset: 0x0000B5C8
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, string.Concat(new object[]
			{
				x.Text,
				EffectHelper.ModHelper.Translation.Get("Spec-DScale")
			}))).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00003D84 File Offset: 0x00001F84
		public DepthScale(DepthScalingParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00003D98 File Offset: 0x00001F98
		public DepthScale(int floors, IEffect actualEffect) : base(DepthScalingParameters.With(floors, actualEffect))
		{
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0000D414 File Offset: 0x0000B614
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00003DB2 File Offset: 0x00001FB2
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			this.SourceItem = null;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000D470 File Offset: 0x0000B670
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			MineShaft mineShaft = Game1.currentLocation as MineShaft;
			if (mineShaft != null && ((mineShaft.mineLevel < 120 && mineShaft.mineLevel > 25) || mineShaft.mineLevel > 145))
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					Game1.addHUDMessage(new CustomHUDMessage(string.Concat(new object[]
					{
						"The effect of ",
						this.SourceItem.DisplayName,
						" is scaling "
					}), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				this.isApplied.Value = true;
				base.Parameters.Effect.Apply(sourceItem, reason);
				return;
			}
			if (this.isApplied.Value)
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					Game1.addHUDMessage(new CustomHUDMessage("The effect of " + this.SourceItem.DisplayName + " wore off", this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				base.Parameters.Effect.Remove(sourceItem, reason);
				this.isApplied.Value = false;
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00003DED File Offset: 0x00001FED
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x04000283 RID: 643
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x04000284 RID: 644
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
