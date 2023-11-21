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
    /// UnlinkedPATemplateCategoryAndTypeDetails
    /// </summary>
    [DataContract(Name = "UnlinkedPATemplateCategoryAndTypeDetails")]
    public partial class UnlinkedPATemplateCategoryAndTypeDetails : IEquatable<UnlinkedPATemplateCategoryAndTypeDetails>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnlinkedPATemplateCategoryAndTypeDetails" /> class.
        /// </summary>
        /// <param name="id">Type Id.</param>
        /// <param name="columns">List of default columns.</param>
        /// <param name="groups">List of default groupings.</param>
        /// <param name="snapshot">Snapshot.</param>
        /// <param name="category">Unlinked template category.</param>
        /// <param name="name">Unlinked template type.</param>
        public UnlinkedPATemplateCategoryAndTypeDetails(string id = default(string), List<UnlinkedPATemplateColumnDetails> columns = default(List<UnlinkedPATemplateColumnDetails>), List<UnlinkedPATemplateGroupDetails> groups = default(List<UnlinkedPATemplateGroupDetails>), bool snapshot = default(bool), string category = default(string), string name = default(string))
        {
            this.Id = id;
            this.Columns = columns;
            this.Groups = groups;
            this.Snapshot = snapshot;
            this.Category = category;
            this.Name = name;
        }

        /// <summary>
        /// Type Id
        /// </summary>
        /// <value>Type Id</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// List of default columns
        /// </summary>
        /// <value>List of default columns</value>
        [DataMember(Name = "columns", EmitDefaultValue = false)]
        public List<UnlinkedPATemplateColumnDetails> Columns { get; set; }

        /// <summary>
        /// List of default groupings
        /// </summary>
        /// <value>List of default groupings</value>
        [DataMember(Name = "groups", EmitDefaultValue = false)]
        public List<UnlinkedPATemplateGroupDetails> Groups { get; set; }

        /// <summary>
        /// Snapshot
        /// </summary>
        /// <value>Snapshot</value>
        [DataMember(Name = "snapshot", EmitDefaultValue = false)]
        public bool Snapshot { get; set; }

        /// <summary>
        /// Unlinked template category
        /// </summary>
        /// <value>Unlinked template category</value>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public string Category { get; set; }

        /// <summary>
        /// Unlinked template type
        /// </summary>
        /// <value>Unlinked template type</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UnlinkedPATemplateCategoryAndTypeDetails {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Columns: ").Append(Columns).Append("\n");
            sb.Append("  Groups: ").Append(Groups).Append("\n");
            sb.Append("  Snapshot: ").Append(Snapshot).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
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
            return this.Equals(input as UnlinkedPATemplateCategoryAndTypeDetails);
        }

        /// <summary>
        /// Returns true if UnlinkedPATemplateCategoryAndTypeDetails instances are equal
        /// </summary>
        /// <param name="input">Instance of UnlinkedPATemplateCategoryAndTypeDetails to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UnlinkedPATemplateCategoryAndTypeDetails input)
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
                    this.Columns == input.Columns ||
                    this.Columns != null &&
                    input.Columns != null &&
                    this.Columns.SequenceEqual(input.Columns)
                ) && 
                (
                    this.Groups == input.Groups ||
                    this.Groups != null &&
                    input.Groups != null &&
                    this.Groups.SequenceEqual(input.Groups)
                ) && 
                (
                    this.Snapshot == input.Snapshot ||
                    this.Snapshot.Equals(input.Snapshot)
                ) && 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Columns != null)
                    hashCode = hashCode * 59 + this.Columns.GetHashCode();
                if (this.Groups != null)
                    hashCode = hashCode * 59 + this.Groups.GetHashCode();
                hashCode = hashCode * 59 + this.Snapshot.GetHashCode();
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
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
