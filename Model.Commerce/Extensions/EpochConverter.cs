using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Model.Commerce.Extensions;

public sealed class JsonDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(DateTimeOffset))
        {
            throw new ArgumentException($"Unexpected type '{typeToConvert}'.");
        }

        string formatted = reader.GetString();
        return EpochConverter.GetDateTimeOffsetFromEpoch(formatted);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        long unixTime = Convert.ToInt64((value - EpochConverter.EpochStart).TotalMilliseconds);
        TimeSpan utcOffset = value.Offset;

        string formatted = FormattableString.Invariant($"/Date({unixTime}{(utcOffset >= TimeSpan.Zero ? "+" : "-")}{utcOffset:hhmm})/");
        writer.WriteStringValue(formatted);
    }
}

public sealed class JsonDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(DateTime))
        {
            throw new ArgumentException($"Unexpected type '{typeToConvert}'.");
        }

        string formatted = reader.GetString();
        return EpochConverter.GetDateTimeFromEpoch(formatted);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        var unixTime = EpochConverter.GetUnixTime(value);
        string formatted = FormattableString.Invariant($"/Date({unixTime})/");
        writer.WriteStringValue(formatted);
    }
}

public sealed partial class JsonNullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert != typeof(DateTime?))
        {
            throw new ArgumentException($"Unexpected type '{typeToConvert}'.");
        }

        string formatted = reader.GetString();
        return EpochConverter.GetNullableDateTimeFromEpoch(formatted);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        var unixTime = EpochConverter.GetUnixTime(value.Value);
        string formatted = FormattableString.Invariant($"/Date({unixTime})/");
        writer.WriteStringValue(formatted);
    }
}

public static class EpochConverter
{
    private static readonly Regex EpochRegex = new Regex(@"Date\((\d+)([+-]\d{4})\)", RegexOptions.CultureInvariant);
    public static DateTime EpochStart { get;  } = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static DateTime? GetNullableDateTimeFromEpoch(string formatted)
    {
        var unixTime = ParseUnixTimeMilliSeconds(formatted);

        return EpochStart.AddMilliseconds(unixTime);
    }

    public static DateTime GetDateTimeFromEpoch(string formatted)
    {
        var unixTime = ParseUnixTimeMilliSeconds(formatted);

        return EpochStart.AddMilliseconds(unixTime);
    }

    public static DateTimeOffset GetDateTimeOffsetFromEpoch(string formatted)
    {
        var unixTime = ParseUnixTimeMilliSeconds(formatted);

        return new DateTimeOffset(EpochStart.AddMilliseconds(unixTime));
    }

    private static long ParseUnixTimeMilliSeconds(string formatted)
    {
        Match match = EpochRegex.Match(formatted ?? "");
        var numberValuePart0 = match.Groups[0].Value;
        var numberValuePart1 = match.Groups[1].Value;
        var numberValuePart2 = match.Groups[2].Value;

        foreach (Group matchGroup in match.Groups)
        {
            Console.WriteLine(matchGroup.Value);
        }

        if (!match.Success || !long.TryParse(numberValuePart1, NumberStyles.Integer, CultureInfo.InvariantCulture, out long unixTime))
        {
            throw new Exception("Unexpected value format, unable to parse DateTime.");
        }

        return unixTime;
    }

    public static long GetUnixTime(DateTime dateTime)
    {
        return Convert.ToInt64((dateTime - EpochStart).TotalMilliseconds);
    }

    public static JsonSerializerOptions Options  => new JsonSerializerOptions
                                                                      {
                                                                          Converters =
                                                                          {
                                                                              new JsonDateTimeConverter(),
                                                                              new JsonDateTimeOffsetConverter(),
                                                                              new JsonNullableDateTimeConverter()
                                                                          }
                                                                      };
}