/*
 * Engines API
 *
 * Allow clients to fetch Engines Analytics through APIs.
 *
 * The version of the OpenAPI document: 3
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
    /// QuantUniversalScreenUniverse1
    /// </summary>
    [DataContract(Name = "QuantUniversalScreenUniverse1")]
    public partial class QuantUniversalScreenUniverse1 : IEquatable<QuantUniversalScreenUniverse1>, IValidatableObject
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
        [DataMember(Name = "source", EmitDefaultValue = false)]
        public SourceEnum? Source { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniversalScreenUniverse1" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantUniversalScreenUniverse1() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniversalScreenUniverse1" /> class.
        /// </summary>
        /// <param name="screen">screen (required).</param>
        /// <param name="source">source.</param>
        public QuantUniversalScreenUniverse1(string screen = default(string), SourceEnum? source = default(SourceEnum?))
        {
            // to ensure "screen" is required (not null)
            this.Screen = screen ?? throw new ArgumentNullException("screen is a required property for QuantUniversalScreenUniverse1 and cannot be null");
            this.Source = source;
        }

        /// <summary>
        /// Gets or Sets Screen
        /// </summary>
        [DataMember(Name = "screen", IsRequired = true, EmitDefaultValue = false)]
        public string Screen { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantUniversalScreenUniverse1 {\n");
            sb.Append("  Screen: ").Append(Screen).Append("\n");
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
            return this.Equals(input as QuantUniversalScreenUniverse1);
        }

        /// <summary>
        /// Returns true if QuantUniversalScreenUniverse1 instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantUniversalScreenUniverse1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantUniversalScreenUniverse1 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Screen == input.Screen ||
                    (this.Screen != null &&
                    this.Screen.Equals(input.Screen))
                ) && 
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
                if (this.Screen != null)
                    hashCode = hashCode * 59 + this.Screen.GetHashCode();
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
