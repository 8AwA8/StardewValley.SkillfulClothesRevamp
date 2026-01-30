using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SkillfulClothes.Types
{
	// Token: 0x02000026 RID: 38
	public static class KnownPants
	{
		// Token: 0x060000FA RID: 250 RVA: 0x00007DD0 File Offset: 0x00005FD0
		static KnownPants()
		{
			foreach (FieldInfo field in from x in typeof(KnownPants).GetFields(BindingFlags.Static | BindingFlags.Public)
			where x.FieldType == typeof(Pants)
			select x)
			{
				Pants pants = field.GetValue(null) as Pants;
				pants.ItemName = field.Name;
				KnownPants.lut_ids.Add(pants.ItemId, pants);
				KnownPants.lut_names.Add(pants.ItemName, pants);
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00007F68 File Offset: 0x00006168
		public static Pants GetById(string itemId)
		{
			if (itemId == null)
			{
				return KnownPants.None;
			}
			Pants knownPants;
			if (KnownPants.lut_ids.TryGetValue(itemId, out knownPants) || KnownPants.lut_names.TryGetValue(itemId, out knownPants))
			{
				return knownPants;
			}
			return new Pants(itemId)
			{
				ItemName = itemId
			};
		}

		// Token: 0x040000C6 RID: 198
		public static Pants None = -1;

		// Token: 0x040000C7 RID: 199
		public static Pants FarmerPants = 0;

		// Token: 0x040000C8 RID: 200
		public static Pants Shorts = 1;

		// Token: 0x040000C9 RID: 201
		public static Pants Dress = 2;

		// Token: 0x040000CA RID: 202
		public static Pants Skirt = 3;

		// Token: 0x040000CB RID: 203
		public static Pants PleatedSkirt = 4;

		// Token: 0x040000CC RID: 204
		public static Pants DinosaurPants = 5;

		// Token: 0x040000CD RID: 205
		public static Pants GrassSkirt = 6;

		// Token: 0x040000CE RID: 206
		public static Pants LuauSkirt = 7;

		// Token: 0x040000CF RID: 207
		public static Pants GeniePants = 8;

		// Token: 0x040000D0 RID: 208
		public static Pants TightPants = 9;

		// Token: 0x040000D1 RID: 209
		public static Pants BaggyPants = 10;

		// Token: 0x040000D2 RID: 210
		public static Pants SimpleDress = 11;

		// Token: 0x040000D3 RID: 211
		public static Pants RelaxedFitPants = 12;

		// Token: 0x040000D4 RID: 212
		public static Pants RelaxedFitShorts = 13;

		// Token: 0x040000D5 RID: 213
		public static Pants PolkaDotShorts = 14;

		// Token: 0x040000D6 RID: 214
		public static Pants TrimmedLuckyPurpleShorts = 15;

		// Token: 0x040000D7 RID: 215
		public static Pants PrismaticPants = 998;

		// Token: 0x040000D8 RID: 216
		public static Pants PrismaticGeniePants = 999;

		// Token: 0x040000D9 RID: 217
		private static Dictionary<string, Pants> lut_ids = new Dictionary<string, Pants>();

		// Token: 0x040000DA RID: 218
		private static Dictionary<string, Pants> lut_names = new Dictionary<string, Pants>();
	}
}
