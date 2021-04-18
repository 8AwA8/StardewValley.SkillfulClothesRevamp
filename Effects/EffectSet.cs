﻿using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillfulClothes.Effects
{
    /*
     * A set of effects
     */
    class EffectSet : IEffect
    {

        public IEffect[] Effects { get; }        

        List<EffectDescriptionLine> IEffect.EffectDescription => Effects.SelectMany(x => x.EffectDescription).ToList();

        private EffectSet(params IEffect[] effects)
        {
            Effects = effects;
        }

        public static EffectSet of(params IEffect[] effects)
        {
            return new EffectSet(effects);
        }

        public void Apply(Farmer farmer)
        {
            foreach(var effect in Effects)
            {
                effect.Apply(farmer);
            }
        }

        public void Remove(Farmer farmer)
        {
            foreach (var effect in Effects)
            {
                effect.Remove(farmer);
            }
        }
    }
}
