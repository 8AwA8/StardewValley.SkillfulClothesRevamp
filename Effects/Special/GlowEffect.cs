using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Types;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.BellsAndWhistles;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000048 RID: 72
	internal class GlowEffect : SingleEffect<GlowEffectParameters>
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000174 RID: 372 RVA: 0x000030F7 File Offset: 0x000012F7
		public float Radius { get; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000175 RID: 373 RVA: 0x000030FF File Offset: 0x000012FF
		// (set) Token: 0x06000176 RID: 374 RVA: 0x00003107 File Offset: 0x00001307
		public Color Color { get; set; }

		// Token: 0x06000177 RID: 375 RVA: 0x00003110 File Offset: 0x00001310
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return new EffectDescriptionLine(EffectIcon.Glow, EffectHelper.ModHelper.Translation.Get("Spec-Glow"));
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000A4A4 File Offset: 0x000086A4
		public GlowEffect(GlowEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000A58C File Offset: 0x0000878C
		public GlowEffect(float radius, Color? color = null) : base(GlowEffectParameters.With(radius, color))
		{
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000A67C File Offset: 0x0000887C
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
			if (base.Parameters.Color.A == 0)
			{
				this.grad.Value = true;
			}
			else
			{
				this.grad.Value = false;
				base.Parameters.Color = new Color((int)base.Parameters.Color.R, (int)base.Parameters.Color.G, (int)base.Parameters.Color.B, 155);
			}
			this.firefly.Value = new Firefly(Game1.player.Position);
			this.light.Value = EffectHelper.ModHelper.Reflection.GetField<LightSource>(this.firefly.Value, "light", true).GetValue();
			float radius = base.Parameters.Radius;
			Color color = base.Parameters.Color;
			this.light.Value.radius.Set(radius);
			this.light.Value.color.Set(color);
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.Player.Warped += this.Events_LocationChanged;
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking += this.GameLoop_UpdateTicking;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000A814 File Offset: 0x00008A14
		private void GameLoop_UpdateTicking(object sender, UpdateTickingEventArgs e)
		{
			if (this.light.Value == null)
			{
				return;
			}
			if (this.grad.Value)
			{
				this.light.Value.color.Set(Color.Lerp(this.light.Value.color.Value, this.rainbow[this.countKeep.Value], 0.03f));
				if (this.ColorsAreClose(this.light.Value.color.Value, this.rainbow[this.countKeep.Value], 50))
				{
					int value = this.countKeep.Value;
					this.countKeep.Value = value + 1;
				}
				if (this.countKeep.Value == 5)
				{
					this.countKeep.Value = 0;
				}
			}
			this.light.Value.position.Value = Game1.player.Position + new Vector2(26f, -6f);
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000A928 File Offset: 0x00008B28
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
			EffectHelper.ModHelper.Events.GameLoop.UpdateTicking -= this.GameLoop_UpdateTicking;
			EffectHelper.ModHelper.Events.Player.Warped -= this.Events_LocationChanged;
			if (this.light.Value != null)
			{
				this.light.Value.radius.Set(0f);
				this.light.Value = null;
			}
			if (this.firefly.Value != null)
			{
				this.firefly.Value = null;
			}
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000A9C4 File Offset: 0x00008BC4
		private bool ColorsAreClose(Color a, Color z, int threshold = 50)
		{
			int b = a.R - z.R;
			int num = (int)(a.G - z.G);
			int num2 = (int)(a.B - z.B);
			return (int)(b * b) + num * num + num2 * num2 <= threshold * threshold;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000AA14 File Offset: 0x00008C14
		private void Events_LocationChanged(object sender, WarpedEventArgs e)
		{
			this.firefly.Value = new Firefly(Game1.player.Position);
			this.light.Value = EffectHelper.ModHelper.Reflection.GetField<LightSource>(this.firefly.Value, "light", true).GetValue();
			float radius = base.Parameters.Radius;
			Color color = base.Parameters.Color;
			this.light.Value.radius.Set(radius);
			this.light.Value.color.Set(color);
		}

		// Token: 0x04000220 RID: 544
		private const float drawXOffset = 26f;

		// Token: 0x04000221 RID: 545
		private const float drawYOffset = -6f;

		// Token: 0x04000224 RID: 548
		private Color[] rainbow = new Color[]
		{
			new Color(255, 0, 0, 155),
			new Color(255, 255, 0, 155),
			new Color(0, 255, 255, 155),
			new Color(0, 255, 0, 155),
			new Color(0, 0, 255, 155),
			new Color(255, 0, 255, 155)
		};

		// Token: 0x04000225 RID: 549
		private PerScreen<LightSource> light = new PerScreen<LightSource>();

		// Token: 0x04000226 RID: 550
		private PerScreen<Firefly> firefly = new PerScreen<Firefly>();

		// Token: 0x04000227 RID: 551
		private PerScreen<int> countKeep = new PerScreen<int>();

		// Token: 0x04000228 RID: 552
		private PerScreen<bool> grad = new PerScreen<bool>();
	}
}
