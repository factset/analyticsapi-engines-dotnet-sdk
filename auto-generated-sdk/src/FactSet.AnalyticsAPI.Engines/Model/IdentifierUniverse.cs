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
    /// IdentifierUniverse
    /// </summary>
    [DataContract(Name = "IdentifierUniverse")]
    public partial class IdentifierUniverse : IEquatable<IdentifierUniverse>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="IdentifierUniverse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected IdentifierUniverse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifierUniverse" /> class.
        /// </summary>
        /// <param name="universeType">universeType (required).</param>
        /// <param name="identifiers">identifiers (required).</param>
        public IdentifierUniverse(UniverseTypeEnum universeType = default(UniverseTypeEnum), List<string> identifiers = default(List<string>))
        {
            this.UniverseType = universeType;
            // to ensure "identifiers" is required (not null)
            this.Identifiers = identifiers ?? throw new ArgumentNullException("identifiers is a required property for IdentifierUniverse and cannot be null");
        }

        /// <summary>
        /// Gets or Sets Identifiers
        /// </summary>
        [DataMember(Name = "identifiers", IsRequired = true, EmitDefaultValue = false)]
        public List<string> Identifiers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class IdentifierUniverse {\n");
            sb.Append("  UniverseType: ").Append(UniverseType).Append("\n");
            sb.Append("  Identifiers: ").Append(Identifiers).Append("\n");
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
            return this.Equals(input as IdentifierUniverse);
        }

        /// <summary>
        /// Returns true if IdentifierUniverse instances are equal
        /// </summary>
        /// <param name="input">Instance of IdentifierUniverse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(IdentifierUniverse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.UniverseType == input.UniverseType ||
                    this.UniverseType.Equals(input.UniverseType)
                ) && 
                (
                    this.Identifiers == input.Identifiers ||
                    this.Identifiers != null &&
                    input.Identifiers != null &&
                    this.Identifiers.SequenceEqual(input.Identifiers)
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
                hashCode = hashCode * 59 + this.UniverseType.GetHashCode();
                if (this.Identifiers != null)
                    hashCode = hashCode * 59 + this.Identifiers.GetHashCode();
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
