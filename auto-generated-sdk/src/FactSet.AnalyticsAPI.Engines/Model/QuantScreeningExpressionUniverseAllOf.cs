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
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// QuantScreeningExpressionUniverseAllOf
    /// </summary>
    [DataContract(Name = "QuantScreeningExpressionUniverse_allOf")]
    public partial class QuantScreeningExpressionUniverseAllOf : IEquatable<QuantScreeningExpressionUniverseAllOf>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="QuantScreeningExpressionUniverseAllOf" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantScreeningExpressionUniverseAllOf() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantScreeningExpressionUniverseAllOf" /> class.
        /// </summary>
        /// <param name="universeExpr">universeExpr (required).</param>
        /// <param name="universeType">universeType (required).</param>
        /// <param name="securityExpr">securityExpr.</param>
        public QuantScreeningExpressionUniverseAllOf(string universeExpr = default(string), UniverseTypeEnum universeType = default(UniverseTypeEnum), string securityExpr = default(string))
        {
            // to ensure "universeExpr" is required (not null)
            this.UniverseExpr = universeExpr ?? throw new ArgumentNullException("universeExpr is a required property for QuantScreeningExpressionUniverseAllOf and cannot be null");
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
            sb.Append("class QuantScreeningExpressionUniverseAllOf {\n");
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
            return this.Equals(input as QuantScreeningExpressionUniverseAllOf);
        }

        /// <summary>
        /// Returns true if QuantScreeningExpressionUniverseAllOf instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantScreeningExpressionUniverseAllOf to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantScreeningExpressionUniverseAllOf input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.UniverseExpr == input.UniverseExpr ||
                    (this.UniverseExpr != null &&
                    this.UniverseExpr.Equals(input.UniverseExpr))
                ) && 
                (
                    this.UniverseType == input.UniverseType ||
                    this.UniverseType.Equals(input.UniverseType)
                ) && 
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
                int hashCode = 41;
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
            yield break;
        }
    }

}
