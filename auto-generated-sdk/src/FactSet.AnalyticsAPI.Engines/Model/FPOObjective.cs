/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,security-modeling,others],v1:[fiab]
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
    /// FPOObjective
    /// </summary>
    [DataContract(Name = "FPOObjective")]
    public partial class FPOObjective : IEquatable<FPOObjective>, IValidatableObject
    {
        /// <summary>
        /// Defines Inner
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InnerEnum
        {
            /// <summary>
            /// Enum Disable for value: Disable
            /// </summary>
            [EnumMember(Value = "Disable")]
            Disable = 1,

            /// <summary>
            /// Enum Enable for value: Enable
            /// </summary>
            [EnumMember(Value = "Enable")]
            Enable = 2

        }


        /// <summary>
        /// Gets or Sets Terms
        /// </summary>
        [DataMember(Name = "terms", EmitDefaultValue = false)]
        public Dictionary<string, InnerEnum> Terms { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FPOObjective" /> class.
        /// </summary>
        /// <param name="active">active.</param>
        /// <param name="terms">terms.</param>
        public FPOObjective(string active = default(string), Dictionary<string, InnerEnum> terms = default(Dictionary<string, InnerEnum>))
        {
            this.Active = active;
            this.Terms = terms;
        }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name = "active", EmitDefaultValue = false)]
        public string Active { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FPOObjective {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Terms: ").Append(Terms).Append("\n");
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
            return this.Equals(input as FPOObjective);
        }

        /// <summary>
        /// Returns true if FPOObjective instances are equal
        /// </summary>
        /// <param name="input">Instance of FPOObjective to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FPOObjective input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Active == input.Active ||
                    (this.Active != null &&
                    this.Active.Equals(input.Active))
                ) && 
                (
                    this.Terms == input.Terms ||
                    this.Terms.SequenceEqual(input.Terms)
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
                if (this.Active != null)
                    hashCode = hashCode * 59 + this.Active.GetHashCode();
                hashCode = hashCode * 59 + this.Terms.GetHashCode();
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
