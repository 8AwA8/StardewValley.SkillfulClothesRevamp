using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009D RID: 157
	internal class NPCEffect : SingleEffect<NPCEffectParameters>
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00004A24 File Offset: 0x00002C24
		// (set) Token: 0x0600038D RID: 909 RVA: 0x00004A2C File Offset: 0x00002C2C
		private Item SourceItem { get; set; }

		// Token: 0x0600038E RID: 910 RVA: 0x00011498 File Offset: 0x0000F698
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			if (base.Parameters.type == 0)
			{
				return new EffectDescriptionLine(EffectIcon.Popularity, string.Concat(new string[]
				{
					EffectHelper.ModHelper.Translation.Get("NPC-1"),
					base.Parameters.NPC,
					EffectHelper.ModHelper.Translation.Get("NPC-2"),
					((int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f))).ToString(),
					EffectHelper.ModHelper.Translation.Get("NPC-3")
				}));
			}
			if (base.Parameters.type == 1)
			{
				return new EffectDescriptionLine(EffectIcon.Energy, string.Concat(new string[]
				{
					EffectHelper.ModHelper.Translation.Get("NPC-1"),
					base.Parameters.NPC,
					EffectHelper.ModHelper.Translation.Get("NPC-2"),
					((int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f))).ToString(),
					EffectHelper.ModHelper.Translation.Get("NPC-4")
				}));
			}
			if (base.Parameters.type == 2)
			{
				return new EffectDescriptionLine(EffectIcon.Health, string.Concat(new string[]
				{
					EffectHelper.ModHelper.Translation.Get("NPC-1"),
					base.Parameters.NPC,
					EffectHelper.ModHelper.Translation.Get("NPC-2"),
					((int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f))).ToString(),
					EffectHelper.ModHelper.Translation.Get("NPC-5")
				}));
			}
			if (base.Parameters.type == 3)
			{
				return new EffectDescriptionLine(EffectIcon.Red, string.Concat(new string[]
				{
					EffectHelper.ModHelper.Translation.Get("NPC-1"),
					base.Parameters.NPC,
					EffectHelper.ModHelper.Translation.Get("NPC-2"),
					((int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f))).ToString(),
					EffectHelper.ModHelper.Translation.Get("NPC-6")
				}));
			}
			return new EffectDescriptionLine(EffectIcon.SaveFromDeath, EffectHelper.ModHelper.Translation.Get("NPC-7"));
		}

		// Token: 0x0600038F RID: 911 RVA: 0x00004A35 File Offset: 0x00002C35
		public NPCEffect(NPCEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000390 RID: 912 RVA: 0x00004A49 File Offset: 0x00002C49
		public NPCEffect(string NPC, int amount, int type) : base(NPCEffectParameters.With(NPC, amount, type))
		{
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00004A64 File Offset: 0x00002C64
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			EffectHelper.Events.InteractedWithNPC -= this.Events_UpdateTicking;
			EffectHelper.Events.InteractedWithNPC += this.Events_UpdateTicking;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00004A99 File Offset: 0x00002C99
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.InteractedWithNPC -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x000117DC File Offset: 0x0000F9DC
		private void Events_UpdateTicking(object sender, InteractedWithNPCEventArgs e)
		{
			if (!(e.Npc.displayName.ToLower() == base.Parameters.NPC.ToLower()) || this.day.Value == Game1.dayOfMonth)
			{
				return;
			}
			this.day.Value = Game1.dayOfMonth;
			switch (base.Parameters.type)
			{
			case 0:
				Game1.player.changeFriendship((int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), e.Npc);
				e.Npc.doEmote((base.Parameters.amount > 0) ? 32 : 12, true);
				return;
			case 1:
				Game1.player.stamina = Math.Min(Game1.player.stamina + (float)((int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f))), (float)Game1.player.MaxStamina);
				e.Npc.doEmote((base.Parameters.amount > 0) ? 32 : 12, true);
				return;
			case 2:
				Game1.player.health = Math.Min(Game1.player.health + (int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), Game1.player.maxHealth);
				e.Npc.doEmote((base.Parameters.amount > 0) ? 32 : 12, true);
				return;
			case 3:
				Game1.player.Money = Math.Max(Game1.player.Money + (int)((float)base.Parameters.amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)), 0);
				e.Npc.doEmote((base.Parameters.amount > 0) ? 32 : 12, true);
				return;
			default:
				return;
			}
		}

		// Token: 0x040002BC RID: 700
		private PerScreen<int> day = new PerScreen<int>();
	}
}
