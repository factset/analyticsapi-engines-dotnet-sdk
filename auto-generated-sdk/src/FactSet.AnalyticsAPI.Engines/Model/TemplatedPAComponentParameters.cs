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
    /// TemplatedPAComponentParameters
    /// </summary>
    [DataContract(Name = "TemplatedPAComponentParameters")]
    public partial class TemplatedPAComponentParameters : IEquatable<TemplatedPAComponentParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatedPAComponentParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TemplatedPAComponentParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatedPAComponentParameters" /> class.
        /// </summary>
        /// <param name="directory">Directory to create templated components (required).</param>
        /// <param name="parentTemplateId">Parent template id (required).</param>
        /// <param name="description">Component description..</param>
        /// <param name="componentData">componentData.</param>
        public TemplatedPAComponentParameters(string directory = default(string), string parentTemplateId = default(string), string description = default(string), PAComponentData componentData = default(PAComponentData))
        {
            // to ensure "directory" is required (not null)
            this.Directory = directory ?? throw new ArgumentNullException("directory is a required property for TemplatedPAComponentParameters and cannot be null");
            // to ensure "parentTemplateId" is required (not null)
            this.ParentTemplateId = parentTemplateId ?? throw new ArgumentNullException("parentTemplateId is a required property for TemplatedPAComponentParameters and cannot be null");
            this.Description = description;
            this.ComponentData = componentData;
        }

        /// <summary>
        /// Directory to create templated components
        /// </summary>
        /// <value>Directory to create templated components</value>
        [DataMember(Name = "directory", IsRequired = true, EmitDefaultValue = false)]
        public string Directory { get; set; }

        /// <summary>
        /// Parent template id
        /// </summary>
        /// <value>Parent template id</value>
        [DataMember(Name = "parentTemplateId", IsRequired = true, EmitDefaultValue = false)]
        public string ParentTemplateId { get; set; }

        /// <summary>
        /// Component description.
        /// </summary>
        /// <value>Component description.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ComponentData
        /// </summary>
        [DataMember(Name = "componentData", EmitDefaultValue = false)]
        public PAComponentData ComponentData { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TemplatedPAComponentParameters {\n");
            sb.Append("  Directory: ").Append(Directory).Append("\n");
            sb.Append("  ParentTemplateId: ").Append(ParentTemplateId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ComponentData: ").Append(ComponentData).Append("\n");
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
            return this.Equals(input as TemplatedPAComponentParameters);
        }

        /// <summary>
        /// Returns true if TemplatedPAComponentParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of TemplatedPAComponentParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TemplatedPAComponentParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Directory == input.Directory ||
                    (this.Directory != null &&
                    this.Directory.Equals(input.Directory))
                ) && 
                (
                    this.ParentTemplateId == input.ParentTemplateId ||
                    (this.ParentTemplateId != null &&
                    this.ParentTemplateId.Equals(input.ParentTemplateId))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.ComponentData == input.ComponentData ||
                    (this.ComponentData != null &&
                    this.ComponentData.Equals(input.ComponentData))
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
                if (this.Directory != null)
                    hashCode = hashCode * 59 + this.Directory.GetHashCode();
                if (this.ParentTemplateId != null)
                    hashCode = hashCode * 59 + this.ParentTemplateId.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.ComponentData != null)
                    hashCode = hashCode * 59 + this.ComponentData.GetHashCode();
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
