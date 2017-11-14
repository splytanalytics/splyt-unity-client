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
    [KnetikFactory ("updateCollection")]
    
    public class DataCollectorUpdateCollectionRequest : DataCollectorBaseRequest
    {
        /// <summary>
        /// Final balance after the transaction
        /// </summary>
        /// <value>Final balance after the transaction</value>
        [JsonProperty(PropertyName = "balance")]
        public double? Balance;

        /// <summary>
        /// The amount changed (delta) in the transaction
        /// </summary>
        /// <value>The amount changed (delta) in the transaction</value>
        [JsonProperty(PropertyName = "balance_modification")]
        public double? BalanceModification;

        /// <summary>
        /// Whether the unit being updated is a currency unit or not
        /// </summary>
        /// <value>Whether the unit being updated is a currency unit or not</value>
        [JsonProperty(PropertyName = "currency")]
        public bool? Currency;

        /// <summary>
        /// Name of the unit/collection/currency being updated
        /// </summary>
        /// <value>Name of the unit/collection/currency being updated</value>
        [JsonProperty(PropertyName = "name")]
        public string Name;

        /// <inheritdoc />
        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DataCollectorUpdateCollectionRequest {\n");
            sb.Append("  DeviceId: ").Append(DeviceId).Append("\n");
            sb.Append("  EventProperties: ").Append(EventProperties).Append("\n");
            sb.Append("  EventTimestamp: ").Append(EventTimestamp).Append("\n");
            sb.Append("  RequestType: ").Append(RequestType).Append("\n");
            sb.Append("  SendTimestamp: ").Append(SendTimestamp).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  BalanceModification: ").Append(BalanceModification).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
