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
    /// LinkedPATemplate
    /// </summary>
    [DataContract(Name = "LinkedPATemplate")]
    public partial class LinkedPATemplate : IEquatable<LinkedPATemplate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedPATemplate" /> class.
        /// </summary>
        /// <param name="directory">Template directory..</param>
        /// <param name="snapshot">snapshot..</param>
        /// <param name="content">content.</param>
        /// <param name="id">Template id..</param>
        /// <param name="description">Template description..</param>
        /// <param name="name">Template name..</param>
        /// <param name="parentComponentId">Template parent tile..</param>
        public LinkedPATemplate(string directory = default(string), bool snapshot = default(bool), TemplateContentTypes content = default(TemplateContentTypes), string id = default(string), string description = default(string), string name = default(string), string parentComponentId = default(string))
        {
            this.Directory = directory;
            this.Snapshot = snapshot;
            this.Content = content;
            this.Id = id;
            this.Description = description;
            this.Name = name;
            this.ParentComponentId = parentComponentId;
        }

        /// <summary>
        /// Template directory.
        /// </summary>
        /// <value>Template directory.</value>
        [DataMember(Name = "directory", EmitDefaultValue = false)]
        public string Directory { get; set; }

        /// <summary>
        /// snapshot.
        /// </summary>
        /// <value>snapshot.</value>
        [DataMember(Name = "snapshot", EmitDefaultValue = true)]
        public bool Snapshot { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [DataMember(Name = "content", EmitDefaultValue = false)]
        public TemplateContentTypes Content { get; set; }

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
            StringBuilder sb = new StringBuilder();
            sb.Append("class LinkedPATemplate {\n");
            sb.Append("  Directory: ").Append(Directory).Append("\n");
            sb.Append("  Snapshot: ").Append(Snapshot).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
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
            return this.Equals(input as LinkedPATemplate);
        }

        /// <summary>
        /// Returns true if LinkedPATemplate instances are equal
        /// </summary>
        /// <param name="input">Instance of LinkedPATemplate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LinkedPATemplate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Directory == input.Directory ||
                    (this.Directory != null &&
                    this.Directory.Equals(input.Directory))
                ) && 
                (
                    this.Snapshot == input.Snapshot ||
                    this.Snapshot.Equals(input.Snapshot)
                ) && 
                (
                    this.Content == input.Content ||
                    (this.Content != null &&
                    this.Content.Equals(input.Content))
                ) && 
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
                if (this.Directory != null)
                {
                    hashCode = (hashCode * 59) + this.Directory.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Snapshot.GetHashCode();
                if (this.Content != null)
                {
                    hashCode = (hashCode * 59) + this.Content.GetHashCode();
                }
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.ParentComponentId != null)
                {
                    hashCode = (hashCode * 59) + this.ParentComponentId.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
