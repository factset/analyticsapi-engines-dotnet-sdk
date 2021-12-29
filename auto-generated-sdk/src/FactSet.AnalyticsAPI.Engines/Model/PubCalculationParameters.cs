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
    /// PubCalculationParameters
    /// </summary>
    [DataContract(Name = "PubCalculationParameters")]
    public partial class PubCalculationParameters : IEquatable<PubCalculationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PubCalculationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PubCalculationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PubCalculationParameters" /> class.
        /// </summary>
        /// <param name="document">The Publisher Engine document to analyze. (required).</param>
        /// <param name="account">account (required).</param>
        /// <param name="dates">dates (required).</param>
        public PubCalculationParameters(string document = default(string), PubIdentifier account = default(PubIdentifier), PubDateParameters dates = default(PubDateParameters))
        {
            // to ensure "document" is required (not null)
            if (document == null) {
                throw new ArgumentNullException("document is a required property for PubCalculationParameters and cannot be null");
            }
            this.Document = document;
            // to ensure "account" is required (not null)
            if (account == null) {
                throw new ArgumentNullException("account is a required property for PubCalculationParameters and cannot be null");
            }
            this.Account = account;
            // to ensure "dates" is required (not null)
            if (dates == null) {
                throw new ArgumentNullException("dates is a required property for PubCalculationParameters and cannot be null");
            }
            this.Dates = dates;
        }

        /// <summary>
        /// The Publisher Engine document to analyze.
        /// </summary>
        /// <value>The Publisher Engine document to analyze.</value>
        [DataMember(Name = "document", IsRequired = true, EmitDefaultValue = false)]
        public string Document { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = false)]
        public PubIdentifier Account { get; set; }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name = "dates", IsRequired = true, EmitDefaultValue = false)]
        public PubDateParameters Dates { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PubCalculationParameters {\n");
            sb.Append("  Document: ").Append(Document).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
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
            return this.Equals(input as PubCalculationParameters);
        }

        /// <summary>
        /// Returns true if PubCalculationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of PubCalculationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PubCalculationParameters input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Document == input.Document ||
                    (this.Document != null &&
                    this.Document.Equals(input.Document))
                ) && 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Dates == input.Dates ||
                    (this.Dates != null &&
                    this.Dates.Equals(input.Dates))
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
                if (this.Document != null)
                {
                    hashCode = (hashCode * 59) + this.Document.GetHashCode();
                }
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                if (this.Dates != null)
                {
                    hashCode = (hashCode * 59) + this.Dates.GetHashCode();
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
