/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
 * Contact: analytics.api.support@factset.com
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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// QuantScreeningExpressionUniverse
    /// </summary>
    [DataContract(Name = "QuantScreeningExpressionUniverse")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    public partial class QuantScreeningExpressionUniverse : QuantUniverse, IEquatable<QuantScreeningExpressionUniverse>, IValidatableObject
    {
        /// <summary>
        /// Defines UniverseType
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum UniverseTypeEnum
        {
            /// <summary>
            /// Enum Equity for value: Equity
            /// </summary>
            [EnumMember(Value = "Equity")]
            Equity = 1,

            /// <summary>
            /// Enum Debt for value: Debt
            /// </summary>
            [EnumMember(Value = "Debt")]
            Debt = 2

        }

        /// <summary>
        /// Gets or Sets UniverseType
        /// </summary>
        [DataMember(Name = "universeType", IsRequired = true, EmitDefaultValue = false)]
        public UniverseTypeEnum UniverseType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantScreeningExpressionUniverse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantScreeningExpressionUniverse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantScreeningExpressionUniverse" /> class.
        /// </summary>
        /// <param name="universeExpr">universeExpr (required).</param>
        /// <param name="universeType">universeType (required).</param>
        /// <param name="securityExpr">securityExpr.</param>
        /// <param name="type">type (required) (default to &quot;QuantScreeningExpressionUniverse&quot;).</param>
        /// <param name="source">source.</param>
        public QuantScreeningExpressionUniverse(string universeExpr = default(string), UniverseTypeEnum universeType = default(UniverseTypeEnum), string securityExpr = default(string), string type = "QuantScreeningExpressionUniverse", SourceEnum? source = default(SourceEnum?)) : base(type, source)
        {
            // to ensure "universeExpr" is required (not null)
            this.UniverseExpr = universeExpr ?? throw new ArgumentNullException("universeExpr is a required property for QuantScreeningExpressionUniverse and cannot be null");
            this.UniverseType = universeType;
            this.SecurityExpr = securityExpr;
        }

        /// <summary>
        /// Gets or Sets UniverseExpr
        /// </summary>
        [DataMember(Name = "universeExpr", IsRequired = true, EmitDefaultValue = false)]
        public string UniverseExpr { get; set; }

        /// <summary>
        /// Gets or Sets SecurityExpr
        /// </summary>
        [DataMember(Name = "securityExpr", EmitDefaultValue = true)]
        public string SecurityExpr { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantScreeningExpressionUniverse {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  UniverseExpr: ").Append(UniverseExpr).Append("\n");
            sb.Append("  UniverseType: ").Append(UniverseType).Append("\n");
            sb.Append("  SecurityExpr: ").Append(SecurityExpr).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as QuantScreeningExpressionUniverse);
        }

        /// <summary>
        /// Returns true if QuantScreeningExpressionUniverse instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantScreeningExpressionUniverse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantScreeningExpressionUniverse input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.UniverseExpr == input.UniverseExpr ||
                    (this.UniverseExpr != null &&
                    this.UniverseExpr.Equals(input.UniverseExpr))
                ) && base.Equals(input) && 
                (
                    this.UniverseType == input.UniverseType ||
                    this.UniverseType.Equals(input.UniverseType)
                ) && base.Equals(input) && 
                (
                    this.SecurityExpr == input.SecurityExpr ||
                    (this.SecurityExpr != null &&
                    this.SecurityExpr.Equals(input.SecurityExpr))
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
                int hashCode = base.GetHashCode();
                if (this.UniverseExpr != null)
                    hashCode = hashCode * 59 + this.UniverseExpr.GetHashCode();
                hashCode = hashCode * 59 + this.UniverseType.GetHashCode();
                if (this.SecurityExpr != null)
                    hashCode = hashCode * 59 + this.SecurityExpr.GetHashCode();
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
