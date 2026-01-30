using System;
using System.Collections.Generic;
using SkillfulClothes.Types;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B8 RID: 184
	internal class PetAnimalsOnTouch : SingleEffect<NoEffectParameters>
	{
		// Token: 0x06000449 RID: 1097 RVA: 0x000031B2 File Offset: 0x000013B2
		public PetAnimalsOnTouch() : base(NoEffectParameters.Default)
		{
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00015FF8 File Offset: 0x000141F8
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.GameLoop_UpdateTicked;
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking += this.GameLoop_UpdateTicked;
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x0000523E File Offset: 0x0000343E
		private bool canPet(FarmAnimal animal)
		{
			return Game1.timeOfDay < 1900 && !animal.wasPet.Value;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00016048 File Offset: 0x00014248
		private void CheckPetAnimal(GameLocation location, Farmer who)
		{
			foreach (KeyValuePair<long, FarmAnimal> keyValuePair in location.Animals.Pairs)
			{
				FarmAnimal value = keyValuePair.Value;
				if (this.canPet(value) && value.Tile.X - who.Tile.X <= 3f && value.Tile.Y - who.Tile.Y <= 3f && value.Tile.X - who.Tile.X >= -3f && value.Tile.Y - who.Tile.Y >= -3f)
				{
					value.pet(who, false);
				}
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x0000525C File Offset: 0x0000345C
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.OneSecondUpdateTicking -= this.GameLoop_UpdateTicked;
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x0000527E File Offset: 0x0000347E
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Animal_Cow, EffectHelper.ModHelper.Translation.Get("Animal-Any"));
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000052A0 File Offset: 0x000034A0
		private void GameLoop_UpdateTicked(object sender, OneSecondUpdateTickingEventArgs e)
		{
			if (!Context.IsPlayerFree || Game1.timeOfDay >= 1900)
			{
				return;
			}
			this.CheckPetAnimal(Game1.currentLocation, Game1.player);
		}
	}
}
