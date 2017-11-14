using System;
using com.knetikcloud.Factory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace com.knetikcloud.Serialization
{
    /// <summary>
    /// Converter to handle polymorphic deserialization via JSON.Net/MONO.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KnetikJsonConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // This approach is based upon: https://stackoverflow.com/questions/29124126/polymorphic-json-deserialization-failing-using-json-net?rq=1
            JToken jsonObject = JToken.Load(reader);

            // All models have a Type field.  Get the value for lookup.
            string sourceType = jsonObject["type"].Value<string>();

            // Instantiate a instance of the appropritate type
            T target = (T)KnetikFactory.CreateInstance(typeof(T), sourceType);

            // JSON.Net can now deserialize properly as it has the appropriate type.
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Default to standard JSON for the server to read
            serializer.Serialize(writer, value);
        }
    }
}
