using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000078 RID: 120
	internal class IncreaseAttackMultiplier : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x0000354F File Offset: 0x0000174F
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Attack;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x00003E40 File Offset: 0x00002040
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-AttackM");
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000D5C0 File Offset: 0x0000B7C0
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.AttackMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseAttackMultiplier(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseAttackMultiplier(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
