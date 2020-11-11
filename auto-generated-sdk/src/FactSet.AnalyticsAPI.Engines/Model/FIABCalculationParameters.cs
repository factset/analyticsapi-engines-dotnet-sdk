/* 
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v2:[pa,spar,vault,pub],v1:[fiab,fi,axp,afi,npo,bpm,fpo]
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
    /// FIABCalculationParameters
    /// </summary>
    [DataContract]
    public partial class FIABCalculationParameters :  IEquatable<FIABCalculationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIABCalculationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FIABCalculationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FIABCalculationParameters" /> class.
        /// </summary>
        /// <param name="fiabdocument">FiabDocument (optional) - FIAB document to use as a template. Should  be a path to a FIAB document. Expects a GUI-style path (Client:/foo/bar).</param>
        /// <param name="account">account (required).</param>
        /// <param name="dates">dates (required).</param>
        /// <param name="msl">Master Security List. Analytics results will be written to the selected MSL. Expects a GUI-style path (Client:/foo/bar).</param>
        /// <param name="fisettingsdocument">FISettingsDocument (optional) - The given @FIS document will be used to  configure analytics assumptions and settings. Expects a GUI-style path (Client:/foo/bar).</param>
        public FIABCalculationParameters(string fiabdocument = default(string), FIABIdentifier account = default(FIABIdentifier), FIABDateParameters dates = default(FIABDateParameters), string msl = default(string), string fisettingsdocument = default(string))
        {
            // to ensure "account" is required (not null)
            this.Account = account ?? throw new ArgumentNullException("account is a required property for FIABCalculationParameters and cannot be null");
            // to ensure "dates" is required (not null)
            this.Dates = dates ?? throw new ArgumentNullException("dates is a required property for FIABCalculationParameters and cannot be null");
            this.Fiabdocument = fiabdocument;
            this.Msl = msl;
            this.Fisettingsdocument = fisettingsdocument;
        }
        
        /// <summary>
        /// FiabDocument (optional) - FIAB document to use as a template. Should  be a path to a FIAB document. Expects a GUI-style path (Client:/foo/bar)
        /// </summary>
        /// <value>FiabDocument (optional) - FIAB document to use as a template. Should  be a path to a FIAB document. Expects a GUI-style path (Client:/foo/bar)</value>
        [DataMember(Name="fiabdocument", EmitDefaultValue=false)]
        public string Fiabdocument { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name="account", EmitDefaultValue=false)]
        public FIABIdentifier Account { get; set; }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name="dates", EmitDefaultValue=false)]
        public FIABDateParameters Dates { get; set; }

        /// <summary>
        /// Master Security List. Analytics results will be written to the selected MSL. Expects a GUI-style path (Client:/foo/bar)
        /// </summary>
        /// <value>Master Security List. Analytics results will be written to the selected MSL. Expects a GUI-style path (Client:/foo/bar)</value>
        [DataMember(Name="msl", EmitDefaultValue=false)]
        public string Msl { get; set; }

        /// <summary>
        /// FISettingsDocument (optional) - The given @FIS document will be used to  configure analytics assumptions and settings. Expects a GUI-style path (Client:/foo/bar)
        /// </summary>
        /// <value>FISettingsDocument (optional) - The given @FIS document will be used to  configure analytics assumptions and settings. Expects a GUI-style path (Client:/foo/bar)</value>
        [DataMember(Name="fisettingsdocument", EmitDefaultValue=false)]
        public string Fisettingsdocument { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIABCalculationParameters {\n");
            sb.Append("  Fiabdocument: ").Append(Fiabdocument).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
            sb.Append("  Msl: ").Append(Msl).Append("\n");
            sb.Append("  Fisettingsdocument: ").Append(Fisettingsdocument).Append("\n");
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
            return this.Equals(input as FIABCalculationParameters);
        }

        /// <summary>
        /// Returns true if FIABCalculationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of FIABCalculationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIABCalculationParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Fiabdocument == input.Fiabdocument ||
                    (this.Fiabdocument != null &&
                    this.Fiabdocument.Equals(input.Fiabdocument))
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
                    this.Msl == input.Msl ||
                    (this.Msl != null &&
                    this.Msl.Equals(input.Msl))
                ) && 
                (
                    this.Fisettingsdocument == input.Fisettingsdocument ||
                    (this.Fisettingsdocument != null &&
                    this.Fisettingsdocument.Equals(input.Fisettingsdocument))
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
                if (this.Fiabdocument != null)
                    hashCode = hashCode * 59 + this.Fiabdocument.GetHashCode();
                if (this.Account != null)
                    hashCode = hashCode * 59 + this.Account.GetHashCode();
                if (this.Dates != null)
                    hashCode = hashCode * 59 + this.Dates.GetHashCode();
                if (this.Msl != null)
                    hashCode = hashCode * 59 + this.Msl.GetHashCode();
                if (this.Fisettingsdocument != null)
                    hashCode = hashCode * 59 + this.Fisettingsdocument.GetHashCode();
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
