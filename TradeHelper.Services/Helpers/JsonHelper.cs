using Newtonsoft.Json;

namespace TradeHelper.Services.Helpers
{
    public static class JsonHelper
    {
        public static JsonSerializerSettings DefaultSettings { get; } = CreateDefaultSerializeSettings();

        public static string SerializeObject(object value, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return JsonConvert.SerializeObject(value, GetJsonSettings(jsonSerializerSettings));
        }

        public static T DeserializeObject<T>(string value, JsonSerializerSettings jsonSerializerSettings = null)
        {
            return JsonConvert.DeserializeObject<T>(value, GetJsonSettings(jsonSerializerSettings));
        }

        private static JsonSerializerSettings GetJsonSettings(JsonSerializerSettings jsonSerializerSettings = null)
        {
            return jsonSerializerSettings != null
                ? CreateDefaultSerializeSettings(jsonSerializerSettings)
                : DefaultSettings;
        }

        private static JsonSerializerSettings CreateDefaultSerializeSettings(JsonSerializerSettings settings = null)
        {
            if (settings == null)
            {
                settings = new JsonSerializerSettings();
            }

            settings.FloatParseHandling = FloatParseHandling.Decimal;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return settings;
        }
    }
}