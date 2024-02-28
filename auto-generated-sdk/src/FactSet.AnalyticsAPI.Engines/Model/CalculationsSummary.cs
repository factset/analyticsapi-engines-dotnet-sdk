/*
 * Engines API
 *
 * Allow clients to fetch Analytics through API.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
 * Contact: api@factset.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// CalculationsSummary
    /// </summary>
    [DataContract(Name = "CalculationsSummary")]
    public partial class CalculationsSummary : IEquatable<CalculationsSummary>, IValidatableObject
    {
        /// <summary>
        /// Last poll status of the calculation.
        /// </summary>
        /// <value>Last poll status of the calculation.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Queued for value: Queued
            /// </summary>
            [EnumMember(Value = "Queued")]
            Queued = 1,

            /// <summary>
            /// Enum Executing for value: Executing
            /// </summary>
            [EnumMember(Value = "Executing")]
            Executing = 2,

            /// <summary>
            /// Enum Completed for value: Completed
            /// </summary>
            [EnumMember(Value = "Completed")]
            Completed = 3,

            /// <summary>
            /// Enum Cancelled for value: Cancelled
            /// </summary>
            [EnumMember(Value = "Cancelled")]
            Cancelled = 4

        }

        /// <summary>
        /// Last poll status of the calculation.
        /// </summary>
        /// <value>Last poll status of the calculation.</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationsSummary" /> class.
        /// </summary>
        /// <param name="status">Last poll status of the calculation..</param>
        /// <param name="units">Number of calculation units in batch..</param>
        /// <param name="requestTime">Request time of calculation..</param>
        /// <param name="lastPollTime">Last poll time of calculation..</param>
        public CalculationsSummary(StatusEnum? status = default(StatusEnum?), int units = default(int), DateTime requestTime = default(DateTime), DateTime lastPollTime = default(DateTime))
        {
            this.Status = status;
            this.Units = units;
            this.RequestTime = requestTime;
            this.LastPollTime = lastPollTime;
        }

        /// <summary>
        /// Number of calculation units in batch.
        /// </summary>
        /// <value>Number of calculation units in batch.</value>
        [DataMember(Name = "units", EmitDefaultValue = false)]
        public int Units { get; set; }

        /// <summary>
        /// Request time of calculation.
        /// </summary>
        /// <value>Request time of calculation.</value>
        [DataMember(Name = "requestTime", EmitDefaultValue = false)]
        public DateTime RequestTime { get; set; }

        /// <summary>
        /// Last poll time of calculation.
        /// </summary>
        /// <value>Last poll time of calculation.</value>
        [DataMember(Name = "lastPollTime", EmitDefaultValue = false)]
        public DateTime LastPollTime { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalculationsSummary {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Units: ").Append(Units).Append("\n");
            sb.Append("  RequestTime: ").Append(RequestTime).Append("\n");
            sb.Append("  LastPollTime: ").Append(LastPollTime).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CalculationsSummary);
        }

        /// <summary>
        /// Returns true if CalculationsSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of CalculationsSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalculationsSummary input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Units == input.Units ||
                    this.Units.Equals(input.Units)
                ) && 
                (
                    this.RequestTime == input.RequestTime ||
                    (this.RequestTime != null &&
                    this.RequestTime.Equals(input.RequestTime))
                ) && 
                (
                    this.LastPollTime == input.LastPollTime ||
                    (this.LastPollTime != null &&
                    this.LastPollTime.Equals(input.LastPollTime))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                hashCode = hashCode * 59 + this.Units.GetHashCode();
                if (this.RequestTime != null)
                    hashCode = hashCode * 59 + this.RequestTime.GetHashCode();
                if (this.LastPollTime != null)
                    hashCode = hashCode * 59 + this.LastPollTime.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
