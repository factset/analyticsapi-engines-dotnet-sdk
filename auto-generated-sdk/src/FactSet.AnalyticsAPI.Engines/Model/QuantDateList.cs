/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo],v1:[fiab]
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
    /// QuantDateList
    /// </summary>
    [DataContract(Name = "QuantDateList")]
    public partial class QuantDateList : IEquatable<QuantDateList>, IValidatableObject
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
        /// Initializes a new instance of the <see cref="QuantDateList" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantDateList() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantDateList" /> class.
        /// </summary>
        /// <param name="dates">dates.</param>
        /// <param name="source">source (required).</param>
        /// <param name="frequency">frequency (required).</param>
        /// <param name="calendar">calendar (required).</param>
        /// <param name="overrideUniversalScreenCalendar">overrideUniversalScreenCalendar.</param>
        public QuantDateList(List<string> dates = default(List<string>), SourceEnum source = default(SourceEnum), string frequency = default(string), string calendar = default(string), bool overrideUniversalScreenCalendar = default(bool))
        {
            this.Source = source;
            // to ensure "frequency" is required (not null)
            this.Frequency = frequency ?? throw new ArgumentNullException("frequency is a required property for QuantDateList and cannot be null");
            // to ensure "calendar" is required (not null)
            this.Calendar = calendar ?? throw new ArgumentNullException("calendar is a required property for QuantDateList and cannot be null");
            this.Dates = dates;
            this.OverrideUniversalScreenCalendar = overrideUniversalScreenCalendar;
        }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name = "dates", EmitDefaultValue = false)]
        public List<string> Dates { get; set; }

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
        /// Gets or Sets OverrideUniversalScreenCalendar
        /// </summary>
        [DataMember(Name = "overrideUniversalScreenCalendar", EmitDefaultValue = false)]
        public bool OverrideUniversalScreenCalendar { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantDateList {\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Frequency: ").Append(Frequency).Append("\n");
            sb.Append("  Calendar: ").Append(Calendar).Append("\n");
            sb.Append("  OverrideUniversalScreenCalendar: ").Append(OverrideUniversalScreenCalendar).Append("\n");
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
            return this.Equals(input as QuantDateList);
        }

        /// <summary>
        /// Returns true if QuantDateList instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantDateList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantDateList input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Dates == input.Dates ||
                    this.Dates != null &&
                    input.Dates != null &&
                    this.Dates.SequenceEqual(input.Dates)
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
                ) && 
                (
                    this.OverrideUniversalScreenCalendar == input.OverrideUniversalScreenCalendar ||
                    this.OverrideUniversalScreenCalendar.Equals(input.OverrideUniversalScreenCalendar)
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
                if (this.Dates != null)
                    hashCode = hashCode * 59 + this.Dates.GetHashCode();
                hashCode = hashCode * 59 + this.Source.GetHashCode();
                if (this.Frequency != null)
                    hashCode = hashCode * 59 + this.Frequency.GetHashCode();
                if (this.Calendar != null)
                    hashCode = hashCode * 59 + this.Calendar.GetHashCode();
                hashCode = hashCode * 59 + this.OverrideUniversalScreenCalendar.GetHashCode();
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
