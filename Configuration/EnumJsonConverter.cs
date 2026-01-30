using System;
using Newtonsoft.Json;

namespace SkillfulClothes.Configuration
{
	// Token: 0x0200006C RID: 108
	internal class EnumJsonConverter : JsonConverter
	{
		// Token: 0x0600024E RID: 590 RVA: 0x000039E8 File Offset: 0x00001BE8
		public override bool CanConvert(Type objectType)
		{
			return objectType.IsEnum;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x000039F0 File Offset: 0x00001BF0
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000039F7 File Offset: 0x00001BF7
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(((value != null) ? value.ToString() : null) ?? "");
		}
	}
}
