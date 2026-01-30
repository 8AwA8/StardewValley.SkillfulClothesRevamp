using System;
using System.Linq;
using SkillfulClothes.Effects;
using SkillfulClothes.Types;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SkillfulClothes
{
	// Token: 0x0200000D RID: 13
	internal abstract class EquippedClothingItemObserver<T> where T : AlphanumericItemId
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003B RID: 59 RVA: 0x000021FA File Offset: 0x000003FA
		private PerScreen<string> _currentItemid { get; } = new PerScreen<string>();

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002202 File Offset: 0x00000402
		// (set) Token: 0x0600003D RID: 61 RVA: 0x0000220F File Offset: 0x0000040F
		protected string CurrentItemId
		{
			get
			{
				return this._currentItemid.Value;
			}
			set
			{
				this._currentItemid.Value = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003E RID: 62 RVA: 0x0000221D File Offset: 0x0000041D
		private PerScreen<Item> _currentItem { get; } = new PerScreen<Item>();

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002225 File Offset: 0x00000425
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002232 File Offset: 0x00000432
		protected Item CurrentItem
		{
			get
			{
				return this._currentItem.Value;
			}
			set
			{
				this._currentItem.Value = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002240 File Offset: 0x00000440
		private PerScreen<IEffect> _currentEffect { get; } = new PerScreen<IEffect>();

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002248 File Offset: 0x00000448
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002255 File Offset: 0x00000455
		public IEffect CurrentEffect
		{
			get
			{
				return this._currentEffect.Value;
			}
			set
			{
				this._currentEffect.Value = value;
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005ED8 File Offset: 0x000040D8
		public EquippedClothingItemObserver()
		{
			if (!typeof(T).IsAssignableTo(typeof(AlphanumericItemId)))
			{
				throw new ArgumentException("T must be an Enum");
			}
			this.clothingName = typeof(T).Name;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002263 File Offset: 0x00000463
		public void Update(Farmer farmer)
		{
			if (this.CurrentItemId != this.GetCurrentItemId(farmer))
			{
				this.ClothingChanged(farmer, this.GetCurrentItemId(farmer));
			}
		}

		// Token: 0x06000046 RID: 70
		protected abstract string GetCurrentItemId(Farmer farmer);

		// Token: 0x06000047 RID: 71
		protected abstract Item GetCurrentItem(Farmer farmer);

		// Token: 0x06000048 RID: 72 RVA: 0x00005F48 File Offset: 0x00004148
		protected void ClothingChanged(Farmer farmer, string newItemId)
		{
			bool flag = this.CurrentItemId == null;
			this.CurrentItemId = newItemId;
			T knownItemById = ItemDefinitions.GetKnownItemById<T>(newItemId);
			bool same = ((knownItemById != null) ? knownItemById.ItemName : null) == newItemId;
			if (this.CurrentEffect != null)
			{
				this.CurrentEffect.Remove(this.CurrentItem, EffectChangeReason.ItemRemoved);
				this.CurrentEffect = null;
			}
			this.CurrentItem = this.GetCurrentItem(farmer);
			if (newItemId != null)
			{
				IEffect currentEffect;
				if (ItemDefinitions.GetEffectByItemId<T>(newItemId, out currentEffect))
				{
					this.CurrentEffect = currentEffect;
					if (!this.isSuspended)
					{
						this.CurrentEffect.Apply(this.CurrentItem, flag ? EffectChangeReason.DayStart : EffectChangeReason.ItemPutOn);
						return;
					}
				}
				else
				{
					this.CurrentEffect = null;
					Logger.Debug("Equipped " + this.clothingName + " has no effects");
				}
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00006010 File Offset: 0x00004210
		public void Suspend(Farmer farmer, EffectChangeReason reason)
		{
			if (!this.isSuspended)
			{
				Logger.Debug("Suspend " + this.clothingName + " effects");
				this.isSuspended = true;
				IEffect currentEffect = this.CurrentEffect;
				if (currentEffect == null)
				{
					return;
				}
				currentEffect.Remove(this.CurrentItem, reason);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00006060 File Offset: 0x00004260
		public void Restore(Farmer farmer, EffectChangeReason reason)
		{
			if (this.isSuspended)
			{
				Logger.Debug("Restore " + this.clothingName + " effects");
				this.isSuspended = false;
				IEffect currentEffect = this.CurrentEffect;
				if (currentEffect == null)
				{
					return;
				}
				currentEffect.Apply(this.CurrentItem, reason);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000060B0 File Offset: 0x000042B0
		public void Reset(Farmer farmer)
		{
			this.CurrentItemId = null;
			IEffect currentEffect = this.CurrentEffect;
			if (currentEffect != null)
			{
				currentEffect.Remove(this.CurrentItem, EffectChangeReason.Reset);
			}
			this.CurrentEffect = null;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000060E4 File Offset: 0x000042E4
		public bool HasRingEffect(string ringId)
		{
			if (this.isSuspended)
			{
				return false;
			}
			EffectSet effectSet = this.CurrentEffect as EffectSet;
			if (effectSet != null)
			{
				return effectSet.Effects.Any(delegate(IEffect x)
				{
					RingEffect ringEffect2 = x as RingEffect;
					return ringEffect2 != null && ((int)ringEffect2.Parameters.Ring).ToString() == ringId;
				});
			}
			RingEffect ringEffect = this.CurrentEffect as RingEffect;
			return ringEffect != null && ((int)ringEffect.Parameters.Ring).ToString() == ringId;
		}

		// Token: 0x0400001D RID: 29
		private bool isSuspended;

		// Token: 0x0400001E RID: 30
		private string clothingName;
	}
}
