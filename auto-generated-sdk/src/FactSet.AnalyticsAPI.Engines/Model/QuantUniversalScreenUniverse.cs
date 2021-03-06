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
    /// QuantUniversalScreenUniverse
    /// </summary>
    [DataContract(Name = "QuantUniversalScreenUniverse")]
    public partial class QuantUniversalScreenUniverse : IEquatable<QuantUniversalScreenUniverse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniversalScreenUniverse" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantUniversalScreenUniverse() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniversalScreenUniverse" /> class.
        /// </summary>
        /// <param name="screen">screen (required).</param>
        public QuantUniversalScreenUniverse(string screen = default(string))
        {
            // to ensure "screen" is required (not null)
            this.Screen = screen ?? throw new ArgumentNullException("screen is a required property for QuantUniversalScreenUniverse and cannot be null");
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
            sb.Append("class QuantUniversalScreenUniverse {\n");
            sb.Append("  Screen: ").Append(Screen).Append("\n");
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
            return this.Equals(input as QuantUniversalScreenUniverse);
        }

        /// <summary>
        /// Returns true if QuantUniversalScreenUniverse instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantUniversalScreenUniverse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantUniversalScreenUniverse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Screen == input.Screen ||
                    (this.Screen != null &&
                    this.Screen.Equals(input.Screen))
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
