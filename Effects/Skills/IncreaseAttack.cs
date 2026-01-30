using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000056 RID: 86
	internal class IncreaseAttack : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000354F File Offset: 0x0000174F
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Attack;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001CC RID: 460 RVA: 0x00003552 File Offset: 0x00001752
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Attack");
			}
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000B728 File Offset: 0x00009928
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Attack.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseAttack(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseAttack(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
