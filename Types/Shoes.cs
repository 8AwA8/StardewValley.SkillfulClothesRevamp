using System;

namespace SkillfulClothes.Types
{
	// Token: 0x020000BC RID: 188
	public class Shoes : AlphanumericItemId
	{
		// Token: 0x06000460 RID: 1120 RVA: 0x0000535C File Offset: 0x0000355C
		public Shoes(string itemId) : base(itemId, ClothingItemType.Shoes)
		{
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x00005366 File Offset: 0x00003566
		public static implicit operator Shoes(int value)
		{
			return new Shoes(value.ToString());
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00005374 File Offset: 0x00003574
		public static implicit operator Shoes(string value)
		{
			return new Shoes(value);
		}
	}
}
