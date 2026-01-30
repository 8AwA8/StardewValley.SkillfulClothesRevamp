using System;

namespace SkillfulClothes.Types
{
	// Token: 0x0200002E RID: 46
	[Flags]
	public enum SellingCondition
	{
		// Token: 0x040001B6 RID: 438
		None = 0,
		// Token: 0x040001B7 RID: 439
		SkillLevel_2 = 1,
		// Token: 0x040001B8 RID: 440
		SkillLevel_4 = 2,
		// Token: 0x040001B9 RID: 441
		SkillLevel_6 = 4,
		// Token: 0x040001BA RID: 442
		SkillLevel_8 = 8,
		// Token: 0x040001BB RID: 443
		SkillLevel_10 = 16,
		// Token: 0x040001BC RID: 444
		FriendshipHearts_2 = 32,
		// Token: 0x040001BD RID: 445
		FriendshipHearts_4 = 64,
		// Token: 0x040001BE RID: 446
		FriendshipHearts_6 = 128,
		// Token: 0x040001BF RID: 447
		FriendshipHearts_8 = 256,
		// Token: 0x040001C0 RID: 448
		FriendshipHearts_10 = 512
	}
}
