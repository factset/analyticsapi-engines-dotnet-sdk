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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// QuantDateList
    /// </summary>
    [DataContract(Name = "QuantDateList")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    public partial class QuantDateList : QuantDate, IEquatable<QuantDateList>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantDateList" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantDateList() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantDateList" /> class.
        /// </summary>
        /// <param name="dates">dates.</param>
        /// <param name="type">type (required) (default to &quot;QuantDateList&quot;).</param>
        /// <param name="source">source (required).</param>
        /// <param name="frequency">frequency (required).</param>
        /// <param name="calendar">calendar (required).</param>
        public QuantDateList(List<string> dates = default(List<string>), string type = "QuantDateList", SourceEnum source = default(SourceEnum), string frequency = default(string), string calendar = default(string)) : base(type, source, frequency, calendar)
        {
            this.Dates = dates;
        }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name = "dates", EmitDefaultValue = true)]
        public List<string> Dates { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantDateList {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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

            return base.Equals(input) && 
                (
                    this.Dates == input.Dates ||
                    this.Dates != null &&
                    input.Dates != null &&
                    this.Dates.SequenceEqual(input.Dates)
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
                int hashCode = base.GetHashCode();
                if (this.Dates != null)
                    hashCode = hashCode * 59 + this.Dates.GetHashCode();
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
