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
    /// ConstraintAction
    /// </summary>
    [DataContract(Name = "ConstraintAction")]
    public partial class ConstraintAction : IEquatable<ConstraintAction>, IValidatableObject
    {
        /// <summary>
        /// Defines Item2
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Item2Enum
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
        /// Gets or Sets Item2
        /// </summary>
        [DataMember(Name = "item2", EmitDefaultValue = false)]
        public Item2Enum? Item2 { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintAction" /> class.
        /// </summary>
        /// <param name="item1">item1.</param>
        /// <param name="item2">item2.</param>
        public ConstraintAction(string item1 = default(string), Item2Enum? item2 = default(Item2Enum?))
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        /// <summary>
        /// Gets or Sets Item1
        /// </summary>
        [DataMember(Name = "item1", EmitDefaultValue = false)]
        public string Item1 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConstraintAction {\n");
            sb.Append("  Item1: ").Append(Item1).Append("\n");
            sb.Append("  Item2: ").Append(Item2).Append("\n");
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
            return this.Equals(input as ConstraintAction);
        }

        /// <summary>
        /// Returns true if ConstraintAction instances are equal
        /// </summary>
        /// <param name="input">Instance of ConstraintAction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConstraintAction input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Item1 == input.Item1 ||
                    (this.Item1 != null &&
                    this.Item1.Equals(input.Item1))
                ) && 
                (
                    this.Item2 == input.Item2 ||
                    this.Item2.Equals(input.Item2)
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
                if (this.Item1 != null)
                    hashCode = hashCode * 59 + this.Item1.GetHashCode();
                hashCode = hashCode * 59 + this.Item2.GetHashCode();
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
