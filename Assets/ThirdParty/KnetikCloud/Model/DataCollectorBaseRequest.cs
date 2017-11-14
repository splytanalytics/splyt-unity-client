using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using com.knetikcloud.Attributes;
using com.knetikcloud.Serialization;
using Newtonsoft.Json;

namespace com.knetikcloud.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 
    /// </summary>
    
    [JsonConverter(typeof(KnetikJsonConverter<DataCollectorBaseRequest>))]
    public class DataCollectorBaseRequest
    {
        /// <summary>
        /// Unique ID of the device triggering the event
        /// </summary>
        /// <value>Unique ID of the device triggering the event</value>
        [JsonProperty(PropertyName = "device_id")]
        public string DeviceId;

        /// <summary>
        /// A key/value list of properties for this event. Values can be numerical, strings or booleans, proper typing matters (quoted vs unquoted)
        /// </summary>
        /// <value>A key/value list of properties for this event. Values can be numerical, strings or booleans, proper typing matters (quoted vs unquoted)</value>
        [JsonProperty(PropertyName = "event_properties")]
        public Object EventProperties;

        /// <summary>
        /// Epoch timestamp <i>in milliseconds</i> of when event itself occurred
        /// </summary>
        /// <value>Epoch timestamp <i>in milliseconds</i> of when event itself occurred</value>
        [JsonProperty(PropertyName = "event_timestamp")]
        public long? EventTimestamp;

        /// <summary>
        /// Specifies the canonical model name of the request. Ex: DataCollectorNewUserRequest -> newUser, NewEventRequest -> newEvent,e tc
        /// </summary>
        /// <value>Specifies the canonical model name of the request. Ex: DataCollectorNewUserRequest -> newUser, NewEventRequest -> newEvent,e tc</value>
        [JsonProperty(PropertyName = "request_type")]
        public string RequestType;

        /// <summary>
        /// Epoch timestamp <i>in milliseconds</i> of when event was sent to the API
        /// </summary>
        /// <value>Epoch timestamp <i>in milliseconds</i> of when event was sent to the API</value>
        [JsonProperty(PropertyName = "send_timestamp")]
        public long? SendTimestamp;

        /// <summary>
        /// Unique ID of the user triggering the event
        /// </summary>
        /// <value>Unique ID of the user triggering the event</value>
        [JsonProperty(PropertyName = "user_id")]
        public string UserId;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DataCollectorBaseRequest {\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  EventProperties: ").Append(EventProperties).Append("\n");
            sb.Append("  EventTimestamp: ").Append(EventTimestamp).Append("\n");
            sb.Append("  RequestType: ").Append(RequestType).Append("\n");
            sb.Append("  SendTimestamp: ").Append(SendTimestamp).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
