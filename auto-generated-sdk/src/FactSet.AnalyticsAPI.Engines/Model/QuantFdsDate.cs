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
    /// QuantFdsDate
    /// </summary>
    [DataContract(Name = "QuantFdsDate")]
    public partial class QuantFdsDate : IEquatable<QuantFdsDate>, IValidatableObject
    {
        /// <summary>
        /// Defines Source
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SourceEnum
        {
            /// <summary>
            /// Enum FdsDate for value: FdsDate
            /// </summary>
            [EnumMember(Value = "FdsDate")]
            FdsDate = 1,

            /// <summary>
            /// Enum DateList for value: DateList
            /// </summary>
            [EnumMember(Value = "DateList")]
            DateList = 2

        }

        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name = "source", IsRequired = true, EmitDefaultValue = false)]
        public SourceEnum Source { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantFdsDate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantFdsDate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantFdsDate" /> class.
        /// </summary>
        /// <param name="startDate">startDate (required).</param>
        /// <param name="endDate">endDate (required).</param>
        /// <param name="source">source (required).</param>
        /// <param name="frequency">frequency (required).</param>
        /// <param name="calendar">calendar (required).</param>
        public QuantFdsDate(string startDate = default(string), string endDate = default(string), SourceEnum source = default(SourceEnum), string frequency = default(string), string calendar = default(string))
        {
            // to ensure "startDate" is required (not null)
            this.StartDate = startDate ?? throw new ArgumentNullException("startDate is a required property for QuantFdsDate and cannot be null");
            // to ensure "endDate" is required (not null)
            this.EndDate = endDate ?? throw new ArgumentNullException("endDate is a required property for QuantFdsDate and cannot be null");
            this.Source = source;
            // to ensure "frequency" is required (not null)
            this.Frequency = frequency ?? throw new ArgumentNullException("frequency is a required property for QuantFdsDate and cannot be null");
            // to ensure "calendar" is required (not null)
            this.Calendar = calendar ?? throw new ArgumentNullException("calendar is a required property for QuantFdsDate and cannot be null");
        }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>
        [DataMember(Name = "startDate", IsRequired = true, EmitDefaultValue = false)]
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or Sets EndDate
        /// </summary>
        [DataMember(Name = "endDate", IsRequired = true, EmitDefaultValue = false)]
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or Sets Frequency
        /// </summary>
        [DataMember(Name = "frequency", IsRequired = true, EmitDefaultValue = false)]
        public string Frequency { get; set; }

        /// <summary>
        /// Gets or Sets Calendar
        /// </summary>
        [DataMember(Name = "calendar", IsRequired = true, EmitDefaultValue = false)]
        public string Calendar { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantFdsDate {\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  EndDate: ").Append(EndDate).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Frequency: ").Append(Frequency).Append("\n");
            sb.Append("  Calendar: ").Append(Calendar).Append("\n");
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
            return this.Equals(input as QuantFdsDate);
        }

        /// <summary>
        /// Returns true if QuantFdsDate instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantFdsDate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantFdsDate input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.StartDate == input.StartDate ||
                    (this.StartDate != null &&
                    this.StartDate.Equals(input.StartDate))
                ) && 
                (
                    this.EndDate == input.EndDate ||
                    (this.EndDate != null &&
                    this.EndDate.Equals(input.EndDate))
                ) && 
                (
                    this.Source == input.Source ||
                    this.Source.Equals(input.Source)
                ) && 
                (
                    this.Frequency == input.Frequency ||
                    (this.Frequency != null &&
                    this.Frequency.Equals(input.Frequency))
                ) && 
                (
                    this.Calendar == input.Calendar ||
                    (this.Calendar != null &&
                    this.Calendar.Equals(input.Calendar))
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
                if (this.StartDate != null)
                    hashCode = hashCode * 59 + this.StartDate.GetHashCode();
                if (this.EndDate != null)
                    hashCode = hashCode * 59 + this.EndDate.GetHashCode();
                hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.Frequency != null)
                    hashCode = hashCode * 59 + this.Frequency.GetHashCode();
                if (this.Calendar != null)
                    hashCode = hashCode * 59 + this.Calendar.GetHashCode();
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
