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
    /// FIMunicipalBonds
    /// </summary>
    [DataContract(Name = "FIMunicipalBonds")]
    public partial class FIMunicipalBonds : IEquatable<FIMunicipalBonds>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIMunicipalBonds" /> class.
        /// </summary>
        /// <param name="ignoreSinkingFund">Ignore Sinking Fund Schedule.</param>
        /// <param name="useAnticipatedSinkSchedule">Anticipate Sink Schedule.</param>
        public FIMunicipalBonds(bool ignoreSinkingFund = default(bool), bool useAnticipatedSinkSchedule = default(bool))
        {
            this.IgnoreSinkingFund = ignoreSinkingFund;
            this.UseAnticipatedSinkSchedule = useAnticipatedSinkSchedule;
        }

        /// <summary>
        /// Ignore Sinking Fund Schedule
        /// </summary>
        /// <value>Ignore Sinking Fund Schedule</value>
        [DataMember(Name = "ignoreSinkingFund", EmitDefaultValue = false)]
        public bool IgnoreSinkingFund { get; set; }

        /// <summary>
        /// Anticipate Sink Schedule
        /// </summary>
        /// <value>Anticipate Sink Schedule</value>
        [DataMember(Name = "useAnticipatedSinkSchedule", EmitDefaultValue = false)]
        public bool UseAnticipatedSinkSchedule { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIMunicipalBonds {\n");
            sb.Append("  IgnoreSinkingFund: ").Append(IgnoreSinkingFund).Append("\n");
            sb.Append("  UseAnticipatedSinkSchedule: ").Append(UseAnticipatedSinkSchedule).Append("\n");
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
            return this.Equals(input as FIMunicipalBonds);
        }

        /// <summary>
        /// Returns true if FIMunicipalBonds instances are equal
        /// </summary>
        /// <param name="input">Instance of FIMunicipalBonds to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIMunicipalBonds input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.IgnoreSinkingFund == input.IgnoreSinkingFund ||
                    this.IgnoreSinkingFund.Equals(input.IgnoreSinkingFund)
                ) && 
                (
                    this.UseAnticipatedSinkSchedule == input.UseAnticipatedSinkSchedule ||
                    this.UseAnticipatedSinkSchedule.Equals(input.UseAnticipatedSinkSchedule)
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
                hashCode = hashCode * 59 + this.UseAnticipatedSinkSchedule.GetHashCode();
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