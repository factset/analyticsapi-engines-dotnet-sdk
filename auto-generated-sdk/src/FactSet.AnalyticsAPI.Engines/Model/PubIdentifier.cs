/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v2:[pa,spar,vault,pub],v1:[fiab,fi,axp,afi,npo,bpm,fpo]
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
    /// PubIdentifier
    /// </summary>
    [DataContract(Name = "PubIdentifier")]
    public partial class PubIdentifier : IEquatable<PubIdentifier>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PubIdentifier" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PubIdentifier() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PubIdentifier" /> class.
        /// </summary>
        /// <param name="id">User&#39;s FactSet account path OR benchmark. (required).</param>
        /// <param name="holdingsmode">Holdings Mode can be B&amp;H, TBR, OMS or EXT..</param>
        public PubIdentifier(string id = default(string), string holdingsmode = default(string))
        {
            // to ensure "id" is required (not null)
            this.Id = id ?? throw new ArgumentNullException("id is a required property for PubIdentifier and cannot be null");
            this.Holdingsmode = holdingsmode;
        }

        /// <summary>
        /// User&#39;s FactSet account path OR benchmark.
        /// </summary>
        /// <value>User&#39;s FactSet account path OR benchmark.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Holdings Mode can be B&amp;H, TBR, OMS or EXT.
        /// </summary>
        /// <value>Holdings Mode can be B&amp;H, TBR, OMS or EXT.</value>
        [DataMember(Name = "holdingsmode", EmitDefaultValue = false)]
        public string Holdingsmode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PubIdentifier {\n");
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
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PubIdentifier);
        }

        /// <summary>
        /// Returns true if PubIdentifier instances are equal
        /// </summary>
        /// <param name="input">Instance of PubIdentifier to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PubIdentifier input)
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
