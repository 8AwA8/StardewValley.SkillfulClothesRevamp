using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000054 RID: 84
	internal abstract class ChangeSkillEffect<TParameters> : SingleEffect<TParameters> where TParameters : AmountEffectParameters, new()
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060001C3 RID: 451
		public abstract string SkillName { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001C4 RID: 452
		protected abstract EffectIcon Icon { get; }

		// Token: 0x060001C5 RID: 453 RVA: 0x0000B554 File Offset: 0x00009754
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			if (base.Parameters.Amount > 0)
			{
				return new EffectDescriptionLine(this.Icon, string.Format("+{0} {1}", Math.Round((double)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), 2), this.SkillName));
			}
			return new EffectDescriptionLine(this.Icon, string.Format("{0} {1}", Math.Round((double)((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), 2), this.SkillName));
		}

		// Token: 0x060001C6 RID: 454
		protected abstract void UpdateEffects(Farmer farmer, BuffEffects targetEffects);

		// Token: 0x060001C7 RID: 455 RVA: 0x00003546 File Offset: 0x00001746
		public ChangeSkillEffect(TParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000B638 File Offset: 0x00009838
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			Logger.Debug(string.Format("{0} + {1}", this.SkillName, base.Parameters.Amount));
			ChangeSkillEffect<TParameters>.ChangeSkillBuff changeSkillBuff = new ChangeSkillEffect<TParameters>.ChangeSkillBuff(base.EffectId);
			this.thisBuff = changeSkillBuff;
			BuffEffects buffEffects = new BuffEffects();
			this.UpdateEffects(Game1.player, buffEffects);
			changeSkillBuff.effects.Add(buffEffects);
			Game1.player.buffs.Apply(changeSkillBuff);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000B6B0 File Offset: 0x000098B0
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			Logger.Debug(string.Format("{0} - {1}", this.SkillName, base.Parameters.Amount));
			Game1.player.buffs.Remove(base.EffectId);
		}

		// Token: 0x04000239 RID: 569
		public Buff thisBuff;

		// Token: 0x02000055 RID: 85
		private class ChangeSkillBuff : Buff
		{
			// Token: 0x060001CA RID: 458 RVA: 0x0000B6FC File Offset: 0x000098FC
			public ChangeSkillBuff(string id) : base(id, null, null, -2, null, -1, null, new bool?(false), null, null)
			{
				this.visible = false;
			}
		}
	}
}
