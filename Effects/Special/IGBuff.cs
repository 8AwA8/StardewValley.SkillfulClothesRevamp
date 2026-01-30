using System;
using System.Drawing;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A2 RID: 162
	internal class IGBuff : SingleEffect<IGBuffParameters>
	{
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x00004C17 File Offset: 0x00002E17
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x00004C1F File Offset: 0x00002E1F
		private Item SourceItem { get; set; }

		// Token: 0x060003B4 RID: 948 RVA: 0x00011FD4 File Offset: 0x000101D4
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			string str = EffectHelper.ModHelper.Translation.Get("Spec-BuffU");
			string buffId = base.Parameters.buffId;
			int num = 0;
			int.TryParse(buffId, out num);
			if (num == 17)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffT");
			}
			else if (num == 18)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffF");
			}
			else if (num == 25)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffN");
			}
			else if (num == 13)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffS");
			}
			else if (num == 26)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffD");
			}
			else if (num == 24)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffMM");
			}
			else if (num == 28)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffDI");
			}
			else if (num == 23)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffOOG");
			}
			else if (num == 12)
			{
				str = EffectHelper.ModHelper.Translation.Get("Spec-BuffB");
			}
			return new EffectDescriptionLine(EffectIcon.Immunity, EffectHelper.ModHelper.Translation.Get("Spec-BuffApply") + str + EffectHelper.ModHelper.Translation.Get("Spec-BuffEffect"));
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x00004C28 File Offset: 0x00002E28
		public IGBuff(IGBuffParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00004C3C File Offset: 0x00002E3C
		public IGBuff(string buffId) : base(IGBuffParameters.With(buffId))
		{
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00012188 File Offset: 0x00010388
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			Buff buff = new Buff(base.Parameters.buffId, EffectHelper.ModHelper.Translation.Get("Base-SCName"), null, -1, null, -1, null, new bool?(false), null, null);
			buff.millisecondsDuration = -2;
			buff.glow = Microsoft.Xna.Framework.Color.White;
			Game1.player.applyBuff(buff);
			this.isApplied.Value = true;
			this.SourceItem = sourceItem;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00004C55 File Offset: 0x00002E55
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			Game1.player.buffs.Remove(base.Parameters.buffId);
			this.isApplied.Value = false;
			this.SourceItem = null;
		}

		// Token: 0x040002C5 RID: 709
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
