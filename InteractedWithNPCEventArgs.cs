using System;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x0200000C RID: 12
	internal class InteractedWithNPCEventArgs : EventArgs
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000021E3 File Offset: 0x000003E3
		public NPC Npc { get; }

		// Token: 0x0600003A RID: 58 RVA: 0x000021EB File Offset: 0x000003EB
		public InteractedWithNPCEventArgs(NPC npc)
		{
			this.Npc = npc;
		}
	}
}
