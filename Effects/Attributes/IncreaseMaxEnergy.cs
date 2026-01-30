using System;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000062 RID: 98
	internal class IncreaseMaxEnergy : ChangeAttributeMaxEffect
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000216 RID: 534 RVA: 0x000037C1 File Offset: 0x000019C1
		public override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Energy");
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000217 RID: 535 RVA: 0x000037DC File Offset: 0x000019DC
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.MaxEnergy;
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000037DF File Offset: 0x000019DF
		public IncreaseMaxEnergy(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000219 RID: 537 RVA: 0x000037E8 File Offset: 0x000019E8
		public IncreaseMaxEnergy(int amount) : base(AmountEffectParameters.With(amount))
		{
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000037F6 File Offset: 0x000019F6
		protected override int GetCurrentValue(Farmer farmer)
		{
			return (int)farmer.stamina;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000037FF File Offset: 0x000019FF
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.stamina = (float)newValue;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00003809 File Offset: 0x00001A09
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.maxStamina.Value;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00003816 File Offset: 0x00001A16
		protected override void SetMaxValue(Farmer farmer, int newValue)
		{
			farmer.maxStamina.Value = newValue;
		}
	}
}
