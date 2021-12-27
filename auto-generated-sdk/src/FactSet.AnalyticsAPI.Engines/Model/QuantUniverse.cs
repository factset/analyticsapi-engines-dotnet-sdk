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
    /// QuantUniverse
    /// </summary>
    [DataContract(Name = "QuantUniverse")]
    public partial class QuantUniverse : IEquatable<QuantUniverse>, IValidatableObject
    {
        /// <summary>
        /// Defines Source
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SourceEnum
        {
            /// <summary>
            /// Enum ScreeningExpressionUniverse for value: ScreeningExpressionUniverse
            /// </summary>
            [EnumMember(Value = "ScreeningExpressionUniverse")]
            ScreeningExpressionUniverse = 1,

            /// <summary>
            /// Enum UniversalScreenUniverse for value: UniversalScreenUniverse
            /// </summary>
            [EnumMember(Value = "UniversalScreenUniverse")]
            UniversalScreenUniverse = 2,

            /// <summary>
            /// Enum IdentifierUniverse for value: IdentifierUniverse
            /// </summary>
            [EnumMember(Value = "IdentifierUniverse")]
            IdentifierUniverse = 3

        }


        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name = "source", IsRequired = true, EmitDefaultValue = false)]
        public SourceEnum Source { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniverse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantUniverse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniverse" /> class.
        /// </summary>
        /// <param name="source">source (required).</param>
        public QuantUniverse(SourceEnum source = default(SourceEnum))
        {
            this.Source = source;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class QuantUniverse {\n");
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
            return this.Equals(input as QuantUniverse);
        }

        /// <summary>
        /// Returns true if QuantUniverse instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantUniverse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantUniverse input)
        {
            if (input == null)
            {
                return false;
            }
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
                hashCode = (hashCode * 59) + this.Source.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
