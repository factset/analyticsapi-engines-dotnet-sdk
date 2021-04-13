/* 
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
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
    /// OptimalPortfolio
    /// </summary>
    [DataContract]
    public partial class OptimalPortfolio :  IEquatable<OptimalPortfolio>, IValidatableObject
    {
        /// <summary>
        /// Archive action if account exists
        /// </summary>
        /// <value>Archive action if account exists</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IfAcctExistsEnum
        {
            /// <summary>
            /// Enum Abort for value: abort
            /// </summary>
            [EnumMember(Value = "abort")]
            Abort = 1,

            /// <summary>
            /// Enum Overwrite for value: overwrite
            /// </summary>
            [EnumMember(Value = "overwrite")]
            Overwrite = 2,

            /// <summary>
            /// Enum AppendDate for value: appendDate
            /// </summary>
            [EnumMember(Value = "appendDate")]
            AppendDate = 3

        }

        /// <summary>
        /// Archive action if account exists
        /// </summary>
        /// <value>Archive action if account exists</value>
        [DataMember(Name="ifAcctExists", EmitDefaultValue=false)]
        public IfAcctExistsEnum? IfAcctExists { get; set; }
        /// <summary>
        /// Action if ofdb date exists
        /// </summary>
        /// <value>Action if ofdb date exists</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IfOfdbDateExistsEnum
        {
            /// <summary>
            /// Enum Abort for value: abort
            /// </summary>
            [EnumMember(Value = "abort")]
            Abort = 1,

            /// <summary>
            /// Enum ReplaceDate for value: replaceDate
            /// </summary>
            [EnumMember(Value = "replaceDate")]
            ReplaceDate = 2,

            /// <summary>
            /// Enum AppendSecurities for value: appendSecurities
            /// </summary>
            [EnumMember(Value = "appendSecurities")]
            AppendSecurities = 3

        }

        /// <summary>
        /// Action if ofdb date exists
        /// </summary>
        /// <value>Action if ofdb date exists</value>
        [DataMember(Name="ifOfdbDateExists", EmitDefaultValue=false)]
        public IfOfdbDateExistsEnum? IfOfdbDateExists { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimalPortfolio" /> class.
        /// </summary>
        /// <param name="acctName">Account path.</param>
        /// <param name="excludeZero">Exclude zero.</param>
        /// <param name="archiveDate">Archive date.</param>
        /// <param name="ifAcctExists">Archive action if account exists.</param>
        /// <param name="ifOfdbDateExists">Action if ofdb date exists.</param>
        public OptimalPortfolio(string acctName = default(string), bool excludeZero = default(bool), string archiveDate = default(string), IfAcctExistsEnum? ifAcctExists = default(IfAcctExistsEnum?), IfOfdbDateExistsEnum? ifOfdbDateExists = default(IfOfdbDateExistsEnum?))
        {
            this.AcctName = acctName;
            this.ExcludeZero = excludeZero;
            this.ArchiveDate = archiveDate;
            this.IfAcctExists = ifAcctExists;
            this.IfOfdbDateExists = ifOfdbDateExists;
        }
        
        /// <summary>
        /// Account path
        /// </summary>
        /// <value>Account path</value>
        [DataMember(Name="acctName", EmitDefaultValue=false)]
        public string AcctName { get; set; }

        /// <summary>
        /// Exclude zero
        /// </summary>
        /// <value>Exclude zero</value>
        [DataMember(Name="excludeZero", EmitDefaultValue=false)]
        public bool ExcludeZero { get; set; }

        /// <summary>
        /// Archive date
        /// </summary>
        /// <value>Archive date</value>
        [DataMember(Name="archiveDate", EmitDefaultValue=false)]
        public string ArchiveDate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OptimalPortfolio {\n");
            sb.Append("  AcctName: ").Append(AcctName).Append("\n");
            sb.Append("  ExcludeZero: ").Append(ExcludeZero).Append("\n");
            sb.Append("  ArchiveDate: ").Append(ArchiveDate).Append("\n");
            sb.Append("  IfAcctExists: ").Append(IfAcctExists).Append("\n");
            sb.Append("  IfOfdbDateExists: ").Append(IfOfdbDateExists).Append("\n");
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
            return this.Equals(input as OptimalPortfolio);
        }

        /// <summary>
        /// Returns true if OptimalPortfolio instances are equal
        /// </summary>
        /// <param name="input">Instance of OptimalPortfolio to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OptimalPortfolio input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AcctName == input.AcctName ||
                    (this.AcctName != null &&
                    this.AcctName.Equals(input.AcctName))
                ) && 
                (
                    this.ExcludeZero == input.ExcludeZero ||
                    this.ExcludeZero.Equals(input.ExcludeZero)
                ) && 
                (
                    this.ArchiveDate == input.ArchiveDate ||
                    (this.ArchiveDate != null &&
                    this.ArchiveDate.Equals(input.ArchiveDate))
                ) && 
                (
                    this.IfAcctExists == input.IfAcctExists ||
                    this.IfAcctExists.Equals(input.IfAcctExists)
                ) && 
                (
                    this.IfOfdbDateExists == input.IfOfdbDateExists ||
                    this.IfOfdbDateExists.Equals(input.IfOfdbDateExists)
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
                if (this.AcctName != null)
                    hashCode = hashCode * 59 + this.AcctName.GetHashCode();
                hashCode = hashCode * 59 + this.ExcludeZero.GetHashCode();
                if (this.ArchiveDate != null)
                    hashCode = hashCode * 59 + this.ArchiveDate.GetHashCode();
                hashCode = hashCode * 59 + this.IfAcctExists.GetHashCode();
                hashCode = hashCode * 59 + this.IfOfdbDateExists.GetHashCode();
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
