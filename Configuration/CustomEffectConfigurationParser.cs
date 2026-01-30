using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Configuration
{
	// Token: 0x02000065 RID: 101
	public class CustomEffectConfigurationParser
	{
		// Token: 0x0600022C RID: 556 RVA: 0x0000385A File Offset: 0x00001A5A
		public CustomEffectConfigurationParser()
		{
			this.defaultSerializer.Converters.Add(new EffectJsonConverter(EffectLibrary.Default));
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000C7E0 File Offset: 0x0000A9E0
		public List<CustomEffectItemDefinition> Parse(Stream jsonStream)
		{
			JsonSerializer serializer = new JsonSerializer();
			serializer.Converters.Add(new EffectJsonConverter(EffectLibrary.Default));
			List<CustomEffectItemDefinition> result;
			using (StreamReader reader = new StreamReader(jsonStream))
			{
				using (JsonTextReader jsonReader = new JsonTextReader(reader))
				{
					Dictionary<string, IEffect> lst = serializer.Deserialize<Dictionary<string, IEffect>>(jsonReader);
					result = (from x in lst
					select new CustomEffectItemDefinition(x.Key, x.Value)).ToList<CustomEffectItemDefinition>();
				}
			}
			return result;
		}

		// Token: 0x04000249 RID: 585
		private JsonSerializer defaultSerializer = new JsonSerializer();
	}
}
