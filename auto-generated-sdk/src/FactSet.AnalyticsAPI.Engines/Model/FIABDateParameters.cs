/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
 * Contact: testapi@factset.com
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
    /// The date parameters for FIAB calculations.
    /// </summary>
    [DataContract(Name = "FIABDateParameters")]
    public partial class FIABDateParameters : IEquatable<FIABDateParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIABDateParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FIABDateParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FIABDateParameters" /> class.
        /// </summary>
        /// <param name="startdate">Calculation&#39;s start date. (required).</param>
        /// <param name="enddate">Calculation&#39;s end date. (required).</param>
        public FIABDateParameters(string startdate = default(string), string enddate = default(string))
        {
            // to ensure "startdate" is required (not null)
            this.Startdate = startdate ?? throw new ArgumentNullException("startdate is a required property for FIABDateParameters and cannot be null");
            // to ensure "enddate" is required (not null)
            this.Enddate = enddate ?? throw new ArgumentNullException("enddate is a required property for FIABDateParameters and cannot be null");
        }

        /// <summary>
        /// Calculation&#39;s start date.
        /// </summary>
        /// <value>Calculation&#39;s start date.</value>
        [DataMember(Name = "startdate", IsRequired = true, EmitDefaultValue = false)]
        public string Startdate { get; set; }

        /// <summary>
        /// Calculation&#39;s end date.
        /// </summary>
        /// <value>Calculation&#39;s end date.</value>
        [DataMember(Name = "enddate", IsRequired = true, EmitDefaultValue = false)]
        public string Enddate { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIABDateParameters {\n");
            sb.Append("  Startdate: ").Append(Startdate).Append("\n");
            sb.Append("  Enddate: ").Append(Enddate).Append("\n");
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
            return this.Equals(input as FIABDateParameters);
        }

        /// <summary>
        /// Returns true if FIABDateParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of FIABDateParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIABDateParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Startdate == input.Startdate ||
                    (this.Startdate != null &&
                    this.Startdate.Equals(input.Startdate))
                ) && 
                (
                    this.Enddate == input.Enddate ||
                    (this.Enddate != null &&
                    this.Enddate.Equals(input.Enddate))
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
                if (this.Startdate != null)
                    hashCode = hashCode * 59 + this.Startdate.GetHashCode();
                if (this.Enddate != null)
                    hashCode = hashCode * 59 + this.Enddate.GetHashCode();
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
