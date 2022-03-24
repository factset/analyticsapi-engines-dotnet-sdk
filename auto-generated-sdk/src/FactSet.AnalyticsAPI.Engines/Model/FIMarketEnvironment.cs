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
    /// FIMarketEnvironment
    /// </summary>
    [DataContract(Name = "FIMarketEnvironment")]
    public partial class FIMarketEnvironment : IEquatable<FIMarketEnvironment>, IValidatableObject
    {
        /// <summary>
        /// Defines RatePath
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RatePathEnum
        {
            /// <summary>
            /// Enum FLAT for value: FLAT
            /// </summary>
            [EnumMember(Value = "FLAT")]
            FLAT = 1,

            /// <summary>
            /// Enum FORWARD for value: FORWARD
            /// </summary>
            [EnumMember(Value = "FORWARD")]
            FORWARD = 2,

            /// <summary>
            /// Enum FLATFORWARD for value: FLAT & FORWARD
            /// </summary>
            [EnumMember(Value = "FLAT & FORWARD")]
            FLATFORWARD = 3

        }

        /// <summary>
        /// Gets or Sets RatePath
        /// </summary>
        [DataMember(Name = "ratePath", EmitDefaultValue = false)]
        public RatePathEnum? RatePath { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FIMarketEnvironment" /> class.
        /// </summary>
        /// <param name="ratePath">ratePath (default to RatePathEnum.FLATFORWARD).</param>
        public FIMarketEnvironment(RatePathEnum? ratePath = RatePathEnum.FLATFORWARD)
        {
            this.RatePath = ratePath;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIMarketEnvironment {\n");
            sb.Append("  RatePath: ").Append(RatePath).Append("\n");
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
            return this.Equals(input as FIMarketEnvironment);
        }

        /// <summary>
        /// Returns true if FIMarketEnvironment instances are equal
        /// </summary>
        /// <param name="input">Instance of FIMarketEnvironment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIMarketEnvironment input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RatePath == input.RatePath ||
                    this.RatePath.Equals(input.RatePath)
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
                hashCode = hashCode * 59 + this.RatePath.GetHashCode();
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
