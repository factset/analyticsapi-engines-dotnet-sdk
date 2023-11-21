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
    /// BPMOptimizerStrategyOverrides
    /// </summary>
    [DataContract(Name = "BPMOptimizerStrategyOverrides")]
    public partial class BPMOptimizerStrategyOverrides : IEquatable<BPMOptimizerStrategyOverrides>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BPMOptimizerStrategyOverrides" /> class.
        /// </summary>
        /// <param name="constraints">List of constraints.</param>
        /// <param name="alpha">alpha.</param>
        /// <param name="tax">Tax  Can be set to \&quot;\&quot; for local.</param>
        /// <param name="transactionCost">Transaction cost  Can be set to \&quot;\&quot; for local.</param>
        public BPMOptimizerStrategyOverrides(List<ConstraintAction> constraints = default(List<ConstraintAction>), BPMOptimizerStrategyAlphaOverride alpha = default(BPMOptimizerStrategyAlphaOverride), string tax = default(string), string transactionCost = default(string))
        {
            this.Constraints = constraints;
            this.Alpha = alpha;
            this.Tax = tax;
            this.TransactionCost = transactionCost;
        }

        /// <summary>
        /// List of constraints
        /// </summary>
        /// <value>List of constraints</value>
        [DataMember(Name = "constraints", EmitDefaultValue = false)]
        public List<ConstraintAction> Constraints { get; set; }

        /// <summary>
        /// Gets or Sets Alpha
        /// </summary>
        [DataMember(Name = "alpha", EmitDefaultValue = false)]
        public BPMOptimizerStrategyAlphaOverride Alpha { get; set; }

        /// <summary>
        /// Tax  Can be set to \&quot;\&quot; for local
        /// </summary>
        /// <value>Tax  Can be set to \&quot;\&quot; for local</value>
        [DataMember(Name = "tax", EmitDefaultValue = false)]
        public string Tax { get; set; }

        /// <summary>
        /// Transaction cost  Can be set to \&quot;\&quot; for local
        /// </summary>
        /// <value>Transaction cost  Can be set to \&quot;\&quot; for local</value>
        [DataMember(Name = "transactionCost", EmitDefaultValue = false)]
        public string TransactionCost { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BPMOptimizerStrategyOverrides {\n");
            sb.Append("  Constraints: ").Append(Constraints).Append("\n");
            sb.Append("  Alpha: ").Append(Alpha).Append("\n");
            sb.Append("  Tax: ").Append(Tax).Append("\n");
            sb.Append("  TransactionCost: ").Append(TransactionCost).Append("\n");
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
            return this.Equals(input as BPMOptimizerStrategyOverrides);
        }

        /// <summary>
        /// Returns true if BPMOptimizerStrategyOverrides instances are equal
        /// </summary>
        /// <param name="input">Instance of BPMOptimizerStrategyOverrides to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BPMOptimizerStrategyOverrides input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Constraints == input.Constraints ||
                    this.Constraints != null &&
                    input.Constraints != null &&
                    this.Constraints.SequenceEqual(input.Constraints)
                ) && 
                (
                    this.Alpha == input.Alpha ||
                    (this.Alpha != null &&
                    this.Alpha.Equals(input.Alpha))
                ) && 
                (
                    this.Tax == input.Tax ||
                    (this.Tax != null &&
                    this.Tax.Equals(input.Tax))
                ) && 
                (
                    this.TransactionCost == input.TransactionCost ||
                    (this.TransactionCost != null &&
                    this.TransactionCost.Equals(input.TransactionCost))
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
                if (this.Constraints != null)
                    hashCode = hashCode * 59 + this.Constraints.GetHashCode();
                if (this.Alpha != null)
                    hashCode = hashCode * 59 + this.Alpha.GetHashCode();
                if (this.Tax != null)
                    hashCode = hashCode * 59 + this.Tax.GetHashCode();
                if (this.TransactionCost != null)
                    hashCode = hashCode * 59 + this.TransactionCost.GetHashCode();
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
