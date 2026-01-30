using System;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000084 RID: 132
	internal class RangedPower : SingleEffect<RangedPowerParameters>
	{
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060002EF RID: 751 RVA: 0x000040C6 File Offset: 0x000022C6
		// (set) Token: 0x060002F0 RID: 752 RVA: 0x000040CE File Offset: 0x000022CE
		private Item SourceItem { get; set; }

		// Token: 0x060002F1 RID: 753 RVA: 0x000040D7 File Offset: 0x000022D7
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillCombat, EffectHelper.ModHelper.Translation.Get("Spec-Ranged"));
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x000040F9 File Offset: 0x000022F9
		public RangedPower(RangedPowerParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000410D File Offset: 0x0000230D
		public RangedPower(IEffect actualEffect) : base(RangedPowerParameters.With(actualEffect))
		{
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000DCCC File Offset: 0x0000BECC
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.EquipChange += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00004126 File Offset: 0x00002326
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x0000DD20 File Offset: 0x0000BF20
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (Game1.player.ActiveItem == null || !Game1.player.ActiveItem.Name.Contains("Slingshot"))
			{
				if (this.isApplied.Value)
				{
					base.Parameters.Effect.Remove(sourceItem, reason);
					this.isApplied.Value = false;
				}
				return;
			}
			if (this.isApplied.Value)
			{
				return;
			}
			this.isApplied.Value = true;
			base.Parameters.Effect.Apply(sourceItem, reason);
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00004157 File Offset: 0x00002357
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x0400028C RID: 652
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
