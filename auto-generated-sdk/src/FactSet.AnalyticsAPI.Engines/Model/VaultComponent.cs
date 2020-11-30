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
    /// VaultComponent
    /// </summary>
    [DataContract]
    public partial class VaultComponent :  IEquatable<VaultComponent>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VaultComponent" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="account">account.</param>
        /// <param name="benchmark">benchmark.</param>
        /// <param name="currencyisocode">currencyisocode.</param>
        /// <param name="dates">dates.</param>
        /// <param name="snapshot">snapshot.</param>
        /// <param name="name">Component name..</param>
        /// <param name="category">Component category..</param>
        public VaultComponent(string id = default(string), VaultIdentifier account = default(VaultIdentifier), VaultIdentifier benchmark = default(VaultIdentifier), string currencyisocode = default(string), VaultDateParameters dates = default(VaultDateParameters), bool snapshot = default(bool), string name = default(string), string category = default(string))
        {
            this.Id = id;
            this.Account = account;
            this.Benchmark = benchmark;
            this.Currencyisocode = currencyisocode;
            this.Dates = dates;
            this.Snapshot = snapshot;
            this.Name = name;
            this.Category = category;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name="account", EmitDefaultValue=false)]
        public VaultIdentifier Account { get; set; }

        /// <summary>
        /// Gets or Sets Benchmark
        /// </summary>
        [DataMember(Name="benchmark", EmitDefaultValue=false)]
        public VaultIdentifier Benchmark { get; set; }

        /// <summary>
        /// Gets or Sets Currencyisocode
        /// </summary>
        [DataMember(Name="currencyisocode", EmitDefaultValue=false)]
        public string Currencyisocode { get; set; }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name="dates", EmitDefaultValue=false)]
        public VaultDateParameters Dates { get; set; }

        /// <summary>
        /// Gets or Sets Snapshot
        /// </summary>
        [DataMember(Name="snapshot", EmitDefaultValue=false)]
        public bool Snapshot { get; set; }

        /// <summary>
        /// Component name.
        /// </summary>
        /// <value>Component name.</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Component category.
        /// </summary>
        /// <value>Component category.</value>
        [DataMember(Name="category", EmitDefaultValue=false)]
        public string Category { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VaultComponent {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Benchmark: ").Append(Benchmark).Append("\n");
            sb.Append("  Currencyisocode: ").Append(Currencyisocode).Append("\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
            sb.Append("  Snapshot: ").Append(Snapshot).Append("\n");
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as VaultComponent);
        }

        /// <summary>
        /// Returns true if VaultComponent instances are equal
        /// </summary>
        /// <param name="input">Instance of VaultComponent to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VaultComponent input)
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
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Benchmark == input.Benchmark ||
                    (this.Benchmark != null &&
                    this.Benchmark.Equals(input.Benchmark))
                ) && 
                (
                    this.Currencyisocode == input.Currencyisocode ||
                    (this.Currencyisocode != null &&
                    this.Currencyisocode.Equals(input.Currencyisocode))
                ) && 
                (
                    this.Dates == input.Dates ||
                    (this.Dates != null &&
                    this.Dates.Equals(input.Dates))
                ) && 
                (
                    this.Snapshot == input.Snapshot ||
                    this.Snapshot.Equals(input.Snapshot)
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
                if (this.Account != null)
                    hashCode = hashCode * 59 + this.Account.GetHashCode();
                if (this.Benchmark != null)
                    hashCode = hashCode * 59 + this.Benchmark.GetHashCode();
                if (this.Currencyisocode != null)
                    hashCode = hashCode * 59 + this.Currencyisocode.GetHashCode();
                if (this.Dates != null)
                    hashCode = hashCode * 59 + this.Dates.GetHashCode();
                hashCode = hashCode * 59 + this.Snapshot.GetHashCode();
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
