/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
 * Contact: testapi@factset.com
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
    /// TemplatedPAComponentUpdateParameters
    /// </summary>
    [DataContract(Name = "TemplatedPAComponentUpdateParameters")]
    public partial class TemplatedPAComponentUpdateParameters : IEquatable<TemplatedPAComponentUpdateParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatedPAComponentUpdateParameters" /> class.
        /// </summary>
        /// <param name="parentTemplateId">Parent template id.</param>
        /// <param name="description">Component description..</param>
        /// <param name="componentData">componentData.</param>
        public TemplatedPAComponentUpdateParameters(string parentTemplateId = default(string), string description = default(string), PAComponentData componentData = default(PAComponentData))
        {
            this.ParentTemplateId = parentTemplateId;
            this.Description = description;
            this.ComponentData = componentData;
        }

        /// <summary>
        /// Parent template id
        /// </summary>
        /// <value>Parent template id</value>
        [DataMember(Name = "parentTemplateId", EmitDefaultValue = false)]
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
            sb.Append("class TemplatedPAComponentUpdateParameters {\n");
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
            return this.Equals(input as TemplatedPAComponentUpdateParameters);
        }

        /// <summary>
        /// Returns true if TemplatedPAComponentUpdateParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of TemplatedPAComponentUpdateParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TemplatedPAComponentUpdateParameters input)
        {
            if (input == null)
                return false;

            return 
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
