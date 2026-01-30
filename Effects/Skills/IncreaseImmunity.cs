using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000059 RID: 89
	internal class IncreaseImmunity : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x060001DB RID: 475 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseImmunity(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001DC RID: 476 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseImmunity(int amount) : base(AmountEffectParameters.With(amount))
		{
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001DD RID: 477 RVA: 0x000035E6 File Offset: 0x000017E6
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Immunity");
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00003601 File Offset: 0x00001801
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Immunity;
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x0000BB40 File Offset: 0x00009D40
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Immunity.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}
	}
}
