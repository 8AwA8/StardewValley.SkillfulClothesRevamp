using System;
using System.Reflection;
using HarmonyLib;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;
using StardewValley.Tools;

using Hat = StardewValley.Objects.Hat;

namespace SkillfulClothes.Patches
{
	// Token: 0x02000034 RID: 52
	internal class HarmonyPatches
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00002DF2 File Offset: 0x00000FF2
		private static Clothing ShimTrimmedLuckPurpleShorts
		{
			get
			{
				if (HarmonyPatches.shimTrimmedLuckPurpleShorts == null)
				{
					HarmonyPatches.shimTrimmedLuckPurpleShorts = new Clothing(KnownPants.TrimmedLuckyPurpleShorts.ItemId);
				}
				return HarmonyPatches.shimTrimmedLuckPurpleShorts;
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00009274 File Offset: 0x00007474
		public static void Apply(string modId)
		{
			Harmony harmony = new Harmony(modId);
			harmony.Patch(AccessTools.Method(typeof(Item), "getDescriptionWidth", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "getDescriptionWidth", null), null, null);
			harmony.Patch(typeof(IClickableMenu).GetMethod("drawToolTip", BindingFlags.Static | BindingFlags.Public), new HarmonyMethod(typeof(HarmonyPatches), "drawToolTip", null), null, null, null);
			harmony.Patch(AccessTools.Method(typeof(Farmer), "isWearingRing", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "isWearingRing", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(NPC), "checkAction", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "NPC_checkAction", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Farmer), "takeDamage", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "Farmer_TakeDamage", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Item), "onEquip", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "FarmTextureChanged", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Item), "onUnequip", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "FarmTextureChanged", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(Item), "onDetachedFromParent", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "FarmTextureChanged", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(MeleeWeapon), "doDefenseSwordFunction", null, null), null, new HarmonyMethod(typeof(HarmonyPatches), "AbilityUsed", null), null, null);
			harmony.Patch(AccessTools.Method(typeof(TailoringMenu), "_rightIngredientSpotClicked", null, null), new HarmonyMethod(typeof(ForgePatches), "CraftFix", null), null, null, null);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00009498 File Offset: 0x00007698
		private static void drawToolTip(ref Item hoveredItem)
		{
			if (hoveredItem != null && hoveredItem.Category == 0 && hoveredItem.QualifiedItemId == "(O)71")
			{
				hoveredItem = HarmonyPatches.ShimTrimmedLuckPurpleShorts;
			}
			IEffect effect;
			if (ItemDefinitions.GetEffect(hoveredItem, out effect))
			{
				Clothing clothing = hoveredItem as Clothing;
				if (clothing != null)
				{
					HarmonyPatches.clothingDrawWrapper.Assign(clothing, effect);
					hoveredItem = HarmonyPatches.clothingDrawWrapper;
					return;
				}
				Boots boots = hoveredItem as Boots;
				if (boots != null)
				{
					HarmonyPatches.shoesDrawWrapper.Assign(boots, effect);
					hoveredItem = HarmonyPatches.shoesDrawWrapper;
					return;
				}
				Hat hat = hoveredItem as Hat;
				if (hat != null)
				{
					HarmonyPatches.hatDrawWrapper.Assign(hat, effect);
					hoveredItem = HarmonyPatches.hatDrawWrapper;
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00009534 File Offset: 0x00007734
		private static int getDescriptionWidth(int __result, Item __instance)
		{
			IEffect effect;
			if (ItemDefinitions.GetEffect(__instance, out effect))
			{
				return Math.Max(__result, EffectHelper.getDescriptionWidth(effect));
			}
			return __result;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00002E14 File Offset: 0x00001014
		private static bool isWearingRing(bool __result, string itemId)
		{
			return __result || EffectHelper.ClothingObserver.HasRingEffect(itemId);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00002E26 File Offset: 0x00001026
		private static void NPC_checkAction(bool __result, NPC __instance)
		{
			if (__result)
			{
				EffectHelper.Events.RaiseInteractedWithNPC(__instance);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00002E56 File Offset: 0x00001056
		private static void Farmer_TakeDamage(Farmer __instance)
		{
			EffectHelper.Events.RaiseFarmerDamaged(__instance);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000955C File Offset: 0x0000775C
		private static void FarmTextureChanged(Item __instance)
		{
			if (__instance.TypeDefinitionId == "(H)" || __instance.TypeDefinitionId == "(S)" || __instance.TypeDefinitionId == "(P)" || __instance.TypeDefinitionId == "(B)")
			{
				EffectHelper.Events.RaiseClothingChanged();
				return;
			}
			EffectHelper.Events.RaiseEquipChange();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00002E63 File Offset: 0x00001063
		private static void AbilityUsed()
		{
			EffectHelper.Events.RaiseSpecialUsed();
		}

		// Token: 0x040001D4 RID: 468
		private static HatDrawWrapper hatDrawWrapper = new HatDrawWrapper();

		// Token: 0x040001D5 RID: 469
		private static ClothingDrawWrapper clothingDrawWrapper = new ClothingDrawWrapper();

		// Token: 0x040001D6 RID: 470
		private static FieldInfo craftStateFieldInfo;

		// Token: 0x040001D7 RID: 471
		private static FieldInfo craftDisplayedDescriptionFieldInfo;

		// Token: 0x040001D8 RID: 472
		private static Clothing shimTrimmedLuckPurpleShorts;

		// Token: 0x040001D9 RID: 473
		private static ShoesDrawWrapper shoesDrawWrapper = new ShoesDrawWrapper();
	}
}
