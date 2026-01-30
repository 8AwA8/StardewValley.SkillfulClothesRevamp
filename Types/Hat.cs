using System;

namespace SkillfulClothes.Types
{
	// Token: 0x02000022 RID: 34
	public class Hat : AlphanumericItemId
	{
		// Token: 0x060000EC RID: 236 RVA: 0x00002B99 File Offset: 0x00000D99
		public Hat(string itemId) : base(itemId, ClothingItemType.Hat)
		{
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00002BA3 File Offset: 0x00000DA3
		public static implicit operator Hat(int value)
		{
			return new Hat(value.ToString());
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00002BB1 File Offset: 0x00000DB1
		public static implicit operator Hat(string value)
		{
			return new Hat(value);
		}
	}
}
