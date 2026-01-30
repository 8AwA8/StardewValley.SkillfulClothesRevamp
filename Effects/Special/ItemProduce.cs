using System;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000C3 RID: 195
	internal class ItemProduce : SingleEffect<ItemProduceParameters>
	{
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x000054A9 File Offset: 0x000036A9
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x000054B1 File Offset: 0x000036B1
		private Item SourceItem { get; set; }

		// Token: 0x06000482 RID: 1154 RVA: 0x000054BA File Offset: 0x000036BA
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Clover, EffectHelper.ModHelper.Translation.Get("Spec-IP", new
			{
				name = base.Parameters.displayName
			}));
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x000054EC File Offset: 0x000036EC
		public ItemProduce(ItemProduceParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0000550B File Offset: 0x0000370B
		public ItemProduce(int steps, string displayName, string id) : base(ItemProduceParameters.With(steps, displayName, id))
		{
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x000169B4 File Offset: 0x00014BB4
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.steps.Value = (int)Game1.player.stats.StepsTaken;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.Events_UpdateTicking;
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00005531 File Offset: 0x00003731
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00016A24 File Offset: 0x00014C24
		private void Events_UpdateTicking(object sender, TimeChangedEventArgs e)
		{
			if ((long)this.steps.Value < (long)((ulong)Game1.player.stats.StepsTaken))
			{
				this.count.Value += (int)(Game1.player.stats.StepsTaken - (uint)this.steps.Value);
				this.steps.Value = (int)Game1.player.stats.StepsTaken;
				if (this.count.Value >= (int)((float)base.Parameters.Steps * (EffectHelper.Config.LessImpactfulClothes ? (1f / EffectHelper.Config.TypicalClothesMultiple) : 1f)))
				{
					Game1.player.playNearbySoundLocal("coin", null, 0);
					this.count.Value = 0;
					Item item = ItemRegistry.Create(base.Parameters.qId, 1, 0, true);
					Game1.player.addItemToInventory(item);
				}
			}
			this.steps.Value = (int)Game1.player.stats.StepsTaken;
		}

		// Token: 0x04000314 RID: 788
		private PerScreen<int> steps = new PerScreen<int>();

		// Token: 0x04000315 RID: 789
		private PerScreen<int> count = new PerScreen<int>();
	}
}
