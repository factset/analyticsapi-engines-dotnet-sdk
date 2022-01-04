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
    /// LinkedPATemplateParameters
    /// </summary>
    [DataContract(Name = "LinkedPATemplateParameters")]
    public partial class LinkedPATemplateParameters : IEquatable<LinkedPATemplateParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedPATemplateParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected LinkedPATemplateParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedPATemplateParameters" /> class.
        /// </summary>
        /// <param name="directory">The directory to create a linked PA template (required).</param>
        /// <param name="parentComponentId">Parent component id (required).</param>
        /// <param name="description">Template description.</param>
        /// <param name="content">content.</param>
        public LinkedPATemplateParameters(string directory = default(string), string parentComponentId = default(string), string description = default(string), TemplateContentTypes content = default(TemplateContentTypes))
        {
            // to ensure "directory" is required (not null)
            this.Directory = directory ?? throw new ArgumentNullException("directory is a required property for LinkedPATemplateParameters and cannot be null");
            // to ensure "parentComponentId" is required (not null)
            this.ParentComponentId = parentComponentId ?? throw new ArgumentNullException("parentComponentId is a required property for LinkedPATemplateParameters and cannot be null");
            this.Description = description;
            this.Content = content;
        }

        /// <summary>
        /// The directory to create a linked PA template
        /// </summary>
        /// <value>The directory to create a linked PA template</value>
        [DataMember(Name = "directory", IsRequired = true, EmitDefaultValue = false)]
        public string Directory { get; set; }

        /// <summary>
        /// Parent component id
        /// </summary>
        /// <value>Parent component id</value>
        [DataMember(Name = "parentComponentId", IsRequired = true, EmitDefaultValue = false)]
        public string ParentComponentId { get; set; }

        /// <summary>
        /// Template description
        /// </summary>
        /// <value>Template description</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [DataMember(Name = "content", EmitDefaultValue = false)]
        public TemplateContentTypes Content { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LinkedPATemplateParameters {\n");
            sb.Append("  Directory: ").Append(Directory).Append("\n");
            sb.Append("  ParentComponentId: ").Append(ParentComponentId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
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
            return this.Equals(input as LinkedPATemplateParameters);
        }

        /// <summary>
        /// Returns true if LinkedPATemplateParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of LinkedPATemplateParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LinkedPATemplateParameters input)
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
                    this.ParentComponentId == input.ParentComponentId ||
                    (this.ParentComponentId != null &&
                    this.ParentComponentId.Equals(input.ParentComponentId))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Content == input.Content ||
                    (this.Content != null &&
                    this.Content.Equals(input.Content))
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
                if (this.ParentComponentId != null)
                    hashCode = hashCode * 59 + this.ParentComponentId.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Content != null)
                    hashCode = hashCode * 59 + this.Content.GetHashCode();
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