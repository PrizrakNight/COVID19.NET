using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace COVID19.NET.Converters
{
    internal class StringToDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TokenType == JsonTokenType.String)
            {
                var @string = reader.GetString()
                    .Replace(",", string.Empty)
                    .Replace(".", ",");

                return double.Parse(@string);
            }

            throw new NotSupportedException();
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("0.0", CultureInfo.InvariantCulture));
        }
    }
}
