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
    /// SPARComponent
    /// </summary>
    [DataContract(Name = "SPARComponent")]
    public partial class SPARComponent : IEquatable<SPARComponent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPARComponent" /> class.
        /// </summary>
        /// <param name="id">Component identifier..</param>
        /// <param name="accounts">List of accounts in SPAR document..</param>
        /// <param name="benchmarks">benchmarks.</param>
        /// <param name="currencyIsoCode">CurrencyCode in SPAR document..</param>
        /// <param name="path">The path to the document.</param>
        /// <param name="name">Component name..</param>
        /// <param name="category">Component category..</param>
        public SPARComponent(string id = default(string), List<SPARIdentifier> accounts = default(List<SPARIdentifier>), SPARIdentifier benchmarks = default(SPARIdentifier), string currencyIsoCode = default(string), string path = default(string), string name = default(string), string category = default(string))
        {
            this.Id = id;
            this.Accounts = accounts;
            this.Benchmarks = benchmarks;
            this.CurrencyIsoCode = currencyIsoCode;
            this.Path = path;
            this.Name = name;
            this.Category = category;
        }

        /// <summary>
        /// Component identifier.
        /// </summary>
        /// <value>Component identifier.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// List of accounts in SPAR document.
        /// </summary>
        /// <value>List of accounts in SPAR document.</value>
        [DataMember(Name = "accounts", EmitDefaultValue = false)]
        public List<SPARIdentifier> Accounts { get; set; }

        /// <summary>
        /// Gets or Sets Benchmarks
        /// </summary>
        [DataMember(Name = "benchmarks", EmitDefaultValue = false)]
        public SPARIdentifier Benchmarks { get; set; }

        /// <summary>
        /// CurrencyCode in SPAR document.
        /// </summary>
        /// <value>CurrencyCode in SPAR document.</value>
        [DataMember(Name = "currencyIsoCode", EmitDefaultValue = false)]
        public string CurrencyIsoCode { get; set; }

        /// <summary>
        /// The path to the document
        /// </summary>
        /// <value>The path to the document</value>
        [DataMember(Name = "path", EmitDefaultValue = false)]
        public string Path { get; set; }

        /// <summary>
        /// Component name.
        /// </summary>
        /// <value>Component name.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Component category.
        /// </summary>
        /// <value>Component category.</value>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        public string Category { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SPARComponent {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Accounts: ").Append(Accounts).Append("\n");
            sb.Append("  Benchmarks: ").Append(Benchmarks).Append("\n");
            sb.Append("  CurrencyIsoCode: ").Append(CurrencyIsoCode).Append("\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
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
            return this.Equals(input as SPARComponent);
        }

        /// <summary>
        /// Returns true if SPARComponent instances are equal
        /// </summary>
        /// <param name="input">Instance of SPARComponent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SPARComponent input)
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
                    this.Accounts == input.Accounts ||
                    this.Accounts != null &&
                    input.Accounts != null &&
                    this.Accounts.SequenceEqual(input.Accounts)
                ) && 
                (
                    this.Benchmarks == input.Benchmarks ||
                    (this.Benchmarks != null &&
                    this.Benchmarks.Equals(input.Benchmarks))
                ) && 
                (
                    this.CurrencyIsoCode == input.CurrencyIsoCode ||
                    (this.CurrencyIsoCode != null &&
                    this.CurrencyIsoCode.Equals(input.CurrencyIsoCode))
                ) && 
                (
                    this.Path == input.Path ||
                    (this.Path != null &&
                    this.Path.Equals(input.Path))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
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
                if (this.Accounts != null)
                    hashCode = hashCode * 59 + this.Accounts.GetHashCode();
                if (this.Benchmarks != null)
                    hashCode = hashCode * 59 + this.Benchmarks.GetHashCode();
                if (this.CurrencyIsoCode != null)
                    hashCode = hashCode * 59 + this.CurrencyIsoCode.GetHashCode();
                if (this.Path != null)
                    hashCode = hashCode * 59 + this.Path.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
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
