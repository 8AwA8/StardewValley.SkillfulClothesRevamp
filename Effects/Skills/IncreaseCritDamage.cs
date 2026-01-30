using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007B RID: 123
	internal class IncreaseCritDamage : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00003E7A File Offset: 0x0000207A
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.CriticalHitRate;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002C1 RID: 705 RVA: 0x00003E98 File Offset: 0x00002098
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-CritD");
			}
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000D804 File Offset: 0x0000BA04
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.CriticalPowerMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseCritDamage(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseCritDamage(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
