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
    /// FIBankLoans
    /// </summary>
    [DataContract(Name = "FIBankLoans")]
    public partial class FIBankLoans : IEquatable<FIBankLoans>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIBankLoans" /> class.
        /// </summary>
        /// <param name="ignoreSinkingFund">Ignore Sinking Fund.</param>
        public FIBankLoans(bool ignoreSinkingFund = default(bool))
        {
            this.IgnoreSinkingFund = ignoreSinkingFund;
        }

        /// <summary>
        /// Ignore Sinking Fund
        /// </summary>
        /// <value>Ignore Sinking Fund</value>
        [DataMember(Name = "ignoreSinkingFund", EmitDefaultValue = false)]
        public bool IgnoreSinkingFund { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIBankLoans {\n");
            sb.Append("  IgnoreSinkingFund: ").Append(IgnoreSinkingFund).Append("\n");
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
            return this.Equals(input as FIBankLoans);
        }

        /// <summary>
        /// Returns true if FIBankLoans instances are equal
        /// </summary>
        /// <param name="input">Instance of FIBankLoans to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIBankLoans input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.IgnoreSinkingFund == input.IgnoreSinkingFund ||
                    this.IgnoreSinkingFund.Equals(input.IgnoreSinkingFund)
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
                hashCode = hashCode * 59 + this.IgnoreSinkingFund.GetHashCode();
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
