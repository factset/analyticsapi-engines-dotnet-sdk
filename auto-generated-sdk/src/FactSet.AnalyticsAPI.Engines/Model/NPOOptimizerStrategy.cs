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
    /// NPOOptimizerStrategy
    /// </summary>
    [DataContract(Name = "NPOOptimizerStrategy")]
    public partial class NPOOptimizerStrategy : IEquatable<NPOOptimizerStrategy>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NPOOptimizerStrategy" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected NPOOptimizerStrategy() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="NPOOptimizerStrategy" /> class.
        /// </summary>
        /// <param name="overrides">overrides.</param>
        /// <param name="id">OptimizerStrategy document path (required).</param>
        public NPOOptimizerStrategy(NPOOptimizerStrategyOverrides overrides = default(NPOOptimizerStrategyOverrides), string id = default(string))
        {
            // to ensure "id" is required (not null)
            this.Id = id ?? throw new ArgumentNullException("id is a required property for NPOOptimizerStrategy and cannot be null");
            this.Overrides = overrides;
        }

        /// <summary>
        /// Gets or Sets Overrides
        /// </summary>
        [DataMember(Name = "overrides", EmitDefaultValue = false)]
        public NPOOptimizerStrategyOverrides Overrides { get; set; }

        /// <summary>
        /// OptimizerStrategy document path
        /// </summary>
        /// <value>OptimizerStrategy document path</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NPOOptimizerStrategy {\n");
            sb.Append("  Overrides: ").Append(Overrides).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(input as NPOOptimizerStrategy);
        }

        /// <summary>
        /// Returns true if NPOOptimizerStrategy instances are equal
        /// </summary>
        /// <param name="input">Instance of NPOOptimizerStrategy to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NPOOptimizerStrategy input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Overrides == input.Overrides ||
                    (this.Overrides != null &&
                    this.Overrides.Equals(input.Overrides))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
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
                if (this.Overrides != null)
                    hashCode = hashCode * 59 + this.Overrides.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
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
