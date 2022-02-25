using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects;
using SkillfulClothes.Effects.Attributes;
using SkillfulClothes.Effects.Buffs;
using SkillfulClothes.Effects.SharedParameters;
using SkillfulClothes.Effects.Skills;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SkillfulClothes.Test
{
    [TestClass]
    public class CustomEffectConfigurationTest
    {
        [TestMethod]
        public void ParseIdentifiers_Test()
        {
            string json = @"{
	123: 'Foo',
    SailorShirt: 'Bar' }";

            CustomEffectConfigurationParser parser = new CustomEffectConfigurationParser();

            using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var definitions = parser.Parse(mStream);

                Assert.AreEqual(2, definitions.Count);
                Assert.AreEqual("123", definitions[0].ItemIdentifier);
                Assert.AreEqual("SailorShirt", definitions[1].ItemIdentifier);
            }
        }

        [TestMethod]
        public void CreateDefaultEffectInstance_Test()
        {
            CustomEffectConfigurationParser parser = new CustomEffectConfigurationParser();

            IEffect effect = parser.CreateEffectInstance("IncreaseAttack");
            Assert.IsInstanceOfType(effect, typeof(IncreaseAttack));

            Assert.AreEqual(new AmountEffectParameters().Amount, ((IncreaseAttack)effect).Parameters.Amount);
        }

        [TestMethod]
        public void ParseConfigWithSingleEffectAndDefaultParameters_Test()
        {
            string json = @"{
	123: 'IncreaseAttack',
    SailorShirt: 'IncreaseMaxHealth' }";

            CustomEffectConfigurationParser parser = new CustomEffectConfigurationParser();

            using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var definitions = parser.Parse(mStream);

                Assert.AreEqual(2, definitions.Count);
                Assert.AreEqual("123", definitions[0].ItemIdentifier);                
                Assert.IsInstanceOfType(definitions[0].Effect, typeof(IncreaseAttack));

                Assert.AreEqual("SailorShirt", definitions[1].ItemIdentifier);
                Assert.IsInstanceOfType(definitions[1].Effect, typeof(IncreaseMaxHealth));
            }            
        }

        [TestMethod]
        public void ParseConfigWithSingleEffectAndCustomParameters_Test()
        {
            string json = @"{
	123: {
        IncreaseAttack: {
            amount: 5
    }}}";

            CustomEffectConfigurationParser parser = new CustomEffectConfigurationParser();

            using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var definitions = parser.Parse(mStream);

                Assert.AreEqual(1, definitions.Count);
                Assert.AreEqual("123", definitions[0].ItemIdentifier);
                Assert.IsInstanceOfType(definitions[0].Effect, typeof(IncreaseAttack));
                Assert.AreEqual(5, ((IncreaseAttack)definitions[0].Effect).Parameters.Amount);                
            }
        }

        [TestMethod]
        public void ParseConfigWithMultipleEffectsAndDefaultParameters_Test()
        {
            string json = @"{
	123: [
        'IncreaseAttack', 'IncreaseMaxHealth'
        ]}";

            CustomEffectConfigurationParser parser = new CustomEffectConfigurationParser();

            using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var definitions = parser.Parse(mStream);

                Assert.AreEqual(1, definitions.Count);
                Assert.AreEqual("123", definitions[0].ItemIdentifier);
                Assert.IsInstanceOfType(definitions[0].Effect, typeof(EffectSet));

                var effects = new List<IEffect>(((EffectSet)definitions[0].Effect).Effects);
                Assert.IsInstanceOfType(effects[0], typeof(IncreaseAttack));
                Assert.IsInstanceOfType(effects[1], typeof(IncreaseMaxHealth));                
            }
        }

        [TestMethod]
        public void ParseConfigWithMultipleEffectsAndParameters_Test()
        {
            string json = @"{
	123: [
        { IncreaseAttack: {amount: 10} },
        { IncreaseMaxHealth: {amount: 25} }
        ]}";

            CustomEffectConfigurationParser parser = new CustomEffectConfigurationParser();

            using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var definitions = parser.Parse(mStream);

                Assert.AreEqual(1, definitions.Count);
                Assert.AreEqual("123", definitions[0].ItemIdentifier);
                Assert.IsInstanceOfType(definitions[0].Effect, typeof(EffectSet));

                var effects = new List<IEffect>(((EffectSet)definitions[0].Effect).Effects);
                Assert.IsInstanceOfType(effects[0], typeof(IncreaseAttack));
                Assert.AreEqual(10, ((IncreaseAttack)effects[0]).Parameters.Amount);

                Assert.IsInstanceOfType(effects[1], typeof(IncreaseMaxHealth));
                Assert.AreEqual(25, ((IncreaseMaxHealth)effects[1]).Parameters.Amount);
            }
        }

        [TestMethod]
        public void ParseConfigWithMultipleEffectsAndMixedParameterStyle_Test()
        {
            string json = @"{
	123: [
        { IncreaseAttack: {amount: 10} },
        'IncreaseMaxHealth',
        { IncreaseFishingBarByCaughtFish: {} },
        { IncreaseDefense: {} }
        ]}";

            CustomEffectConfigurationParser parser = new CustomEffectConfigurationParser();

            using (var mStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var definitions = parser.Parse(mStream);

                Assert.AreEqual(1, definitions.Count);
                Assert.AreEqual("123", definitions[0].ItemIdentifier);
                Assert.IsInstanceOfType(definitions[0].Effect, typeof(EffectSet));
                var effects = new List<IEffect>(((EffectSet)definitions[0].Effect).Effects);

                Assert.AreEqual(4, effects.Count);
                
                Assert.IsInstanceOfType(effects[0], typeof(IncreaseAttack));
                Assert.AreEqual(10, ((IncreaseAttack)effects[0]).Parameters.Amount);

                Assert.IsInstanceOfType(effects[1], typeof(IncreaseMaxHealth));
                Assert.AreEqual(1, ((IncreaseMaxHealth)effects[1]).Parameters.Amount);

                Assert.IsInstanceOfType(effects[2], typeof(IncreaseFishingBarByCaughtFish));

                Assert.IsInstanceOfType(effects[3], typeof(IncreaseDefense));
                Assert.AreEqual(1, ((IncreaseDefense)effects[3]).Parameters.Amount);
            }
        }
    }
}
