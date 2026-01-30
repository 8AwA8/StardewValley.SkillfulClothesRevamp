using System;

namespace SkillfulClothes.Types
{
	// Token: 0x02000028 RID: 40
	public class Pants : AlphanumericItemId
	{
		// Token: 0x060000FF RID: 255 RVA: 0x00002C4D File Offset: 0x00000E4D
		public Pants(string itemId) : base(itemId, ClothingItemType.Pants)
		{
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00002C57 File Offset: 0x00000E57
		public static implicit operator Pants(int value)
		{
			return new Pants(value.ToString());
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00002C65 File Offset: 0x00000E65
		public static implicit operator Pants(string value)
		{
			return new Pants(value);
		}
	}
}
