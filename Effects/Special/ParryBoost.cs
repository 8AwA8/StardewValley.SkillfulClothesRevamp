using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Tools;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000082 RID: 130
	internal class ParryBoost : SingleEffect<NoEffectParameters>
	{
		// Token: 0x060002E6 RID: 742 RVA: 0x00004025 File Offset: 0x00002225
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Attack, EffectHelper.ModHelper.Translation.Get("Spec-Parry"));
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x000031B2 File Offset: 0x000013B2
		public ParryBoost() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00004046 File Offset: 0x00002246
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.SpecialUsed -= this.GameLoop_UpdateTicking;
			EffectHelper.Events.SpecialUsed += this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00004074 File Offset: 0x00002274
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.SpecialUsed -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000408C File Offset: 0x0000228C
		private void GameLoop_UpdateTicking(object sender, EventArgs e)
		{
			MeleeWeapon.defenseCooldown = 0;
		}
	}
}
