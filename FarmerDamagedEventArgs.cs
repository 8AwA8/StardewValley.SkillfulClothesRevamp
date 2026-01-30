using System;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x020000B9 RID: 185
	internal class FarmerDamagedEventArgs : EventArgs
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x000052C6 File Offset: 0x000034C6
		public Farmer Farmer { get; }

		// Token: 0x06000451 RID: 1105 RVA: 0x000052CE File Offset: 0x000034CE
		public FarmerDamagedEventArgs(Farmer farmer)
		{
			this.Farmer = farmer;
		}
	}
}
