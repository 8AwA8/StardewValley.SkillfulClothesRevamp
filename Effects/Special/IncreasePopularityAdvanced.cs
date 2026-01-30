using System;
using System.Collections.Generic;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B5 RID: 181
	internal class IncreasePopularityAdvanced : SingleEffect<IncreasePopularityParameters>
	{
		// Token: 0x0600042A RID: 1066 RVA: 0x0001593C File Offset: 0x00013B3C
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Popularity, EffectHelper.ModHelper.Translation.Get("Spec-Pop") + " (" + MathF.Round(1f + (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f, 4).ToString() + "x) ");
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000159C8 File Offset: 0x00013BC8
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SetUpFriendshipDictionary();
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged += this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000505C File Offset: 0x0000325C
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.TimeChanged -= this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000507E File Offset: 0x0000327E
		public IncreasePopularityAdvanced(IncreasePopularityParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00005092 File Offset: 0x00003292
		public IncreasePopularityAdvanced(int Amount) : base(IncreasePopularityParameters.With(Amount))
		{
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00015A1C File Offset: 0x00013C1C
		private void GameLoop_UpdateTicking(object sender, TimeChangedEventArgs e)
		{
			if (!this.currentPoints.IsActiveForScreen())
			{
				this.SetUpFriendshipDictionary();
			}
			foreach (string text in Game1.player.friendshipData.Keys)
			{
				Friendship friendship = Game1.player.friendshipData[text];
				int num;
				if (this.currentPoints.Value.TryGetValue(text, out num) && friendship.Points > num)
				{
					float num2 = (float)(friendship.Points - num) * ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)) / 100f;
					friendship.Points = (int)((float)friendship.Points + num2);
				}
				this.currentPoints.Value[text] = friendship.Points;
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00015B2C File Offset: 0x00013D2C
		private void SetUpFriendshipDictionary()
		{
			this.currentPoints.Value = new Dictionary<string, int>();
			foreach (string text in Game1.player.friendshipData.Keys)
			{
				this.currentPoints.Value.Add(text, Game1.player.friendshipData[text].Points);
			}
		}

		// Token: 0x040002EB RID: 747
		private PerScreen<Dictionary<string, int>> currentPoints = new PerScreen<Dictionary<string, int>>();
	}
}
