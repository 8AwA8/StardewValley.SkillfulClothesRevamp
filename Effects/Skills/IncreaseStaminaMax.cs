using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x020000AE RID: 174
	internal class IncreaseStaminaMax : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x000037DC File Offset: 0x000019DC
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.MaxEnergy;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x000037C1 File Offset: 0x000019C1
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Energy");
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x00012FA8 File Offset: 0x000111A8
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.MaxStamina.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseStaminaMax(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseStaminaMax(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
