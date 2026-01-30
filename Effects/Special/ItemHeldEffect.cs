using System;
using System.Collections.Generic;
using System.Linq;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A5 RID: 165
	internal class ItemHeldEffect : SingleEffect<ItemHeldEffectParameters>
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x00004CCE File Offset: 0x00002ECE
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x00004CD6 File Offset: 0x00002ED6
		private Item SourceItem { get; set; }

		// Token: 0x060003C2 RID: 962 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00004CDF File Offset: 0x00002EDF
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x00004CE7 File Offset: 0x00002EE7
		public ItemHeldEffect(ItemHeldEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x00004CFB File Offset: 0x00002EFB
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-ItemH") + base.Parameters.itemId)).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x00004D29 File Offset: 0x00002F29
		public ItemHeldEffect(string itemId, IEffect actualEffect) : base(ItemHeldEffectParameters.With(itemId, actualEffect))
		{
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0001222C File Offset: 0x0001042C
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.EquipChange += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x00004D43 File Offset: 0x00002F43
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00012280 File Offset: 0x00010480
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (Game1.player.ActiveItem == null || Game1.player.ActiveItem.Name == null || !Game1.player.ActiveItem.Name.Contains(base.Parameters.itemId))
			{
				if (this.isApplied.Value)
				{
					base.Parameters.Effect.Remove(sourceItem, reason);
					this.isApplied.Value = false;
				}
				return;
			}
			if (!this.isApplied.Value)
			{
				this.isApplied.Value = true;
				base.Parameters.Effect.Apply(sourceItem, reason);
				return;
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x00004DB0 File Offset: 0x00002FB0
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002C9 RID: 713
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002CA RID: 714
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
