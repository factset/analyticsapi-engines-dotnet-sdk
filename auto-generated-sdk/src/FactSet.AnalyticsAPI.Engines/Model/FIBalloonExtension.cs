/*
 * Engines API
 *
 * Allow clients to fetch Analytics through API.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
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
    /// FIBalloonExtension
    /// </summary>
    [DataContract(Name = "FIBalloonExtension")]
    public partial class FIBalloonExtension : IEquatable<FIBalloonExtension>, IValidatableObject
    {
        /// <summary>
        /// Amortization Type
        /// </summary>
        /// <value>Amortization Type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum AmortizationTypeEnum
        {
            /// <summary>
            /// Enum None for value: Loan_Amort_None
            /// </summary>
            [EnumMember(Value = "Loan_Amort_None")]
            None = 1,

            /// <summary>
            /// Enum Regular for value: Loan_Amort_Regular
            /// </summary>
            [EnumMember(Value = "Loan_Amort_Regular")]
            Regular = 2,

            /// <summary>
            /// Enum Default for value: Loan_Amort_Default
            /// </summary>
            [EnumMember(Value = "Loan_Amort_Default")]
            Default = 3

        }

        /// <summary>
        /// Amortization Type
        /// </summary>
        /// <value>Amortization Type</value>
        [DataMember(Name = "amortizationType", EmitDefaultValue = false)]
        public AmortizationTypeEnum? AmortizationType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FIBalloonExtension" /> class.
        /// </summary>
        /// <param name="months">Months.</param>
        /// <param name="percentage">Percentage.</param>
        /// <param name="amortizationType">Amortization Type.</param>
        /// <param name="units">Units.</param>
        /// <param name="couponStepup">Coupon Stepup.</param>
        public FIBalloonExtension(int months = default(int), double percentage = default(double), AmortizationTypeEnum? amortizationType = default(AmortizationTypeEnum?), string units = default(string), double couponStepup = default(double))
        {
            this.Months = months;
            this.Percentage = percentage;
            this.AmortizationType = amortizationType;
            this.Units = units;
            this.CouponStepup = couponStepup;
        }

        /// <summary>
        /// Months
        /// </summary>
        /// <value>Months</value>
        [DataMember(Name = "months", EmitDefaultValue = false)]
        public int Months { get; set; }

        /// <summary>
        /// Percentage
        /// </summary>
        /// <value>Percentage</value>
        [DataMember(Name = "percentage", EmitDefaultValue = false)]
        public double Percentage { get; set; }

        /// <summary>
        /// Units
        /// </summary>
        /// <value>Units</value>
        [DataMember(Name = "units", EmitDefaultValue = false)]
        public string Units { get; set; }

        /// <summary>
        /// Coupon Stepup
        /// </summary>
        /// <value>Coupon Stepup</value>
        [DataMember(Name = "couponStepup", EmitDefaultValue = false)]
        public double CouponStepup { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIBalloonExtension {\n");
            sb.Append("  Months: ").Append(Months).Append("\n");
            sb.Append("  Percentage: ").Append(Percentage).Append("\n");
            sb.Append("  AmortizationType: ").Append(AmortizationType).Append("\n");
            sb.Append("  Units: ").Append(Units).Append("\n");
            sb.Append("  CouponStepup: ").Append(CouponStepup).Append("\n");
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
            return this.Equals(input as FIBalloonExtension);
        }

        /// <summary>
        /// Returns true if FIBalloonExtension instances are equal
        /// </summary>
        /// <param name="input">Instance of FIBalloonExtension to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIBalloonExtension input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Months == input.Months ||
                    this.Months.Equals(input.Months)
                ) && 
                (
                    this.Percentage == input.Percentage ||
                    this.Percentage.Equals(input.Percentage)
                ) && 
                (
                    this.AmortizationType == input.AmortizationType ||
                    this.AmortizationType.Equals(input.AmortizationType)
                ) && 
                (
                    this.Units == input.Units ||
                    (this.Units != null &&
                    this.Units.Equals(input.Units))
                ) && 
                (
                    this.CouponStepup == input.CouponStepup ||
                    this.CouponStepup.Equals(input.CouponStepup)
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
                hashCode = hashCode * 59 + this.Months.GetHashCode();
                hashCode = hashCode * 59 + this.Percentage.GetHashCode();
                hashCode = hashCode * 59 + this.AmortizationType.GetHashCode();
                if (this.Units != null)
                    hashCode = hashCode * 59 + this.Units.GetHashCode();
                hashCode = hashCode * 59 + this.CouponStepup.GetHashCode();
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
