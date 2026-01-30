using System;
using StardewModdingAPI.Utilities;

namespace SkillfulClothes.Configuration
{
	// Token: 0x0200006D RID: 109
	internal class SkillfulClothesConfig
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000252 RID: 594 RVA: 0x00003A1C File Offset: 0x00001C1C
		// (set) Token: 0x06000253 RID: 595 RVA: 0x00003A24 File Offset: 0x00001C24
		public bool EnableShirtEffects { get; set; } = true;

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000254 RID: 596 RVA: 0x00003A2D File Offset: 0x00001C2D
		// (set) Token: 0x06000255 RID: 597 RVA: 0x00003A35 File Offset: 0x00001C35
		public bool EnablePantsEffects { get; set; } = true;

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00003A3E File Offset: 0x00001C3E
		// (set) Token: 0x06000257 RID: 599 RVA: 0x00003A46 File Offset: 0x00001C46
		public bool EnableHatEffects { get; set; } = true;

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000258 RID: 600 RVA: 0x00003A4F File Offset: 0x00001C4F
		// (set) Token: 0x06000259 RID: 601 RVA: 0x00003A57 File Offset: 0x00001C57
		public bool AllItemsCanBeTailored { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600025A RID: 602 RVA: 0x00003A60 File Offset: 0x00001C60
		// (set) Token: 0x0600025B RID: 603 RVA: 0x00003A68 File Offset: 0x00001C68
		public bool verboseLogging { get; set; }

		// Token: 0x0600025C RID: 604 RVA: 0x0000CEEC File Offset: 0x0000B0EC
		public SkillfulClothesConfig()
		{
			this.KeyForWardrobeSetOne = KeybindList.Parse("D1");
			this.KeyForWardrobeSetTwo = KeybindList.Parse("D2");
			this.KeyForWardrobeSetThree = KeybindList.Parse("D3");
			this.KeyForWardrobeSetFour = KeybindList.Parse("D4");
			this.KeyForWardrobeSetFive = KeybindList.Parse("D5");
			this.KeyForWardrobeSetSix = KeybindList.Parse("D6");
			this.ToggleForWardrobeSetReplace = KeybindList.Parse("LeftShift");
			this.KeysForWardrobeOpening = KeybindList.Parse("Q + LeftShift");
			this.CritDamageBalanceActive = true;
			this.TypicalClothesMultiple = 0.55f;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600025D RID: 605 RVA: 0x00003A71 File Offset: 0x00001C71
		// (set) Token: 0x0600025E RID: 606 RVA: 0x00003A79 File Offset: 0x00001C79
		public bool EnableClothingForge { get; set; } = true;

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600025F RID: 607 RVA: 0x00003A82 File Offset: 0x00001C82
		// (set) Token: 0x06000260 RID: 608 RVA: 0x00003A8A File Offset: 0x00001C8A
		public bool LessImpactfulClothes { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00003A93 File Offset: 0x00001C93
		// (set) Token: 0x06000262 RID: 610 RVA: 0x00003A9B File Offset: 0x00001C9B
		public bool DisableWhenActiveAlerts { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00003AA4 File Offset: 0x00001CA4
		// (set) Token: 0x06000264 RID: 612 RVA: 0x00003AAC File Offset: 0x00001CAC
		public bool DisableEffectSFX { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00003AB5 File Offset: 0x00001CB5
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00003ABD File Offset: 0x00001CBD
		public KeybindList KeyForWardrobeSetOne { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00003AC6 File Offset: 0x00001CC6
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00003ACE File Offset: 0x00001CCE
		public KeybindList KeyForWardrobeSetTwo { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000269 RID: 617 RVA: 0x00003AD7 File Offset: 0x00001CD7
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00003ADF File Offset: 0x00001CDF
		public KeybindList KeyForWardrobeSetThree { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600026B RID: 619 RVA: 0x00003AE8 File Offset: 0x00001CE8
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00003AF0 File Offset: 0x00001CF0
		public KeybindList KeyForWardrobeSetFour { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600026D RID: 621 RVA: 0x00003AF9 File Offset: 0x00001CF9
		// (set) Token: 0x0600026E RID: 622 RVA: 0x00003B01 File Offset: 0x00001D01
		public KeybindList KeyForWardrobeSetFive { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600026F RID: 623 RVA: 0x00003B0A File Offset: 0x00001D0A
		// (set) Token: 0x06000270 RID: 624 RVA: 0x00003B12 File Offset: 0x00001D12
		public KeybindList KeyForWardrobeSetSix { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000271 RID: 625 RVA: 0x00003B1B File Offset: 0x00001D1B
		// (set) Token: 0x06000272 RID: 626 RVA: 0x00003B23 File Offset: 0x00001D23
		public KeybindList ToggleForWardrobeSetReplace { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000273 RID: 627 RVA: 0x00003B2C File Offset: 0x00001D2C
		// (set) Token: 0x06000274 RID: 628 RVA: 0x00003B34 File Offset: 0x00001D34
		public KeybindList KeysForWardrobeOpening { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00003B3D File Offset: 0x00001D3D
		// (set) Token: 0x06000276 RID: 630 RVA: 0x00003B45 File Offset: 0x00001D45
		public bool CritDamageBalanceActive { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00003B4E File Offset: 0x00001D4E
		// (set) Token: 0x06000278 RID: 632 RVA: 0x00003B56 File Offset: 0x00001D56
		public bool GlobalFarmWardrobe { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00003B5F File Offset: 0x00001D5F
		// (set) Token: 0x0600027A RID: 634 RVA: 0x00003B67 File Offset: 0x00001D67
		public bool OneToOneSpeed { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x0600027B RID: 635 RVA: 0x00003B70 File Offset: 0x00001D70
		// (set) Token: 0x0600027C RID: 636 RVA: 0x00003B78 File Offset: 0x00001D78
		public float TypicalClothesMultiple { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00003B81 File Offset: 0x00001D81
		// (set) Token: 0x0600027E RID: 638 RVA: 0x00003B89 File Offset: 0x00001D89
		public bool AutoWaterCanReq { get; set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00003B92 File Offset: 0x00001D92
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00003B9A File Offset: 0x00001D9A
		public float LovingRancherRate { get; set; } = 1f;
	}
}
