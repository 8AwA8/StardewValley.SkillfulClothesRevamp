using System;
using System.Collections.Generic;
using System.Linq;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000095 RID: 149
	internal class MeleePower : SingleEffect<MeleePowerParameters>
	{
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000358 RID: 856 RVA: 0x000046F6 File Offset: 0x000028F6
		// (set) Token: 0x06000359 RID: 857 RVA: 0x000046FE File Offset: 0x000028FE
		private Item SourceItem { get; set; }

		// Token: 0x0600035A RID: 858 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00004707 File Offset: 0x00002907
		public MeleePower(MeleePowerParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000471B File Offset: 0x0000291B
		public MeleePower(IEffect actualEffect, int weaponid) : base(MeleePowerParameters.With(actualEffect, weaponid))
		{
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000F148 File Offset: 0x0000D348
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.isApplied.Value = false;
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.EquipChange += this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x00004735 File Offset: 0x00002935
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.Events.EquipChange -= this.GameLoop_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000F19C File Offset: 0x0000D39C
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			MeleeWeapon meleeWeapon = Game1.player.ActiveItem as MeleeWeapon;
			if (meleeWeapon == null || (meleeWeapon.type.Value != base.Parameters.WeaponID && (meleeWeapon.type.Value != 3 || base.Parameters.WeaponID != 0) && (meleeWeapon.type.Value != 0 || base.Parameters.WeaponID != 3)))
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

		// Token: 0x06000360 RID: 864 RVA: 0x0000F264 File Offset: 0x0000D464
		public override void ReloadParameters()
		{
			if (base.Parameters.WeaponID == 0 || base.Parameters.WeaponID == 3)
			{
				this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
				select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeS"))).ToList<EffectDescriptionLine>();
				return;
			}
			if (base.Parameters.WeaponID == 1)
			{
				this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
				select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeD"))).ToList<EffectDescriptionLine>();
				return;
			}
			if (base.Parameters.WeaponID == 2)
			{
				this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
				select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeC"))).ToList<EffectDescriptionLine>();
				return;
			}
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + EffectHelper.ModHelper.Translation.Get("Spec-MeleeError"))).ToList<EffectDescriptionLine>();
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000361 RID: 865 RVA: 0x00004766 File Offset: 0x00002966
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000476E File Offset: 0x0000296E
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x040002A8 RID: 680
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002A9 RID: 681
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
