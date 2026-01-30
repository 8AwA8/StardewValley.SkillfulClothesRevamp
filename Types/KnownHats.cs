using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SkillfulClothes.Types
{
	// Token: 0x02000020 RID: 32
	public static class KnownHats
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x0000733C File Offset: 0x0000553C
		static KnownHats()
		{
			foreach (FieldInfo field in from x in typeof(KnownHats).GetFields(BindingFlags.Static | BindingFlags.Public)
			where x.FieldType == typeof(Hat)
			select x)
			{
				Hat hat = field.GetValue(null) as Hat;
				hat.ItemName = field.Name;
				KnownHats.lut_ids.Add(hat.ItemId, hat);
				KnownHats.lut_names.Add(hat.ItemName, hat);
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000785C File Offset: 0x00005A5C
		public static Hat GetById(string itemId)
		{
			if (itemId == null)
			{
				return KnownHats.None;
			}
			Hat knownHat;
			if (KnownHats.lut_ids.TryGetValue(itemId, out knownHat) || KnownHats.lut_names.TryGetValue(itemId, out knownHat))
			{
				return knownHat;
			}
			return new Hat(itemId)
			{
				ItemName = itemId
			};
		}

		// Token: 0x04000054 RID: 84
		public static Hat None = -1;

		// Token: 0x04000055 RID: 85
		public static Hat CowboyHat = 0;

		// Token: 0x04000056 RID: 86
		public static Hat BowlerHat = 1;

		// Token: 0x04000057 RID: 87
		public static Hat TopHat = 2;

		// Token: 0x04000058 RID: 88
		public static Hat Sombrero = 3;

		// Token: 0x04000059 RID: 89
		public static Hat StrawHat = 4;

		// Token: 0x0400005A RID: 90
		public static Hat OfficialCap = 5;

		// Token: 0x0400005B RID: 91
		public static Hat BlueBonnet = 6;

		// Token: 0x0400005C RID: 92
		public static Hat PlumChapeau = 7;

		// Token: 0x0400005D RID: 93
		public static Hat SkeletonMask = 8;

		// Token: 0x0400005E RID: 94
		public static Hat GoblinMask = 9;

		// Token: 0x0400005F RID: 95
		public static Hat ChickenMask = 10;

		// Token: 0x04000060 RID: 96
		public static Hat Earmuffs = 11;

		// Token: 0x04000061 RID: 97
		public static Hat DelicateBow = 12;

		// Token: 0x04000062 RID: 98
		public static Hat Tropiclip = 13;

		// Token: 0x04000063 RID: 99
		public static Hat ButterflyBow = 14;

		// Token: 0x04000064 RID: 100
		public static Hat HuntersCap = 15;

		// Token: 0x04000065 RID: 101
		public static Hat TruckerHat = 16;

		// Token: 0x04000066 RID: 102
		public static Hat SailorsCap = 17;

		// Token: 0x04000067 RID: 103
		public static Hat GoodOlCap = 18;

		// Token: 0x04000068 RID: 104
		public static Hat Fedora = 19;

		// Token: 0x04000069 RID: 105
		public static Hat CoolCap = 20;

		// Token: 0x0400006A RID: 106
		public static Hat LuckyBow = 21;

		// Token: 0x0400006B RID: 107
		public static Hat PolkaBow = 22;

		// Token: 0x0400006C RID: 108
		public static Hat GnomesCap = 23;

		// Token: 0x0400006D RID: 109
		public static Hat EyePatch = 24;

		// Token: 0x0400006E RID: 110
		public static Hat SantaHat = 25;

		// Token: 0x0400006F RID: 111
		public static Hat Tiara = 26;

		// Token: 0x04000070 RID: 112
		public static Hat HardHat = 27;

		// Token: 0x04000071 RID: 113
		public static Hat Souwester = 28;

		// Token: 0x04000072 RID: 114
		public static Hat Daisy = 29;

		// Token: 0x04000073 RID: 115
		public static Hat WatermelonBand = 30;

		// Token: 0x04000074 RID: 116
		public static Hat MouseEars = 31;

		// Token: 0x04000075 RID: 117
		public static Hat CatEars = 32;

		// Token: 0x04000076 RID: 118
		public static Hat CowgalHat = 33;

		// Token: 0x04000077 RID: 119
		public static Hat CowpokeHat = 34;

		// Token: 0x04000078 RID: 120
		public static Hat ArchersCap = 35;

		// Token: 0x04000079 RID: 121
		public static Hat PandaHat = 36;

		// Token: 0x0400007A RID: 122
		public static Hat BlueCowboyHat = 37;

		// Token: 0x0400007B RID: 123
		public static Hat RedCowboyHat = 38;

		// Token: 0x0400007C RID: 124
		public static Hat ConeHat = 39;

		// Token: 0x0400007D RID: 125
		public static Hat LivingHat = 40;

		// Token: 0x0400007E RID: 126
		public static Hat EmilysMagicHat = 41;

		// Token: 0x0400007F RID: 127
		public static Hat MushroomCap = 42;

		// Token: 0x04000080 RID: 128
		public static Hat DinosaurHat = 43;

		// Token: 0x04000081 RID: 129
		public static Hat TotemMask = 44;

		// Token: 0x04000082 RID: 130
		public static Hat LogoCap = 45;

		// Token: 0x04000083 RID: 131
		public static Hat WearableDwarfHelm = 46;

		// Token: 0x04000084 RID: 132
		public static Hat FashionHat = 47;

		// Token: 0x04000085 RID: 133
		public static Hat PumpkinMask = 48;

		// Token: 0x04000086 RID: 134
		public static Hat HairBone = 49;

		// Token: 0x04000087 RID: 135
		public static Hat KnightsHelmet = 50;

		// Token: 0x04000088 RID: 136
		public static Hat SquiresHelmet = 51;

		// Token: 0x04000089 RID: 137
		public static Hat SpottedHeadscarf = 52;

		// Token: 0x0400008A RID: 138
		public static Hat Beanie = 53;

		// Token: 0x0400008B RID: 139
		public static Hat FloppyBeanie = 54;

		// Token: 0x0400008C RID: 140
		public static Hat FishingHat = 55;

		// Token: 0x0400008D RID: 141
		public static Hat BlobfishMask = 56;

		// Token: 0x0400008E RID: 142
		public static Hat PartyHat_Red = 57;

		// Token: 0x0400008F RID: 143
		public static Hat PartyHat_Blue = 58;

		// Token: 0x04000090 RID: 144
		public static Hat PartyHat_Green = 59;

		// Token: 0x04000091 RID: 145
		public static Hat ArcaneHat = 60;

		// Token: 0x04000092 RID: 146
		public static Hat ChefHat = 61;

		// Token: 0x04000093 RID: 147
		public static Hat PirateHat = 62;

		// Token: 0x04000094 RID: 148
		public static Hat FlatToppedHat = 63;

		// Token: 0x04000095 RID: 149
		public static Hat ElegantTurban = 64;

		// Token: 0x04000096 RID: 150
		public static Hat WhiteTurban = 65;

		// Token: 0x04000097 RID: 151
		public static Hat GarbageHat = 66;

		// Token: 0x04000098 RID: 152
		public static Hat GoldenMask = 67;

		// Token: 0x04000099 RID: 153
		public static Hat PropellerHat = 68;

		// Token: 0x0400009A RID: 154
		public static Hat BridalVeil = 69;

		// Token: 0x0400009B RID: 155
		public static Hat WitchHat = 70;

		// Token: 0x0400009C RID: 156
		public static Hat CopperPan = 71;

		// Token: 0x0400009D RID: 157
		public static Hat GreenTurban = 72;

		// Token: 0x0400009E RID: 158
		public static Hat MagicCowboyHat = 73;

		// Token: 0x0400009F RID: 159
		public static Hat MagicTurban = 74;

		// Token: 0x040000A0 RID: 160
		public static Hat GoldenHelmet = 75;

		// Token: 0x040000A1 RID: 161
		public static Hat DeluxePirateHat = 76;

		// Token: 0x040000A2 RID: 162
		public static Hat PinkBow = 77;

		// Token: 0x040000A3 RID: 163
		public static Hat FrogHat = 78;

		// Token: 0x040000A4 RID: 164
		public static Hat SmallCap = 79;

		// Token: 0x040000A5 RID: 165
		public static Hat BluebirdMask = 80;

		// Token: 0x040000A6 RID: 166
		public static Hat DeluxeCowboyHat = 81;

		// Token: 0x040000A7 RID: 167
		public static Hat MrQisHat = 82;

		// Token: 0x040000A8 RID: 168
		public static Hat DarkCowboyHat = 83;

		// Token: 0x040000A9 RID: 169
		public static Hat RadioactiveGoggles = 84;

		// Token: 0x040000AA RID: 170
		public static Hat SwashbucklerHat = 85;

		// Token: 0x040000AB RID: 171
		public static Hat QiMask = 86;

		// Token: 0x040000AC RID: 172
		public static Hat StarHelmet = 87;

		// Token: 0x040000AD RID: 173
		public static Hat Sunglasses = 88;

		// Token: 0x040000AE RID: 174
		public static Hat Goggles = 89;

		// Token: 0x040000AF RID: 175
		public static Hat ForagersHat = 90;

		// Token: 0x040000B0 RID: 176
		public static Hat TigerHat = 91;

		// Token: 0x040000B1 RID: 177
		public static Hat ThreeQuestionMarks = 92;

		// Token: 0x040000B2 RID: 178
		public static Hat WarriorHelmet = 93;

		// Token: 0x040000B3 RID: 179
		private static Dictionary<string, Hat> lut_ids = new Dictionary<string, Hat>();

		// Token: 0x040000B4 RID: 180
		private static Dictionary<string, Hat> lut_names = new Dictionary<string, Hat>();
	}
}
