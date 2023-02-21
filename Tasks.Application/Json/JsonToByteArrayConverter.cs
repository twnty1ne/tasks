using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text;
using Tasks.Application.Exceptions;

namespace Tasks.Application.Json
{
    internal sealed class JsonToByteArrayConverter : JsonConverter<byte[]?>
    {
        // Converts base64 encoded string to byte[].
        public override byte[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!reader.TryGetBytesFromBase64(out byte[]? result) || result == default)
            {
                throw new InvalidRequestException();
            }
            return result;
        }

        // Converts byte[] to base64 encoded string.
        public override void Write(Utf8JsonWriter writer, byte[]? value, JsonSerializerOptions options)
        {
            writer.WriteBase64StringValue(value);
        }
    }
}
