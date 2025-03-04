using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace YoutubeApi.Client.Extensions
{
    public static class JsonSerilaizerUtils
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public static T Deserialize<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content, jsonSerializerOptions);
        }

        public static T Deserialize<T>(Stream  content)
        {
            return JsonSerializer.Deserialize<T>(content, jsonSerializerOptions);
        }

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, jsonSerializerOptions);
        }
    }
}
