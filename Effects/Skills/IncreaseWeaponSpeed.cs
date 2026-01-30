using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007C RID: 124
	internal class IncreaseWeaponSpeed : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000354F File Offset: 0x0000174F
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Attack;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x00003EB3 File Offset: 0x000020B3
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-WS");
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000D858 File Offset: 0x0000BA58
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.WeaponSpeedMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseWeaponSpeed(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseWeaponSpeed(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
