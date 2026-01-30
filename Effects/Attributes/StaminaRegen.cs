using System;
using Microsoft.Xna.Framework;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000064 RID: 100
	internal class StaminaRegen : AttributeRegenEffect
	{
		// Token: 0x06000226 RID: 550 RVA: 0x00003830 File Offset: 0x00001A30
		public StaminaRegen() : base(AttributeRegenParameters.With(Color.Green, 5, 1, 1))
		{
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000227 RID: 551 RVA: 0x000037C1 File Offset: 0x000019C1
		protected override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Energy");
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00003845 File Offset: 0x00001A45
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Energy;
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000037F6 File Offset: 0x000019F6
		protected override int GetCurrentValue(Farmer farmer)
		{
			return (int)farmer.stamina;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00003848 File Offset: 0x00001A48
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.MaxStamina;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00003850 File Offset: 0x00001A50
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.Stamina = (float)newValue;
		}
	}
}
