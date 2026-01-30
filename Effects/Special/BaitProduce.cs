using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008C RID: 140
	internal class BaitProduce : SingleEffect<BaitProduceParameters>
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000439D File Offset: 0x0000259D
		// (set) Token: 0x06000323 RID: 803 RVA: 0x000043A5 File Offset: 0x000025A5
		private Item SourceItem { get; set; }

		// Token: 0x06000324 RID: 804 RVA: 0x000043AE File Offset: 0x000025AE
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillFishing, EffectHelper.ModHelper.Translation.Get("Spec-BP"));
		}

		// Token: 0x06000325 RID: 805 RVA: 0x000043D0 File Offset: 0x000025D0
		public BaitProduce(BaitProduceParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000326 RID: 806 RVA: 0x000043FA File Offset: 0x000025FA
		public BaitProduce(int steps) : base(BaitProduceParameters.With(steps))
		{
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000E310 File Offset: 0x0000C510
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.steps.Value = (int)Game1.player.stats.StepsTaken;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.Events_UpdateTicking;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00004429 File Offset: 0x00002629
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0000E380 File Offset: 0x0000C580
		private void Events_UpdateTicking(object sender, TimeChangedEventArgs e)
		{
			if ((long)this.steps.Value < (long)((ulong)Game1.player.stats.StepsTaken))
			{
				this.count.Value += (int)(Game1.player.stats.StepsTaken - (uint)this.steps.Value);
				this.steps.Value = (int)Game1.player.stats.StepsTaken;
				if (this.count.Value >= (int)((float)base.Parameters.Steps * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? (1f / EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple) : 1f)))
				{
					Game1.player.playNearbySoundLocal("coin", null, 0);
					int value = this.overcount.Value;
					this.overcount.Value = value + this.count.Value / 10;
					this.count.Value = 0;
					if (this.overcount.Value >= 10)
					{
						this.overcount.Value = 0;
						Item item = ItemRegistry.Create("DeluxeBait", 1, 0, true);
						Game1.player.addItemToInventory(item);
					}
					else
					{
						Item item2 = ItemRegistry.Create("685", 1, 0, true);
						Game1.player.addItemToInventory(item2);
					}
				}
			}
			this.steps.Value = (int)Game1.player.stats.StepsTaken;
		}

		// Token: 0x04000299 RID: 665
		private PerScreen<int> steps = new PerScreen<int>();

		// Token: 0x0400029A RID: 666
		private PerScreen<int> count = new PerScreen<int>();

		// Token: 0x0400029B RID: 667
		private PerScreen<int> overcount = new PerScreen<int>();
	}
}
