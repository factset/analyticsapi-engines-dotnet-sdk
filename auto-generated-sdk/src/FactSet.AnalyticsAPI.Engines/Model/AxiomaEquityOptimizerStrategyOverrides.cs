/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
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
    /// AxiomaEquityOptimizerStrategyOverrides
    /// </summary>
    [DataContract(Name = "AxiomaEquityOptimizerStrategyOverrides")]
    public partial class AxiomaEquityOptimizerStrategyOverrides : IEquatable<AxiomaEquityOptimizerStrategyOverrides>, IValidatableObject
    {
        /// <summary>
        /// Defines Inner
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum InnerEnum
        {
            /// <summary>
            /// Enum Disable for value: Disable
            /// </summary>
            [EnumMember(Value = "Disable")]
            Disable = 1,

            /// <summary>
            /// Enum Enable for value: Enable
            /// </summary>
            [EnumMember(Value = "Enable")]
            Enable = 2

        }


        /// <summary>
        /// List of constraints
        /// </summary>
        /// <value>List of constraints</value>
        [DataMember(Name = "constraints", EmitDefaultValue = false)]
        public Dictionary<string, InnerEnum> Constraints { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AxiomaEquityOptimizerStrategyOverrides" /> class.
        /// </summary>
        /// <param name="objective">Objective.</param>
        /// <param name="tax">Tax.</param>
        /// <param name="constraints">List of constraints.</param>
        /// <param name="alpha">Alpha.</param>
        /// <param name="transactionCost">Transaction cost.</param>
        public AxiomaEquityOptimizerStrategyOverrides(string objective = default(string), string tax = default(string), Dictionary<string, InnerEnum> constraints = default(Dictionary<string, InnerEnum>), string alpha = default(string), string transactionCost = default(string))
        {
            this.Objective = objective;
            this.Tax = tax;
            this.Constraints = constraints;
            this.Alpha = alpha;
            this.TransactionCost = transactionCost;
        }

        /// <summary>
        /// Objective
        /// </summary>
        /// <value>Objective</value>
        [DataMember(Name = "objective", EmitDefaultValue = false)]
        public string Objective { get; set; }

        /// <summary>
        /// Tax
        /// </summary>
        /// <value>Tax</value>
        [DataMember(Name = "tax", EmitDefaultValue = false)]
        public string Tax { get; set; }

        /// <summary>
        /// Alpha
        /// </summary>
        /// <value>Alpha</value>
        [DataMember(Name = "alpha", EmitDefaultValue = false)]
        public string Alpha { get; set; }

        /// <summary>
        /// Transaction cost
        /// </summary>
        /// <value>Transaction cost</value>
        [DataMember(Name = "transactionCost", EmitDefaultValue = false)]
        public string TransactionCost { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AxiomaEquityOptimizerStrategyOverrides {\n");
            sb.Append("  Objective: ").Append(Objective).Append("\n");
            sb.Append("  Tax: ").Append(Tax).Append("\n");
            sb.Append("  Constraints: ").Append(Constraints).Append("\n");
            sb.Append("  Alpha: ").Append(Alpha).Append("\n");
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
            return this.Equals(input as AxiomaEquityOptimizerStrategyOverrides);
        }

        /// <summary>
        /// Returns true if AxiomaEquityOptimizerStrategyOverrides instances are equal
        /// </summary>
        /// <param name="input">Instance of AxiomaEquityOptimizerStrategyOverrides to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AxiomaEquityOptimizerStrategyOverrides input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Objective == input.Objective ||
                    (this.Objective != null &&
                    this.Objective.Equals(input.Objective))
                ) && 
                (
                    this.Tax == input.Tax ||
                    (this.Tax != null &&
                    this.Tax.Equals(input.Tax))
                ) && 
                (
                    this.Constraints == input.Constraints ||
                    this.Constraints.SequenceEqual(input.Constraints)
                ) && 
                (
                    this.Alpha == input.Alpha ||
                    (this.Alpha != null &&
                    this.Alpha.Equals(input.Alpha))
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
                if (this.Objective != null)
                    hashCode = hashCode * 59 + this.Objective.GetHashCode();
                if (this.Tax != null)
                    hashCode = hashCode * 59 + this.Tax.GetHashCode();
                hashCode = hashCode * 59 + this.Constraints.GetHashCode();
                if (this.Alpha != null)
                    hashCode = hashCode * 59 + this.Alpha.GetHashCode();
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
