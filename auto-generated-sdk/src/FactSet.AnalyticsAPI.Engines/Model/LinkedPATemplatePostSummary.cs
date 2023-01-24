/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
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
    /// LinkedPATemplatePostSummary
    /// </summary>
    [DataContract(Name = "LinkedPATemplatePostSummary")]
    public partial class LinkedPATemplatePostSummary : IEquatable<LinkedPATemplatePostSummary>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedPATemplatePostSummary" /> class.
        /// </summary>
        /// <param name="id">Template id..</param>
        /// <param name="description">Template description..</param>
        /// <param name="name">Template name..</param>
        /// <param name="parentComponentId">Template parent tile..</param>
        public LinkedPATemplatePostSummary(string id = default(string), string description = default(string), string name = default(string), string parentComponentId = default(string))
        {
            this.Id = id;
            this.Description = description;
            this.Name = name;
            this.ParentComponentId = parentComponentId;
        }

        /// <summary>
        /// Template id.
        /// </summary>
        /// <value>Template id.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Template description.
        /// </summary>
        /// <value>Template description.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Template name.
        /// </summary>
        /// <value>Template name.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Template parent tile.
        /// </summary>
        /// <value>Template parent tile.</value>
        [DataMember(Name = "parentComponentId", EmitDefaultValue = false)]
        public string ParentComponentId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LinkedPATemplatePostSummary {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  ParentComponentId: ").Append(ParentComponentId).Append("\n");
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
            return this.Equals(input as LinkedPATemplatePostSummary);
        }

        /// <summary>
        /// Returns true if LinkedPATemplatePostSummary instances are equal
        /// </summary>
        /// <param name="input">Instance of LinkedPATemplatePostSummary to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LinkedPATemplatePostSummary input)
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
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.ParentComponentId == input.ParentComponentId ||
                    (this.ParentComponentId != null &&
                    this.ParentComponentId.Equals(input.ParentComponentId))
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
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.ParentComponentId != null)
                    hashCode = hashCode * 59 + this.ParentComponentId.GetHashCode();
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
