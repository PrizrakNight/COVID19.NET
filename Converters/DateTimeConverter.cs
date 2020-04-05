using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace COVID19.NET
{
    internal class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TokenType == JsonTokenType.String)
            {
                string[] dateInfo = reader.GetString().Split('/');

                return new DateTime(2000 + int.Parse(dateInfo[2]), int.Parse(dateInfo[0]), int.Parse(dateInfo[1]));
            }

            throw new NotSupportedException();
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}