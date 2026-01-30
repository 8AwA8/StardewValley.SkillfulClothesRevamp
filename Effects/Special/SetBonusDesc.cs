using System;
using System.Collections.Generic;
using System.Linq;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000AC RID: 172
	internal class SetBonusDesc : SingleEffect<SetBonusDescParameters>
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x00004F67 File Offset: 0x00003167
		// (set) Token: 0x060003F5 RID: 1013 RVA: 0x00004F6F File Offset: 0x0000316F
		private Item SourceItem { get; set; }

		// Token: 0x060003F6 RID: 1014 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x00004F78 File Offset: 0x00003178
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x00004F80 File Offset: 0x00003180
		public SetBonusDesc(SetBonusDescParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00012EEC File Offset: 0x000110EC
		public override void ReloadParameters()
		{
			EffectIcon icon = this.iconFromName(base.Parameters.iconName);
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(icon, EffectHelper.ModHelper.Translation.Get("SetBonusTitle") + this.CheckForTranslation(this.Parameters.setBonus) + ": " + x.Text)).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00004F89 File Offset: 0x00003189
		public SetBonusDesc(string setBonus, string iconName, IEffect actualEffect) : base(SetBonusDescParameters.With(setBonus, iconName, actualEffect))
		{
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x00004F99 File Offset: 0x00003199
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00004FA2 File Offset: 0x000031A2
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = null;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000128DC File Offset: 0x00010ADC
		private EffectIcon iconFromName(string name)
		{
			if (name == "Popularity")
			{
				return EffectIcon.Popularity;
			}
			if (name == "Attack")
			{
				return EffectIcon.Attack;
			}
			if (name == "Defense")
			{
				return EffectIcon.Defense;
			}
			if (name == "CriticalHitRate")
			{
				return EffectIcon.CriticalHitRate;
			}
			if (name == "Immunity")
			{
				return EffectIcon.Immunity;
			}
			if (name == "Speed")
			{
				return EffectIcon.Speed;
			}
			if (name == "SaveFromDeath")
			{
				return EffectIcon.SaveFromDeath;
			}
			if (name == "Yoba")
			{
				return EffectIcon.Yoba;
			}
			if (name == "TreasureChest")
			{
				return EffectIcon.TreasureChest;
			}
			if (name == "Chicken")
			{
				return EffectIcon.Animal_Chicken;
			}
			if (name == "Cow")
			{
				return EffectIcon.Animal_Cow;
			}
			if (name == "Glow")
			{
				return EffectIcon.Glow;
			}
			if (name == "Money")
			{
				return EffectIcon.Money;
			}
			if (name == "Red")
			{
				return EffectIcon.Red2;
			}
			if (name == "Blue")
			{
				return EffectIcon.Blue;
			}
			if (name == "Yellow")
			{
				return EffectIcon.Yellow;
			}
			if (name == "Lewis")
			{
				return EffectIcon.Person_Lewis;
			}
			if (name == "Fire")
			{
				return EffectIcon.Fire;
			}
			if (name == "Crown")
			{
				return EffectIcon.Crown;
			}
			if (name == "Iridium")
			{
				return EffectIcon.Iridium;
			}
			if (name == "DustSprite")
			{
				return EffectIcon.DustSprite;
			}
			if (name == "Stardrop")
			{
				return EffectIcon.Stardrop;
			}
			if (name == "Crab")
			{
				return EffectIcon.Crab;
			}
			if (name == "CandyCane")
			{
				return EffectIcon.CandyCane;
			}
			if (name == "Pumpkin")
			{
				return EffectIcon.Pumpkin;
			}
			if (name == "Heart")
			{
				return EffectIcon.Heart;
			}
			if (name == "Swirl")
			{
				return EffectIcon.Swirl;
			}
			if (name == "Lightning")
			{
				return EffectIcon.Lightning;
			}
			if (name == "Clover")
			{
				return EffectIcon.Clover;
			}
			if (name == "Dwarf")
			{
				return EffectIcon.Dwarf;
			}
			if (name == "Krobus")
			{
				return EffectIcon.Krobus;
			}
			return EffectIcon.Stardrop;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x00012AD8 File Offset: 0x00010CD8
		private string CheckForTranslation(string s)
		{
			if (s == "Diggy Diggy:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus1");
			}
			if (s == "Eonic Tribute:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus2");
			}
			if (s == "Ruler of Infinity:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus3");
			}
			if (s == "Miderian Finale:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus4");
			}
			if (s == "Spook:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus5");
			}
			if (s == "Truly Magic:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus6");
			}
			if (s == "Eclipse:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus7");
			}
			if (s == "Hidden Treasure:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus8");
			}
			if (s == "Street Smarts:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus9");
			}
			if (s == "Decorated Past:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus10");
			}
			if (s == "Vigil Ascension:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus11");
			}
			if (s == "No Will To Break:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus12");
			}
			if (s == "Jolly:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus13");
			}
			if (s == "Running River:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus14");
			}
			if (s == "Siren:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus15");
			}
			if (s == "Michelin Star:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus16");
			}
			if (s == "Season of Luck:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus17");
			}
			if (s == "Prairie Friend:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus18");
			}
			if (s == "Salem's Fallout:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus19");
			}
			if (s == "Why Go Alone?:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus20");
			}
			if (s == "Clown Around:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus21");
			}
			if (s == "Wild:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus22");
			}
			if (s == "One WIth Nature:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus23");
			}
			if (s == "Squawk Proud:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus24");
			}
			if (s == "Top TopHat:")
			{
				return EffectHelper.ModHelper.Translation.Get("SetBonus25");
			}
			return s;
		}

		// Token: 0x040002DD RID: 733
		private List<EffectDescriptionLine> effectDescription;
	}
}
