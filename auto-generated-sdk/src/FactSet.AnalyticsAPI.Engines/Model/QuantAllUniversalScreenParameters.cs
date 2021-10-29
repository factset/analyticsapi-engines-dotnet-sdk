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
    /// QuantAllUniversalScreenParameters
    /// </summary>
    [DataContract(Name = "QuantAllUniversalScreenParameters")]
    public partial class QuantAllUniversalScreenParameters : IEquatable<QuantAllUniversalScreenParameters>, IValidatableObject
    {
        /// <summary>
        /// Defines Source
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SourceEnum
        {
            /// <summary>
            /// Enum ScreeningExpression for value: ScreeningExpression
            /// </summary>
            [EnumMember(Value = "ScreeningExpression")]
            ScreeningExpression = 1,

            /// <summary>
            /// Enum FqlExpression for value: FqlExpression
            /// </summary>
            [EnumMember(Value = "FqlExpression")]
            FqlExpression = 2,

            /// <summary>
            /// Enum UniversalScreenParameter for value: UniversalScreenParameter
            /// </summary>
            [EnumMember(Value = "UniversalScreenParameter")]
            UniversalScreenParameter = 3,

            /// <summary>
            /// Enum AllUniversalScreenParameters for value: AllUniversalScreenParameters
            /// </summary>
            [EnumMember(Value = "AllUniversalScreenParameters")]
            AllUniversalScreenParameters = 4

        }

        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name = "source", IsRequired = true, EmitDefaultValue = false)]
        public SourceEnum Source { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantAllUniversalScreenParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantAllUniversalScreenParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantAllUniversalScreenParameters" /> class.
        /// </summary>
        /// <param name="source">source (required).</param>
        public QuantAllUniversalScreenParameters(SourceEnum source = default(SourceEnum))
        {
            this.Source = source;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantAllUniversalScreenParameters {\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
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
            return this.Equals(input as QuantAllUniversalScreenParameters);
        }

        /// <summary>
        /// Returns true if QuantAllUniversalScreenParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantAllUniversalScreenParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantAllUniversalScreenParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Source == input.Source ||
                    this.Source.Equals(input.Source)
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
                hashCode = hashCode * 59 + this.Source.GetHashCode();
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
