/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo],v1:[fiab]
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
    /// BPMOptimizerStrategyAlphaOverride
    /// </summary>
    [DataContract(Name = "BPMOptimizerStrategyAlphaOverride")]
    public partial class BPMOptimizerStrategyAlphaOverride : IEquatable<BPMOptimizerStrategyAlphaOverride>, IValidatableObject
    {
        /// <summary>
        /// Defines ReturnType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReturnTypeEnum
        {
            /// <summary>
            /// Enum Excess for value: Excess
            /// </summary>
            [EnumMember(Value = "Excess")]
            Excess = 1,

            /// <summary>
            /// Enum Total for value: Total
            /// </summary>
            [EnumMember(Value = "Total")]
            Total = 2,

            /// <summary>
            /// Enum Active for value: Active
            /// </summary>
            [EnumMember(Value = "Active")]
            Active = 3,

            /// <summary>
            /// Enum Residual for value: Residual
            /// </summary>
            [EnumMember(Value = "Residual")]
            Residual = 4,

            /// <summary>
            /// Enum Exceptional for value: Exceptional
            /// </summary>
            [EnumMember(Value = "Exceptional")]
            Exceptional = 5

        }

        /// <summary>
        /// Gets or Sets ReturnType
        /// </summary>
        [DataMember(Name = "returnType", EmitDefaultValue = false)]
        public ReturnTypeEnum? ReturnType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BPMOptimizerStrategyAlphaOverride" /> class.
        /// </summary>
        /// <param name="formula">formula.</param>
        /// <param name="returnType">returnType.</param>
        /// <param name="returnMultiplier">returnMultiplier.</param>
        public BPMOptimizerStrategyAlphaOverride(string formula = default(string), ReturnTypeEnum? returnType = default(ReturnTypeEnum?), string returnMultiplier = default(string))
        {
            this.Formula = formula;
            this.ReturnType = returnType;
            this.ReturnMultiplier = returnMultiplier;
        }

        /// <summary>
        /// Gets or Sets Formula
        /// </summary>
        [DataMember(Name = "formula", EmitDefaultValue = false)]
        public string Formula { get; set; }

        /// <summary>
        /// Gets or Sets ReturnMultiplier
        /// </summary>
        [DataMember(Name = "returnMultiplier", EmitDefaultValue = false)]
        public string ReturnMultiplier { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BPMOptimizerStrategyAlphaOverride {\n");
            sb.Append("  Formula: ").Append(Formula).Append("\n");
            sb.Append("  ReturnType: ").Append(ReturnType).Append("\n");
            sb.Append("  ReturnMultiplier: ").Append(ReturnMultiplier).Append("\n");
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
            return this.Equals(input as BPMOptimizerStrategyAlphaOverride);
        }

        /// <summary>
        /// Returns true if BPMOptimizerStrategyAlphaOverride instances are equal
        /// </summary>
        /// <param name="input">Instance of BPMOptimizerStrategyAlphaOverride to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BPMOptimizerStrategyAlphaOverride input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Formula == input.Formula ||
                    (this.Formula != null &&
                    this.Formula.Equals(input.Formula))
                ) && 
                (
                    this.ReturnType == input.ReturnType ||
                    this.ReturnType.Equals(input.ReturnType)
                ) && 
                (
                    this.ReturnMultiplier == input.ReturnMultiplier ||
                    (this.ReturnMultiplier != null &&
                    this.ReturnMultiplier.Equals(input.ReturnMultiplier))
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
                if (this.Formula != null)
                    hashCode = hashCode * 59 + this.Formula.GetHashCode();
                hashCode = hashCode * 59 + this.ReturnType.GetHashCode();
                if (this.ReturnMultiplier != null)
                    hashCode = hashCode * 59 + this.ReturnMultiplier.GetHashCode();
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
