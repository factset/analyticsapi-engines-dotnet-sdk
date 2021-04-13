/* 
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
 * Contact: analytics.api.support@factset.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// CalculationStatus
    /// </summary>
    [DataContract]
    public partial class CalculationStatus :  IEquatable<CalculationStatus>, IValidatableObject
    {
        /// <summary>
        /// Defines Status
        /// </summary>
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
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationStatus" /> class.
        /// </summary>
        /// <param name="calculationid">calculationid.</param>
        /// <param name="status">status.</param>
        /// <param name="units">Number of calculation units in batch..</param>
        public CalculationStatus(string calculationid = default(string), StatusEnum? status = default(StatusEnum?), Dictionary<string, CalculationUnitStatus> units = default(Dictionary<string, CalculationUnitStatus>))
        {
            this.Calculationid = calculationid;
            this.Status = status;
            this.Units = units;
        }
        
        /// <summary>
        /// Gets or Sets Calculationid
        /// </summary>
        [DataMember(Name="calculationid", EmitDefaultValue=false)]
        public string Calculationid { get; set; }

        /// <summary>
        /// Number of calculation units in batch.
        /// </summary>
        /// <value>Number of calculation units in batch.</value>
        [DataMember(Name="units", EmitDefaultValue=false)]
        public Dictionary<string, CalculationUnitStatus> Units { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalculationStatus {\n");
            sb.Append("  Calculationid: ").Append(Calculationid).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Units: ").Append(Units).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CalculationStatus);
        }

        /// <summary>
        /// Returns true if CalculationStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of CalculationStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalculationStatus input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Calculationid == input.Calculationid ||
                    (this.Calculationid != null &&
                    this.Calculationid.Equals(input.Calculationid))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Units == input.Units ||
                    this.Units != null &&
                    input.Units != null &&
                    this.Units.SequenceEqual(input.Units)
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
                if (this.Calculationid != null)
                    hashCode = hashCode * 59 + this.Calculationid.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Units != null)
                    hashCode = hashCode * 59 + this.Units.GetHashCode();
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
