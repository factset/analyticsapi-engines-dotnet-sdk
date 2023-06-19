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
    /// VaultCalculationParameters
    /// </summary>
    [DataContract(Name = "VaultCalculationParameters")]
    public partial class VaultCalculationParameters : IEquatable<VaultCalculationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VaultCalculationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected VaultCalculationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="VaultCalculationParameters" /> class.
        /// </summary>
        /// <param name="componentid">The Vault component identifier to analyze. (required).</param>
        /// <param name="account">account (required).</param>
        /// <param name="dates">dates.</param>
        /// <param name="configid">Vault Configuration identifier. (required).</param>
        /// <param name="componentdetail">Component detail type for the Vault component. It can be GROUPS or TOTALS or SECURITIES..</param>
        public VaultCalculationParameters(string componentid = default(string), VaultIdentifier account = default(VaultIdentifier), VaultDateParameters dates = default(VaultDateParameters), string configid = default(string), string componentdetail = default(string))
        {
            // to ensure "componentid" is required (not null)
            this.Componentid = componentid ?? throw new ArgumentNullException("componentid is a required property for VaultCalculationParameters and cannot be null");
            // to ensure "account" is required (not null)
            this.Account = account ?? throw new ArgumentNullException("account is a required property for VaultCalculationParameters and cannot be null");
            // to ensure "configid" is required (not null)
            this.Configid = configid ?? throw new ArgumentNullException("configid is a required property for VaultCalculationParameters and cannot be null");
            this.Dates = dates;
            this.Componentdetail = componentdetail;
        }

        /// <summary>
        /// The Vault component identifier to analyze.
        /// </summary>
        /// <value>The Vault component identifier to analyze.</value>
        [DataMember(Name = "componentid", IsRequired = true, EmitDefaultValue = false)]
        public string Componentid { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", IsRequired = true, EmitDefaultValue = false)]
        public VaultIdentifier Account { get; set; }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name = "dates", EmitDefaultValue = false)]
        public VaultDateParameters Dates { get; set; }

        /// <summary>
        /// Vault Configuration identifier.
        /// </summary>
        /// <value>Vault Configuration identifier.</value>
        [DataMember(Name = "configid", IsRequired = true, EmitDefaultValue = false)]
        public string Configid { get; set; }

        /// <summary>
        /// Component detail type for the Vault component. It can be GROUPS or TOTALS or SECURITIES.
        /// </summary>
        /// <value>Component detail type for the Vault component. It can be GROUPS or TOTALS or SECURITIES.</value>
        [DataMember(Name = "componentdetail", EmitDefaultValue = false)]
        public string Componentdetail { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VaultCalculationParameters {\n");
            sb.Append("  Componentid: ").Append(Componentid).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
            sb.Append("  Configid: ").Append(Configid).Append("\n");
            sb.Append("  Componentdetail: ").Append(Componentdetail).Append("\n");
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
            return this.Equals(input as VaultCalculationParameters);
        }

        /// <summary>
        /// Returns true if VaultCalculationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of VaultCalculationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VaultCalculationParameters input)
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
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Dates == input.Dates ||
                    (this.Dates != null &&
                    this.Dates.Equals(input.Dates))
                ) && 
                (
                    this.Configid == input.Configid ||
                    (this.Configid != null &&
                    this.Configid.Equals(input.Configid))
                ) && 
                (
                    this.Componentdetail == input.Componentdetail ||
                    (this.Componentdetail != null &&
                    this.Componentdetail.Equals(input.Componentdetail))
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
                if (this.Account != null)
                    hashCode = hashCode * 59 + this.Account.GetHashCode();
                if (this.Dates != null)
                    hashCode = hashCode * 59 + this.Dates.GetHashCode();
                if (this.Configid != null)
                    hashCode = hashCode * 59 + this.Configid.GetHashCode();
                if (this.Componentdetail != null)
                    hashCode = hashCode * 59 + this.Componentdetail.GetHashCode();
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
