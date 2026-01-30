using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000060 RID: 96
	internal abstract class ChangeAttributeMaxEffect : SingleEffect<AmountEffectParameters>
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000206 RID: 518
		public abstract string AttributeName { get; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00003698 File Offset: 0x00001898
		public virtual EffectIcon Icon
		{
			get
			{
				return EffectIcon.None;
			}
		}

		// Token: 0x06000208 RID: 520
		protected abstract int GetMaxValue(Farmer farmer);

		// Token: 0x06000209 RID: 521
		protected abstract void SetMaxValue(Farmer farmer, int newValue);

		// Token: 0x0600020A RID: 522
		protected abstract int GetCurrentValue(Farmer farmer);

		// Token: 0x0600020B RID: 523
		protected abstract void SetCurrentValue(Farmer farmer, int newValue);

		// Token: 0x0600020C RID: 524 RVA: 0x0000C474 File Offset: 0x0000A674
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			if (base.Parameters.Amount > 0)
			{
				return new EffectDescriptionLine(this.Icon, string.Format("+{0} " + EffectHelper.ModHelper.Translation.Get("Attribute-Max") + " {1}", Math.Round((double)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 0.55f : 1f)), 1), this.AttributeName));
			}
			return new EffectDescriptionLine(this.Icon, string.Format("{0} " + EffectHelper.ModHelper.Translation.Get("Attribute-Max") + " {1}", Math.Round((double)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 0.55f : 1f)), 1), this.AttributeName));
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00003756 File Offset: 0x00001956
		public ChangeAttributeMaxEffect(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000C578 File Offset: 0x0000A778
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			if (this.isApplied.Value)
			{
				return;
			}
			this.isApplied.Value = true;
			int currentValue = this.GetCurrentValue(Game1.player);
			if (this.GetMaxValue(Game1.player) == this.savedHealth.Value + (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)))
			{
				this.SetMaxValue(Game1.player, this.savedHealth.Value);
			}
			int maxValue = this.GetMaxValue(Game1.player);
			this.savedHealth.Value = maxValue;
			if (currentValue == maxValue)
			{
				this.SetMaxValue(Game1.player, maxValue + (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)));
				this.SetCurrentValue(Game1.player, currentValue + (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)));
			}
			else
			{
				this.SetMaxValue(Game1.player, maxValue + (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)));
			}
			Logger.Debug(string.Format("Max{0} + {1}", this.AttributeName, base.Parameters.Amount));
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000C71C File Offset: 0x0000A91C
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			if (!this.isApplied.Value)
			{
				return;
			}
			this.isApplied.Value = false;
			int num = Math.Max(this.GetMaxValue(Game1.player) - (int)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), this.savedHealth.Value);
			if (this.GetCurrentValue(Game1.player) > num)
			{
				this.SetCurrentValue(Game1.player, num);
			}
			this.SetMaxValue(Game1.player, num);
			Logger.Debug(string.Format("Max{0} - {1}", this.AttributeName, base.Parameters.Amount));
		}

		// Token: 0x04000247 RID: 583
		private PerScreen<bool> isApplied = new PerScreen<bool>();

		// Token: 0x04000248 RID: 584
		private PerScreen<int> savedHealth = new PerScreen<int>();
	}
}
