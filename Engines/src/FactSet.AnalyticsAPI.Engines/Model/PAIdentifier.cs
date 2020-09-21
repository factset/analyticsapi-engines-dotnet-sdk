/* 
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: 2
 * Contact: analytics.api.support@factset.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// PAIdentifier
    /// </summary>
    [DataContract]
    public partial class PAIdentifier :  IEquatable<PAIdentifier>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PAIdentifier" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PAIdentifier() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PAIdentifier" /> class.
        /// </summary>
        /// <param name="id">User&#39;s FactSet account path OR benchmark. (required).</param>
        /// <param name="holdingsmode">Holdings Mode can be B&amp;H, TBR, OMS or EXT..</param>
        public PAIdentifier(string id = default(string), string holdingsmode = default(string))
        {
            // to ensure "id" is required (not null)
            this.Id = id ?? throw new ArgumentNullException("id is a required property for PAIdentifier and cannot be null");
            this.Holdingsmode = holdingsmode;
        }
        
        /// <summary>
        /// User&#39;s FactSet account path OR benchmark.
        /// </summary>
        /// <value>User&#39;s FactSet account path OR benchmark.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Holdings Mode can be B&amp;H, TBR, OMS or EXT.
        /// </summary>
        /// <value>Holdings Mode can be B&amp;H, TBR, OMS or EXT.</value>
        [DataMember(Name="holdingsmode", EmitDefaultValue=false)]
        public string Holdingsmode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PAIdentifier {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Holdingsmode: ").Append(Holdingsmode).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PAIdentifier);
        }

        /// <summary>
        /// Returns true if PAIdentifier instances are equal
        /// </summary>
        /// <param name="input">Instance of PAIdentifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PAIdentifier input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Holdingsmode == input.Holdingsmode ||
                    (this.Holdingsmode != null &&
                    this.Holdingsmode.Equals(input.Holdingsmode))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Holdingsmode != null)
                    hashCode = hashCode * 59 + this.Holdingsmode.GetHashCode();
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
