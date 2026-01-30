using System;
using System.Collections.Generic;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000099 RID: 153
	internal class CrafterPower : SingleEffect<CrafterParameters>
	{
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000373 RID: 883 RVA: 0x000048BE File Offset: 0x00002ABE
		// (set) Token: 0x06000374 RID: 884 RVA: 0x000048C6 File Offset: 0x00002AC6
		private Item SourceItem { get; set; }

		// Token: 0x06000375 RID: 885 RVA: 0x000048CF File Offset: 0x00002ACF
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.SkillCombat, EffectHelper.ModHelper.Translation.Get("Spec-Crafter"));
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000048F1 File Offset: 0x00002AF1
		public CrafterPower(CrafterParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000377 RID: 887 RVA: 0x000048FA File Offset: 0x00002AFA
		public CrafterPower(IEffect actualEffect) : base(CrafterParameters.With(actualEffect))
		{
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00004908 File Offset: 0x00002B08
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.RevalidateConditions(sourceItem, reason);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00004919 File Offset: 0x00002B19
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			this.SourceItem = null;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x000107C0 File Offset: 0x0000E9C0
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			Dictionary<string, string> dictionary = DataLoader.CraftingRecipes(Game1.content);
			float num = 0f;
			float num2 = EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f;
			foreach (string text in dictionary.Keys)
			{
				int num3 = 0;
				if (!(text == "Wedding Ring") && Game1.player.craftingRecipes.TryGetValue(text, out num3) && Game1.player.craftingRecipes[text] > 0)
				{
					num += num2;
				}
			}
			num = Math.Min(num / 200f, 80f);
			ShopDiscount shopDiscount = new ShopDiscount(Shop.Robin, (double)num);
			if (shopDiscount.Parameters.Discount > 80.0)
			{
				shopDiscount.Parameters.Discount = 80.0;
			}
			base.Parameters.Effect = shopDiscount;
			base.Parameters.Effect.Apply(sourceItem, reason);
		}
	}
}
