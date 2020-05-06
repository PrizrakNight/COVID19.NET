using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace COVID19.NET.Converters
{
    internal class StringToIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var @string = reader.GetString();

                return @string.ToLower() == "n/a" ? -1 : int.Parse(@string.Replace(",", string.Empty));
            }

            throw new NotSupportedException();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(string.Format("{0:n0}", value));
        }
    }
}
