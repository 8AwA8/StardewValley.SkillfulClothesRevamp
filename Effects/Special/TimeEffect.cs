using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009F RID: 159
	internal class TimeEffect : SingleEffect<TimeEffectParameters>
	{
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00004B1A File Offset: 0x00002D1A
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				return this.effectDescription;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00004B22 File Offset: 0x00002D22
		// (set) Token: 0x0600039E RID: 926 RVA: 0x00004B2A File Offset: 0x00002D2A
		private Item SourceItem { get; set; }

		// Token: 0x0600039F RID: 927 RVA: 0x00003C50 File Offset: 0x00001E50
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return null;
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x00004B33 File Offset: 0x00002D33
		public override void ReloadParameters()
		{
			this.effectDescription = (from x in base.Parameters.Effect.EffectDescription
			select new EffectDescriptionLine(x.Icon, x.Text + this.TimeText())).ToList<EffectDescriptionLine>();
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x00004B61 File Offset: 0x00002D61
		public TimeEffect(TimeEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00004B75 File Offset: 0x00002D75
		public TimeEffect(int timeStart, int timeEnd, IEffect actualEffect) : base(TimeEffectParameters.With(timeStart, timeEnd, actualEffect))
		{
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00011A24 File Offset: 0x0000FC24
		private string TimeText()
		{
			string text = EffectHelper.ModHelper.Translation.Get("Spec-Time4");
			if (base.Parameters.timeStart > 1800)
			{
				text = text + (base.Parameters.timeStart - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeStart < 300)
			{
				text = text + base.Parameters.timeStart.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeStart > 200 && base.Parameters.timeStart < 1200)
			{
				text = text + base.Parameters.timeStart.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time2");
			}
			else if (base.Parameters.timeStart >= 1200 && base.Parameters.timeStart < 1300)
			{
				text = text + base.Parameters.timeStart.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			else if (base.Parameters.timeStart >= 1300 && base.Parameters.timeStart < 1900)
			{
				text = text + (base.Parameters.timeStart - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			text += EffectHelper.ModHelper.Translation.Get("Spec-Time5");
			if (base.Parameters.timeEnd > 1800)
			{
				text = text + (base.Parameters.timeEnd - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeEnd < 300)
			{
				text = text + base.Parameters.timeEnd.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time1");
			}
			else if (base.Parameters.timeEnd > 200 && base.Parameters.timeEnd < 1200)
			{
				text = text + base.Parameters.timeEnd.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time2");
			}
			else if (base.Parameters.timeEnd >= 1200 && base.Parameters.timeEnd < 1300)
			{
				text = text + base.Parameters.timeEnd.ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			else if (base.Parameters.timeEnd >= 1300 && base.Parameters.timeEnd < 1900)
			{
				text = text + (base.Parameters.timeEnd - 1200).ToString() + EffectHelper.ModHelper.Translation.Get("Spec-Time3");
			}
			return text.Replace("00", "");
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00011DD4 File Offset: 0x0000FFD4
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			this.isApplied.Value = false;
			this.RevalidateConditions(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_TimeChanged;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.Events_TimeChanged;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00004B90 File Offset: 0x00002D90
		private void Events_TimeChanged(object sender, TimeChangedEventArgs e)
		{
			this.RevalidateConditions(this.SourceItem, EffectChangeReason.Reset);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x00004B9F File Offset: 0x00002D9F
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			base.Parameters.Effect.Remove(sourceItem, reason);
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.Events_TimeChanged;
			this.SourceItem = null;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x00011E3C File Offset: 0x0001003C
		private void RevalidateConditions(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.timeEnd >= Game1.timeOfDay && base.Parameters.timeStart <= Game1.timeOfDay)
			{
				if (!this.isApplied.Value)
				{
					if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
					{
						Game1.addHUDMessage(new CustomHUDMessage(EffectHelper.ModHelper.Translation.Get("Base-EFXB") + this.SourceItem.DisplayName + EffectHelper.ModHelper.Translation.Get("Base-Active"), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
					}
					this.isApplied.Value = true;
					base.Parameters.Effect.Apply(sourceItem, reason);
					return;
				}
			}
			else if (this.isApplied.Value)
			{
				if (this.SourceItem != null && reason == EffectChangeReason.Reset && !EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().DisableWhenActiveAlerts)
				{
					Game1.addHUDMessage(new CustomHUDMessage(EffectHelper.ModHelper.Translation.Get("Base-EFXB") + this.SourceItem.DisplayName + EffectHelper.ModHelper.Translation.Get("Base-Wore"), this.SourceItem, Color.White, TimeSpan.FromSeconds(5.0)));
				}
				this.isApplied.Value = false;
				base.Parameters.Effect.Remove(sourceItem, reason);
			}
		}

		// Token: 0x040002C1 RID: 705
		private List<EffectDescriptionLine> effectDescription;

		// Token: 0x040002C2 RID: 706
		private PerScreen<bool> isApplied = new PerScreen<bool>();
	}
}
