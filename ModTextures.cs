using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x02000014 RID: 20
	internal class ModTextures
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000023B9 File Offset: 0x000005B9
		// (set) Token: 0x06000066 RID: 102 RVA: 0x000023C1 File Offset: 0x000005C1
		public Texture2D LooseSprites { get; private set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000067 RID: 103 RVA: 0x000023CA File Offset: 0x000005CA
		// (set) Token: 0x06000068 RID: 104 RVA: 0x000023D2 File Offset: 0x000005D2
		public Texture2D Emojis { get; private set; }

		// Token: 0x06000069 RID: 105 RVA: 0x000023DB File Offset: 0x000005DB
		public void Init()
		{
			this.LooseSprites = this.LoadFromResource("SkillfulClothes.Textures.loose_sprites.png");
			this.Emojis = Game1.content.Load<Texture2D>("LooseSprites\\emojis");
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000065A8 File Offset: 0x000047A8
		private Texture2D LoadFromResource(string name)
		{
			Texture2D result;
			try
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				Stream stream = assembly.GetManifestResourceStream(name);
				result = Texture2D.FromStream(Game1.graphics.GraphicsDevice, stream);
			}
			catch (Exception exc)
			{
				Logger.Error("Could not load mod texture file '" + name + "': " + exc.Message);
				result = null;
			}
			return result;
		}
	}
}
