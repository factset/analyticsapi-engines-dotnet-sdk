/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
 * Contact: testapi@factset.com
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
    /// FICashflows
    /// </summary>
    [DataContract(Name = "FICashflows")]
    public partial class FICashflows : IEquatable<FICashflows>, IValidatableObject
    {
        /// <summary>
        /// OptionalRedemptionCallWhenUnits
        /// </summary>
        /// <value>OptionalRedemptionCallWhenUnits</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OptionalRedemptionCallWhenUnitsEnum
        {
            /// <summary>
            /// Enum Manual for value: Manual
            /// </summary>
            [EnumMember(Value = "Manual")]
            Manual = 1,

            /// <summary>
            /// Enum Never for value: Never
            /// </summary>
            [EnumMember(Value = "Never")]
            Never = 2,

            /// <summary>
            /// Enum ASAP for value: ASAP
            /// </summary>
            [EnumMember(Value = "ASAP")]
            ASAP = 3,

            /// <summary>
            /// Enum Date for value: Date
            /// </summary>
            [EnumMember(Value = "Date")]
            Date = 4,

            /// <summary>
            /// Enum DealClosing for value: Deal Closing
            /// </summary>
            [EnumMember(Value = "Deal Closing")]
            DealClosing = 5,

            /// <summary>
            /// Enum SettleDate for value: Settle Date
            /// </summary>
            [EnumMember(Value = "Settle Date")]
            SettleDate = 6

        }

        /// <summary>
        /// OptionalRedemptionCallWhenUnits
        /// </summary>
        /// <value>OptionalRedemptionCallWhenUnits</value>
        [DataMember(Name = "optionalRedemptionCallWhenUnits", EmitDefaultValue = false)]
        public OptionalRedemptionCallWhenUnitsEnum? OptionalRedemptionCallWhenUnits { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FICashflows" /> class.
        /// </summary>
        /// <param name="optionalRedemptionCallWhenUnits">OptionalRedemptionCallWhenUnits.</param>
        /// <param name="optionalRedemptionCallWhen">OptionalRedemptionCallWhen.</param>
        /// <param name="recoveryLag">RecoveryLag.</param>
        public FICashflows(OptionalRedemptionCallWhenUnitsEnum? optionalRedemptionCallWhenUnits = default(OptionalRedemptionCallWhenUnitsEnum?), int optionalRedemptionCallWhen = default(int), int recoveryLag = default(int))
        {
            this.OptionalRedemptionCallWhenUnits = optionalRedemptionCallWhenUnits;
            this.OptionalRedemptionCallWhen = optionalRedemptionCallWhen;
            this.RecoveryLag = recoveryLag;
        }

        /// <summary>
        /// OptionalRedemptionCallWhen
        /// </summary>
        /// <value>OptionalRedemptionCallWhen</value>
        [DataMember(Name = "optionalRedemptionCallWhen", EmitDefaultValue = false)]
        public int OptionalRedemptionCallWhen { get; set; }

        /// <summary>
        /// RecoveryLag
        /// </summary>
        /// <value>RecoveryLag</value>
        [DataMember(Name = "recoveryLag", EmitDefaultValue = false)]
        public int RecoveryLag { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FICashflows {\n");
            sb.Append("  OptionalRedemptionCallWhenUnits: ").Append(OptionalRedemptionCallWhenUnits).Append("\n");
            sb.Append("  OptionalRedemptionCallWhen: ").Append(OptionalRedemptionCallWhen).Append("\n");
            sb.Append("  RecoveryLag: ").Append(RecoveryLag).Append("\n");
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
            return this.Equals(input as FICashflows);
        }

        /// <summary>
        /// Returns true if FICashflows instances are equal
        /// </summary>
        /// <param name="input">Instance of FICashflows to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FICashflows input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.OptionalRedemptionCallWhenUnits == input.OptionalRedemptionCallWhenUnits ||
                    this.OptionalRedemptionCallWhenUnits.Equals(input.OptionalRedemptionCallWhenUnits)
                ) && 
                (
                    this.OptionalRedemptionCallWhen == input.OptionalRedemptionCallWhen ||
                    this.OptionalRedemptionCallWhen.Equals(input.OptionalRedemptionCallWhen)
                ) && 
                (
                    this.RecoveryLag == input.RecoveryLag ||
                    this.RecoveryLag.Equals(input.RecoveryLag)
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
                hashCode = hashCode * 59 + this.OptionalRedemptionCallWhenUnits.GetHashCode();
                hashCode = hashCode * 59 + this.OptionalRedemptionCallWhen.GetHashCode();
                hashCode = hashCode * 59 + this.RecoveryLag.GetHashCode();
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
