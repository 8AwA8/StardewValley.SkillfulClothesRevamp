using System;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Objects.Trinkets;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B3 RID: 179
	internal class TrinketEffect : SingleEffect<TrinketEffectParameters>
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x00004FF8 File Offset: 0x000031F8
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x00005000 File Offset: 0x00003200
		private Item SourceItem { get; set; }

		// Token: 0x0600041E RID: 1054 RVA: 0x0001540C File Offset: 0x0001360C
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.TreasureChest, EffectHelper.ModHelper.Translation.Get("Spec-BuffApply") + this.Name() + EffectHelper.ModHelper.Translation.Get("Spec-BuffEffect"));
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00005009 File Offset: 0x00003209
		public TrinketEffect(TrinketEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00005012 File Offset: 0x00003212
		public TrinketEffect(int Trinket) : base(TrinketEffectParameters.With(Trinket))
		{
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00015460 File Offset: 0x00013660
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			this.SourceItem = sourceItem;
			Trinket trinketFromTrinket = this.GetTrinketFromTrinket();
			trinketFromTrinket.Price = 1;
			trinketFromTrinket.price.Value = 1;
			Game1.player.trinketItems.Add(null);
			Game1.player.trinketItems.Add(null);
			Game1.player.trinketItems.Add(trinketFromTrinket);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000154C0 File Offset: 0x000136C0
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			for (int i = 2; i < Game1.player.trinketItems.Count; i++)
			{
				if (Game1.player.trinketItems[i] != null && this.IsSame(Game1.player.trinketItems[i]))
				{
					Game1.player.trinketItems.RemoveAt(i);
				}
			}
			this.SourceItem = null;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00015528 File Offset: 0x00013728
		private string Name()
		{
			if (base.Parameters.Trinket == 1)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket1");
			}
			if (base.Parameters.Trinket == 2)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket2");
			}
			if (base.Parameters.Trinket == 3)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket3");
			}
			if (base.Parameters.Trinket == 4)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket4");
			}
			if (base.Parameters.Trinket == 5)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket5");
			}
			if (base.Parameters.Trinket == 6)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket6");
			}
			if (base.Parameters.Trinket == 7)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket7");
			}
			if (base.Parameters.Trinket == 8)
			{
				return EffectHelper.ModHelper.Translation.Get("Trinket8");
			}
			if (base.Parameters.Trinket == 9)
			{
				return "Bat Effect";
			}
			if (base.Parameters.Trinket == 10)
			{
				return "Dust Spririt Effect";
			}
			if (base.Parameters.Trinket == 11)
			{
				return "Skull Effect";
			}
			if (base.Parameters.Trinket == 12)
			{
				return "Snek Effect";
			}
			if (base.Parameters.Trinket == 13)
			{
				return "Spider Effect";
			}
			if (base.Parameters.Trinket == 14)
			{
				return "Stick Effect";
			}
			return EffectHelper.ModHelper.Translation.Get("Animal-Unknown");
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0001570C File Offset: 0x0001390C
		public Trinket GetTrinketFromTrinket()
		{
			if (base.Parameters.Trinket == 1)
			{
				return new Trinket("MagicHairDye", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 2)
			{
				return new Trinket("FrogEgg", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 3)
			{
				return new Trinket("MagicQuiver", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 4)
			{
				return new Trinket("FairyBox", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 5)
			{
				return new Trinket("ParrotEgg", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 6)
			{
				return new Trinket("IceRod", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 7)
			{
				return new Trinket("IridiumSpur", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 8)
			{
				return new Trinket("BasiliskPaw", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 9)
			{
				return new Trinket("mushymato.SinisterServants_Bat", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 10)
			{
				return new Trinket("mushymato.SinisterServants_DustSpirit", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 11)
			{
				return new Trinket("mushymato.SinisterServants_Skull", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 12)
			{
				return new Trinket("mushymato.SinisterServants_Snek", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 13)
			{
				return new Trinket("mushymato.SinisterServants_Spider", Game1.random.Next(100));
			}
			if (base.Parameters.Trinket == 14)
			{
				return new Trinket("mushymato.SinisterServants_Stick", Game1.random.Next(100));
			}
			return new Trinket("ParrotEgg", Game1.random.Next(100));
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00005020 File Offset: 0x00003220
		private bool IsSame(Trinket a)
		{
			return a != null && a.ItemId == this.GetTrinketFromTrinket().ItemId;
		}
	}
}
