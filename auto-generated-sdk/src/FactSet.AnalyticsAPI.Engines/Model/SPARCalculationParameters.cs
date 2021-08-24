/*
 * Engines API
 *
 * Allow clients to fetch Engines Analytics through APIs.
 *
 * The version of the OpenAPI document: 3
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
    /// SPARCalculationParameters
    /// </summary>
    [DataContract(Name = "SPARCalculationParameters")]
    public partial class SPARCalculationParameters : IEquatable<SPARCalculationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SPARCalculationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SPARCalculationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SPARCalculationParameters" /> class.
        /// </summary>
        /// <param name="componentid">The SPAR Engine component identifier to analyze. (required).</param>
        /// <param name="accounts">List of accounts for SPAR calculation..</param>
        /// <param name="benchmark">benchmark.</param>
        /// <param name="dates">dates.</param>
        /// <param name="currencyisocode">Currency ISO code for calculation..</param>
        public SPARCalculationParameters(string componentid = default(string), List<SPARIdentifier> accounts = default(List<SPARIdentifier>), SPARIdentifier benchmark = default(SPARIdentifier), SPARDateParameters dates = default(SPARDateParameters), string currencyisocode = default(string))
        {
            // to ensure "componentid" is required (not null)
            this.Componentid = componentid ?? throw new ArgumentNullException("componentid is a required property for SPARCalculationParameters and cannot be null");
            this.Accounts = accounts;
            this.Benchmark = benchmark;
            this.Dates = dates;
            this.Currencyisocode = currencyisocode;
        }

        /// <summary>
        /// The SPAR Engine component identifier to analyze.
        /// </summary>
        /// <value>The SPAR Engine component identifier to analyze.</value>
        [DataMember(Name = "componentid", IsRequired = true, EmitDefaultValue = false)]
        public string Componentid { get; set; }

        /// <summary>
        /// List of accounts for SPAR calculation.
        /// </summary>
        /// <value>List of accounts for SPAR calculation.</value>
        [DataMember(Name = "accounts", EmitDefaultValue = false)]
        public List<SPARIdentifier> Accounts { get; set; }

        /// <summary>
        /// Gets or Sets Benchmark
        /// </summary>
        [DataMember(Name = "benchmark", EmitDefaultValue = false)]
        public SPARIdentifier Benchmark { get; set; }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name = "dates", EmitDefaultValue = false)]
        public SPARDateParameters Dates { get; set; }

        /// <summary>
        /// Currency ISO code for calculation.
        /// </summary>
        /// <value>Currency ISO code for calculation.</value>
        [DataMember(Name = "currencyisocode", EmitDefaultValue = false)]
        public string Currencyisocode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SPARCalculationParameters {\n");
            sb.Append("  Componentid: ").Append(Componentid).Append("\n");
            sb.Append("  Accounts: ").Append(Accounts).Append("\n");
            sb.Append("  Benchmark: ").Append(Benchmark).Append("\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
            sb.Append("  Currencyisocode: ").Append(Currencyisocode).Append("\n");
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
            return this.Equals(input as SPARCalculationParameters);
        }

        /// <summary>
        /// Returns true if SPARCalculationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of SPARCalculationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SPARCalculationParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Componentid == input.Componentid ||
                    (this.Componentid != null &&
                    this.Componentid.Equals(input.Componentid))
                ) && 
                (
                    this.Accounts == input.Accounts ||
                    this.Accounts != null &&
                    input.Accounts != null &&
                    this.Accounts.SequenceEqual(input.Accounts)
                ) && 
                (
                    this.Benchmark == input.Benchmark ||
                    (this.Benchmark != null &&
                    this.Benchmark.Equals(input.Benchmark))
                ) && 
                (
                    this.Dates == input.Dates ||
                    (this.Dates != null &&
                    this.Dates.Equals(input.Dates))
                ) && 
                (
                    this.Currencyisocode == input.Currencyisocode ||
                    (this.Currencyisocode != null &&
                    this.Currencyisocode.Equals(input.Currencyisocode))
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
                if (this.Componentid != null)
                    hashCode = hashCode * 59 + this.Componentid.GetHashCode();
                if (this.Accounts != null)
                    hashCode = hashCode * 59 + this.Accounts.GetHashCode();
                if (this.Benchmark != null)
                    hashCode = hashCode * 59 + this.Benchmark.GetHashCode();
                if (this.Dates != null)
                    hashCode = hashCode * 59 + this.Dates.GetHashCode();
                if (this.Currencyisocode != null)
                    hashCode = hashCode * 59 + this.Currencyisocode.GetHashCode();
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
