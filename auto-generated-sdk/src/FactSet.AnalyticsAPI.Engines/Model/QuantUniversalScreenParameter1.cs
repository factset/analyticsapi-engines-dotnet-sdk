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
    /// QuantUniversalScreenParameter1
    /// </summary>
    [DataContract(Name = "QuantUniversalScreenParameter1")]
    public partial class QuantUniversalScreenParameter1 : IEquatable<QuantUniversalScreenParameter1>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniversalScreenParameter1" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantUniversalScreenParameter1() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantUniversalScreenParameter1" /> class.
        /// </summary>
        /// <param name="referenceName">referenceName (required).</param>
        /// <param name="name">name (required).</param>
        public QuantUniversalScreenParameter1(string referenceName = default(string), string name = default(string))
        {
            // to ensure "referenceName" is required (not null)
            this.ReferenceName = referenceName ?? throw new ArgumentNullException("referenceName is a required property for QuantUniversalScreenParameter1 and cannot be null");
            // to ensure "name" is required (not null)
            this.Name = name ?? throw new ArgumentNullException("name is a required property for QuantUniversalScreenParameter1 and cannot be null");
        }

        /// <summary>
        /// Gets or Sets ReferenceName
        /// </summary>
        [DataMember(Name = "referenceName", IsRequired = true, EmitDefaultValue = false)]
        public string ReferenceName { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantUniversalScreenParameter1 {\n");
            sb.Append("  ReferenceName: ").Append(ReferenceName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as QuantUniversalScreenParameter1);
        }

        /// <summary>
        /// Returns true if QuantUniversalScreenParameter1 instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantUniversalScreenParameter1 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantUniversalScreenParameter1 input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ReferenceName == input.ReferenceName ||
                    (this.ReferenceName != null &&
                    this.ReferenceName.Equals(input.ReferenceName))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                if (this.ReferenceName != null)
                    hashCode = hashCode * 59 + this.ReferenceName.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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
