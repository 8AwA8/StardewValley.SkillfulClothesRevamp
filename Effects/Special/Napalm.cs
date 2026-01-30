using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000088 RID: 136
	internal class Napalm : SingleEffect<NapalmParameters>
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00004257 File Offset: 0x00002457
		// (set) Token: 0x06000309 RID: 777 RVA: 0x0000425F File Offset: 0x0000245F
		private Item SourceItem { get; set; }

		// Token: 0x0600030A RID: 778 RVA: 0x00004268 File Offset: 0x00002468
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.MaxHealth, EffectHelper.ModHelper.Translation.Get("Spec-Napalm"));
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00004289 File Offset: 0x00002489
		public Napalm(NapalmParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000429D File Offset: 0x0000249D
		public Napalm(int damage) : base(NapalmParameters.With(damage))
		{
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000DE88 File Offset: 0x0000C088
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			EffectHelper.ModHelper.Events.World.NpcListChanged += this.Events_UpdateTicking;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000042B6 File Offset: 0x000024B6
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.World.NpcListChanged -= this.Events_UpdateTicking;
			this.SourceItem = null;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000DEF8 File Offset: 0x0000C0F8
		private void Events_UpdateTicking(object sender, NpcListChangedEventArgs e)
		{
			if (!e.IsCurrentLocation)
			{
				return;
			}
			if (this.monstersSlain.Value < (int)Game1.player.stats.MonstersKilled)
			{
				if (!EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableEffectSFX)
				{
					Game1.player.playNearbySoundLocal("explosion", null, 0);
				}
				Game1.currentLocation.explode(Game1.player.Tile, 2 + Game1.player.Attack / 6, Game1.player, false, base.Parameters.ExtraDamage, true);
				this.monstersSlain.Value = (int)Game1.player.stats.MonstersKilled;
			}
		}

		// Token: 0x04000292 RID: 658
		private PerScreen<int> monstersSlain = new PerScreen<int>();
	}
}
