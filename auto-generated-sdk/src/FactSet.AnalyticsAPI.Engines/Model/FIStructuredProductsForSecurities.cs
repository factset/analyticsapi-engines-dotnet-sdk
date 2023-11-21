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
    /// FIStructuredProductsForSecurities
    /// </summary>
    [DataContract(Name = "FIStructuredProductsForSecurities")]
    public partial class FIStructuredProductsForSecurities : IEquatable<FIStructuredProductsForSecurities>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIStructuredProductsForSecurities" /> class.
        /// </summary>
        /// <param name="servicerAdvances">servicerAdvances.</param>
        /// <param name="ignoreFinancialGuarantee">Ignore Financial Guarantee.</param>
        /// <param name="cleanUpCallMethod">Cleanup Call Method.</param>
        /// <param name="doOPTRedeem">Do OPT Redeem.</param>
        /// <param name="prepayLockout">prepayLockout.</param>
        /// <param name="cashflows">cashflows.</param>
        /// <param name="balloonExtension">balloonExtension.</param>
        public FIStructuredProductsForSecurities(FIServicerAdvancesForSecurities servicerAdvances = default(FIServicerAdvancesForSecurities), string ignoreFinancialGuarantee = default(string), bool cleanUpCallMethod = default(bool), string doOPTRedeem = default(string), FIPrepayLockout prepayLockout = default(FIPrepayLockout), FICashflows cashflows = default(FICashflows), FIBalloonExtension balloonExtension = default(FIBalloonExtension))
        {
            this.ServicerAdvances = servicerAdvances;
            this.IgnoreFinancialGuarantee = ignoreFinancialGuarantee;
            this.CleanUpCallMethod = cleanUpCallMethod;
            this.DoOPTRedeem = doOPTRedeem;
            this.PrepayLockout = prepayLockout;
            this.Cashflows = cashflows;
            this.BalloonExtension = balloonExtension;
        }

        /// <summary>
        /// Gets or Sets ServicerAdvances
        /// </summary>
        [DataMember(Name = "servicerAdvances", EmitDefaultValue = false)]
        public FIServicerAdvancesForSecurities ServicerAdvances { get; set; }

        /// <summary>
        /// Ignore Financial Guarantee
        /// </summary>
        /// <value>Ignore Financial Guarantee</value>
        [DataMember(Name = "ignoreFinancialGuarantee", EmitDefaultValue = false)]
        public string IgnoreFinancialGuarantee { get; set; }

        /// <summary>
        /// Cleanup Call Method
        /// </summary>
        /// <value>Cleanup Call Method</value>
        [DataMember(Name = "cleanUpCallMethod", EmitDefaultValue = false)]
        public bool CleanUpCallMethod { get; set; }

        /// <summary>
        /// Do OPT Redeem
        /// </summary>
        /// <value>Do OPT Redeem</value>
        [DataMember(Name = "doOPTRedeem", EmitDefaultValue = false)]
        public string DoOPTRedeem { get; set; }

        /// <summary>
        /// Gets or Sets PrepayLockout
        /// </summary>
        [DataMember(Name = "prepayLockout", EmitDefaultValue = false)]
        public FIPrepayLockout PrepayLockout { get; set; }

        /// <summary>
        /// Gets or Sets Cashflows
        /// </summary>
        [DataMember(Name = "cashflows", EmitDefaultValue = false)]
        public FICashflows Cashflows { get; set; }

        /// <summary>
        /// Gets or Sets BalloonExtension
        /// </summary>
        [DataMember(Name = "balloonExtension", EmitDefaultValue = false)]
        public FIBalloonExtension BalloonExtension { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIStructuredProductsForSecurities {\n");
            sb.Append("  ServicerAdvances: ").Append(ServicerAdvances).Append("\n");
            sb.Append("  IgnoreFinancialGuarantee: ").Append(IgnoreFinancialGuarantee).Append("\n");
            sb.Append("  CleanUpCallMethod: ").Append(CleanUpCallMethod).Append("\n");
            sb.Append("  DoOPTRedeem: ").Append(DoOPTRedeem).Append("\n");
            sb.Append("  PrepayLockout: ").Append(PrepayLockout).Append("\n");
            sb.Append("  Cashflows: ").Append(Cashflows).Append("\n");
            sb.Append("  BalloonExtension: ").Append(BalloonExtension).Append("\n");
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
            return this.Equals(input as FIStructuredProductsForSecurities);
        }

        /// <summary>
        /// Returns true if FIStructuredProductsForSecurities instances are equal
        /// </summary>
        /// <param name="input">Instance of FIStructuredProductsForSecurities to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIStructuredProductsForSecurities input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ServicerAdvances == input.ServicerAdvances ||
                    (this.ServicerAdvances != null &&
                    this.ServicerAdvances.Equals(input.ServicerAdvances))
                ) && 
                (
                    this.IgnoreFinancialGuarantee == input.IgnoreFinancialGuarantee ||
                    (this.IgnoreFinancialGuarantee != null &&
                    this.IgnoreFinancialGuarantee.Equals(input.IgnoreFinancialGuarantee))
                ) && 
                (
                    this.CleanUpCallMethod == input.CleanUpCallMethod ||
                    this.CleanUpCallMethod.Equals(input.CleanUpCallMethod)
                ) && 
                (
                    this.DoOPTRedeem == input.DoOPTRedeem ||
                    (this.DoOPTRedeem != null &&
                    this.DoOPTRedeem.Equals(input.DoOPTRedeem))
                ) && 
                (
                    this.PrepayLockout == input.PrepayLockout ||
                    (this.PrepayLockout != null &&
                    this.PrepayLockout.Equals(input.PrepayLockout))
                ) && 
                (
                    this.Cashflows == input.Cashflows ||
                    (this.Cashflows != null &&
                    this.Cashflows.Equals(input.Cashflows))
                ) && 
                (
                    this.BalloonExtension == input.BalloonExtension ||
                    (this.BalloonExtension != null &&
                    this.BalloonExtension.Equals(input.BalloonExtension))
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
                if (this.ServicerAdvances != null)
                    hashCode = hashCode * 59 + this.ServicerAdvances.GetHashCode();
                if (this.IgnoreFinancialGuarantee != null)
                    hashCode = hashCode * 59 + this.IgnoreFinancialGuarantee.GetHashCode();
                hashCode = hashCode * 59 + this.CleanUpCallMethod.GetHashCode();
                if (this.DoOPTRedeem != null)
                    hashCode = hashCode * 59 + this.DoOPTRedeem.GetHashCode();
                if (this.PrepayLockout != null)
                    hashCode = hashCode * 59 + this.PrepayLockout.GetHashCode();
                if (this.Cashflows != null)
                    hashCode = hashCode * 59 + this.Cashflows.GetHashCode();
                if (this.BalloonExtension != null)
                    hashCode = hashCode * 59 + this.BalloonExtension.GetHashCode();
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
