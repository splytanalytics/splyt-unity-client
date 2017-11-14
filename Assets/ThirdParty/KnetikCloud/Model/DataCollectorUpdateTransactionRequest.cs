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
    [KnetikFactory ("updateTransaction")]
    
    public class DataCollectorUpdateTransactionRequest : DataCollectorBaseRequest
    {
        /// <summary>
        /// Progress of the transaction, expressed as a percentage between 1 - 99
        /// </summary>
        /// <value>Progress of the transaction, expressed as a percentage between 1 - 99</value>
        [JsonProperty(PropertyName = "progress")]
        public int? Progress;

        /// <summary>
        /// Unique transaction ID
        /// </summary>
        /// <value>Unique transaction ID</value>
        [JsonProperty(PropertyName = "transaction_id")]
        public string TransactionId;

        /// <summary>
        /// The name/type of the transaction
        /// </summary>
        /// <value>The name/type of the transaction</value>
        [JsonProperty(PropertyName = "category")]
        public string Category;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DataCollectorUpdateTransactionRequest {\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  EventProperties: ").Append(EventProperties).Append("\n");
            sb.Append("  EventTimestamp: ").Append(EventTimestamp).Append("\n");
            sb.Append("  RequestType: ").Append(RequestType).Append("\n");
            sb.Append("  SendTimestamp: ").Append(SendTimestamp).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
            sb.Append("  TransactionId: ").Append(TransactionId).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public new string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
