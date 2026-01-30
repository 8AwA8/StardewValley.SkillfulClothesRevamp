using System;
using HarmonyLib;
using SkillfulClothes.Types;
using SkillfulClothes.Configuration;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000C4 RID: 196
	internal class MysteryBoost : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000488 RID: 1160 RVA: 0x0000555A File Offset: 0x0000375A
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillLuck, EffectHelper.ModHelper.Translation.Get("Spec-Mystery"));
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000031B2 File Offset: 0x000013B2
		public MysteryBoost() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00016B38 File Offset: 0x00014D38
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			new Harmony(EffectHelper.ModHelper.ModContent.ModID).Patch(AccessTools.Method(typeof(Utility), "tryRollMysteryBox", null, null), null, new HarmonyMethod(typeof(MysteryBoost), "MysteryBoxCheck", null), null, null);
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000557C File Offset: 0x0000377C
		public static void MysteryBoxCheck(double baseChance, bool __result, Random r = null)
		{
			if (__result || Game1.random.NextDouble() < 0.33 * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? 1f/EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f))
			{
				return;
			}
			__result = Utility.tryRollMysteryBox(baseChance, r);
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x000055A0 File Offset: 0x000037A0
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			new Harmony(EffectHelper.ModHelper.ModContent.ModID).Unpatch(AccessTools.Method(typeof(Utility), "tryRollMysteryBox", null, null), (HarmonyPatchType)2, "*");
		}
	}
}
