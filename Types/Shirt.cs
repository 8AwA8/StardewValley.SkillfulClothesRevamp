using System;

namespace SkillfulClothes.Types
{
	// Token: 0x0200002C RID: 44
	public class Shirt : AlphanumericItemId
	{
		// Token: 0x06000109 RID: 265 RVA: 0x00002CEB File Offset: 0x00000EEB
		public Shirt(string itemId) : base(itemId, ClothingItemType.Shirt)
		{
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00002CF5 File Offset: 0x00000EF5
		public static implicit operator Shirt(int value)
		{
			return new Shirt(value.ToString());
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00002D03 File Offset: 0x00000F03
		public static implicit operator Shirt(string value)
		{
			return new Shirt(value);
		}
	}
}
