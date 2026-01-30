using System;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004C RID: 76
	internal class LewisDisapprovesEffect : SingleEffect<NoEffectParameters>
	{
		// Token: 0x0600018F RID: 399 RVA: 0x000031B2 File Offset: 0x000013B2
		public LewisDisapprovesEffect() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x06000190 RID: 400 RVA: 0x00003247 File Offset: 0x00001447
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.InteractedWithNPC -= this.Events_InteractedWithNPC;
			EffectHelper.Events.InteractedWithNPC += this.Events_InteractedWithNPC;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00003275 File Offset: 0x00001475
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.Events.InteractedWithNPC -= this.Events_InteractedWithNPC;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		private void Events_InteractedWithNPC(object sender, InteractedWithNPCEventArgs e)
		{
			if (e.Npc.id == 17)
			{
				Game1.addHUDMessage(new HUDMessage(EffectHelper.ModHelper.Translation.Get("Spec-LewHUD")));
				Game1.player.changeFriendship(-10, e.Npc);
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000328D File Offset: 0x0000148D
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Person_Lewis, EffectHelper.ModHelper.Translation.Get("Spec-Lew"));
		}

		// Token: 0x0400022B RID: 555
		private const int LewisNpcId = 17;
	}
}
