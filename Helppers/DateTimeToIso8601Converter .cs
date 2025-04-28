using System.Text.Json;
using System.Text.Json.Serialization;

public class DateTimeToIso8601Converter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var date = reader.GetString() ?? throw new JsonException("Data nula.");

        return DateTime.ParseExact(date, "yyyy-MM-dd", null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
    }
}
