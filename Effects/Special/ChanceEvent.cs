using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Events;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000BB RID: 187
	internal class ChanceEvent : SingleEffect<ChanceEventParameters>
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x00005314 File Offset: 0x00003514
		// (set) Token: 0x06000459 RID: 1113 RVA: 0x0000531C File Offset: 0x0000351C
		private Item SourceItem { get; set; }

		// Token: 0x0600045A RID: 1114 RVA: 0x00016138 File Offset: 0x00014338
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Swirl, string.Concat(new object[]
			{
				(int)((float)Math.Abs(base.Parameters.Chance) * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)),
				"% ",
				this.Name(),
				" ",
				(base.Parameters.Chance < 0) ? EffectHelper.ModHelper.Translation.Get("EventHelp1") : EffectHelper.ModHelper.Translation.Get("EventHelp2")
			}));
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x00005325 File Offset: 0x00003525
		public ChanceEvent(ChanceEventParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00005339 File Offset: 0x00003539
		public ChanceEvent(int chance, int code) : base(ChanceEventParameters.With(chance, code))
		{
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x000161F0 File Offset: 0x000143F0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			if (this.day.Value == Game1.dayOfMonth)
			{
				return;
			}
			this.day.Value = Game1.dayOfMonth;
			if (base.Parameters.Chance < 0)
			{
				switch (base.Parameters.Code)
				{
				case 0:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is FairyEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is FairyEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				case 1:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is WitchEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is WitchEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				case 2:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is SoundInTheNightEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is SoundInTheNightEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				case 3:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is SoundInTheNightEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is SoundInTheNightEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				default:
					if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
					{
						Game1.farmEvent = ((Game1.farmEvent is SoundInTheNightEvent) ? null : Game1.farmEvent);
						Game1.farmEventOverride = ((Game1.farmEventOverride is SoundInTheNightEvent) ? null : Game1.farmEventOverride);
						return;
					}
					break;
				}
			}
			FarmEvent farmEvent = Game1.farmEvent;
			switch (base.Parameters.Code)
			{
			case 0:
				farmEvent = new FairyEvent();
				break;
			case 1:
				farmEvent = new WitchEvent();
				break;
			case 2:
				farmEvent = new SoundInTheNightEvent(0);
				break;
			case 3:
				farmEvent = new SoundInTheNightEvent(1);
				break;
			default:
				farmEvent = new SoundInTheNightEvent(3);
				break;
			}
			if (Game1.random.NextDouble() < (double)((float)base.Parameters.Chance * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / -100f))
			{
				Game1.farmEventOverride = ((Game1.farmEventOverride == null) ? farmEvent : Game1.farmEventOverride);
				return;
			}
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00005353 File Offset: 0x00003553
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = null;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0001657C File Offset: 0x0001477C
		private string Name()
		{
			if (base.Parameters.Code == 0)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode0");
			}
			if (base.Parameters.Code == 1)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode1");
			}
			if (base.Parameters.Code == 2)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode2");
			}
			if (base.Parameters.Code == 3)
			{
				return EffectHelper.ModHelper.Translation.Get("NightCode3");
			}
			return EffectHelper.ModHelper.Translation.Get("NightCode4");
		}

		// Token: 0x040002F6 RID: 758
		private PerScreen<int> day = new PerScreen<int>();
	}
}
