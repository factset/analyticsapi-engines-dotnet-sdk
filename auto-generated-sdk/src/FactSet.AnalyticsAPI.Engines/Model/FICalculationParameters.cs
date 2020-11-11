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
    /// FICalculationParameters
    /// </summary>
    [DataContract]
    public partial class FICalculationParameters :  IEquatable<FICalculationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FICalculationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FICalculationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FICalculationParameters" /> class.
        /// </summary>
        /// <param name="securities">securities (required).</param>
        /// <param name="calculations">calculations (required).</param>
        /// <param name="jobSettings">jobSettings (required).</param>
        public FICalculationParameters(List<Security> securities = default(List<Security>), List<string> calculations = default(List<string>), JobSettings jobSettings = default(JobSettings))
        {
            // to ensure "securities" is required (not null)
            this.Securities = securities ?? throw new ArgumentNullException("securities is a required property for FICalculationParameters and cannot be null");
            // to ensure "calculations" is required (not null)
            this.Calculations = calculations ?? throw new ArgumentNullException("calculations is a required property for FICalculationParameters and cannot be null");
            // to ensure "jobSettings" is required (not null)
            this.JobSettings = jobSettings ?? throw new ArgumentNullException("jobSettings is a required property for FICalculationParameters and cannot be null");
        }
        
        /// <summary>
        /// Gets or Sets Securities
        /// </summary>
        [DataMember(Name="securities", EmitDefaultValue=false)]
        public List<Security> Securities { get; set; }

        /// <summary>
        /// Gets or Sets Calculations
        /// </summary>
        [DataMember(Name="calculations", EmitDefaultValue=false)]
        public List<string> Calculations { get; set; }

        /// <summary>
        /// Gets or Sets JobSettings
        /// </summary>
        [DataMember(Name="jobSettings", EmitDefaultValue=false)]
        public JobSettings JobSettings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FICalculationParameters {\n");
            sb.Append("  Securities: ").Append(Securities).Append("\n");
            sb.Append("  Calculations: ").Append(Calculations).Append("\n");
            sb.Append("  JobSettings: ").Append(JobSettings).Append("\n");
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
            return this.Equals(input as FICalculationParameters);
        }

        /// <summary>
        /// Returns true if FICalculationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of FICalculationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FICalculationParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Securities == input.Securities ||
                    this.Securities != null &&
                    input.Securities != null &&
                    this.Securities.SequenceEqual(input.Securities)
                ) && 
                (
                    this.Calculations == input.Calculations ||
                    this.Calculations != null &&
                    input.Calculations != null &&
                    this.Calculations.SequenceEqual(input.Calculations)
                ) && 
                (
                    this.JobSettings == input.JobSettings ||
                    (this.JobSettings != null &&
                    this.JobSettings.Equals(input.JobSettings))
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
                if (this.Securities != null)
                    hashCode = hashCode * 59 + this.Securities.GetHashCode();
                if (this.Calculations != null)
                    hashCode = hashCode * 59 + this.Calculations.GetHashCode();
                if (this.JobSettings != null)
                    hashCode = hashCode * 59 + this.JobSettings.GetHashCode();
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
