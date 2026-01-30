using System;

namespace SkillfulClothes.Types
{
	// Token: 0x02000017 RID: 23
	public class AlphanumericItemId
	{
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000295D File Offset: 0x00000B5D
		public ClothingItemType ItemType { get; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00002965 File Offset: 0x00000B65
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x0000296D File Offset: 0x00000B6D
		public string ItemName { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00002976 File Offset: 0x00000B76
		public string ItemId { get; }

		// Token: 0x060000C7 RID: 199 RVA: 0x0000297E File Offset: 0x00000B7E
		public AlphanumericItemId(string itemId, ClothingItemType itemType = ClothingItemType.Undefined)
		{
			this.ItemId = itemId;
			this.ItemType = itemType;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00007184 File Offset: 0x00005384
		public override bool Equals(object obj)
		{
			AlphanumericItemId other = obj as AlphanumericItemId;
			return other != null && this.ItemType == other.ItemType && this.ItemId == other.ItemId;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00002994 File Offset: 0x00000B94
		public override int GetHashCode()
		{
			return this.ItemId.GetHashCode();
		}
	}
}
