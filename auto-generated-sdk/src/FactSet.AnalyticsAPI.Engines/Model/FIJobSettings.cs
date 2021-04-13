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
    /// FIJobSettings
    /// </summary>
    [DataContract]
    public partial class FIJobSettings :  IEquatable<FIJobSettings>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIJobSettings" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FIJobSettings() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FIJobSettings" /> class.
        /// </summary>
        /// <param name="asOfDate">asOfDate (required).</param>
        /// <param name="partialDurationMonths">partialDurationMonths.</param>
        public FIJobSettings(string asOfDate = default(string), List<int> partialDurationMonths = default(List<int>))
        {
            // to ensure "asOfDate" is required (not null)
            this.AsOfDate = asOfDate ?? throw new ArgumentNullException("asOfDate is a required property for FIJobSettings and cannot be null");
            this.PartialDurationMonths = partialDurationMonths;
        }
        
        /// <summary>
        /// Gets or Sets AsOfDate
        /// </summary>
        [DataMember(Name="asOfDate", EmitDefaultValue=false)]
        public string AsOfDate { get; set; }

        /// <summary>
        /// Gets or Sets PartialDurationMonths
        /// </summary>
        [DataMember(Name="partialDurationMonths", EmitDefaultValue=false)]
        public List<int> PartialDurationMonths { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIJobSettings {\n");
            sb.Append("  AsOfDate: ").Append(AsOfDate).Append("\n");
            sb.Append("  PartialDurationMonths: ").Append(PartialDurationMonths).Append("\n");
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
            return this.Equals(input as FIJobSettings);
        }

        /// <summary>
        /// Returns true if FIJobSettings instances are equal
        /// </summary>
        /// <param name="input">Instance of FIJobSettings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIJobSettings input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AsOfDate == input.AsOfDate ||
                    (this.AsOfDate != null &&
                    this.AsOfDate.Equals(input.AsOfDate))
                ) && 
                (
                    this.PartialDurationMonths == input.PartialDurationMonths ||
                    this.PartialDurationMonths != null &&
                    input.PartialDurationMonths != null &&
                    this.PartialDurationMonths.SequenceEqual(input.PartialDurationMonths)
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
                if (this.AsOfDate != null)
                    hashCode = hashCode * 59 + this.AsOfDate.GetHashCode();
                if (this.PartialDurationMonths != null)
                    hashCode = hashCode * 59 + this.PartialDurationMonths.GetHashCode();
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
