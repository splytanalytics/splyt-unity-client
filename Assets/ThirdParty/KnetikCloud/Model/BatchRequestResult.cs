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
    
    
    public class BatchRequestResult
    {
        /// <summary>
        /// HTTP response code for the processed request
        /// </summary>
        /// <value>HTTP response code for the processed request</value>
        [JsonProperty(PropertyName = "code")]
        public int? Code;

        /// <summary>
        /// Error messages if the request could not be processed
        /// </summary>
        /// <value>Error messages if the request could not be processed</value>
        [JsonProperty(PropertyName = "errors")]
        public List<string> Errors;

        /// <summary>
        /// The request. Will be null if request was successfully processed
        /// </summary>
        /// <value>The request. Will be null if request was successfully processed</value>
        [JsonProperty(PropertyName = "request")]
        public DataCollectorBaseRequest Request;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BatchRequestResult {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("  Request: ").Append(Request).Append("\n");
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
