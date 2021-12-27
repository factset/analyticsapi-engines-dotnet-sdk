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
    /// FPOOptimizationParameters
    /// </summary>
    [DataContract(Name = "FPOOptimizationParameters")]
    public partial class FPOOptimizationParameters : IEquatable<FPOOptimizationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FPOOptimizationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FPOOptimizationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FPOOptimizationParameters" /> class.
        /// </summary>
        /// <param name="account">account.</param>
        /// <param name="strategy">strategy (required).</param>
        /// <param name="optimization">optimization.</param>
        /// <param name="outputTypes">outputTypes (required).</param>
        public FPOOptimizationParameters(FPOAccount account = default(FPOAccount), FPOOptimizerStrategy strategy = default(FPOOptimizerStrategy), Optimization optimization = default(Optimization), OptimizerOutputTypes outputTypes = default(OptimizerOutputTypes))
        {
            // to ensure "strategy" is required (not null)
            if (strategy == null) {
                throw new ArgumentNullException("strategy is a required property for FPOOptimizationParameters and cannot be null");
            }
            this.Strategy = strategy;
            // to ensure "outputTypes" is required (not null)
            if (outputTypes == null) {
                throw new ArgumentNullException("outputTypes is a required property for FPOOptimizationParameters and cannot be null");
            }
            this.OutputTypes = outputTypes;
            this.Account = account;
            this.Optimization = optimization;
        }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name = "account", EmitDefaultValue = false)]
        public FPOAccount Account { get; set; }

        /// <summary>
        /// Gets or Sets Strategy
        /// </summary>
        [DataMember(Name = "strategy", IsRequired = true, EmitDefaultValue = false)]
        public FPOOptimizerStrategy Strategy { get; set; }

        /// <summary>
        /// Gets or Sets Optimization
        /// </summary>
        [DataMember(Name = "optimization", EmitDefaultValue = false)]
        public Optimization Optimization { get; set; }

        /// <summary>
        /// Gets or Sets OutputTypes
        /// </summary>
        [DataMember(Name = "outputTypes", IsRequired = true, EmitDefaultValue = false)]
        public OptimizerOutputTypes OutputTypes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class FPOOptimizationParameters {\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Strategy: ").Append(Strategy).Append("\n");
            sb.Append("  Optimization: ").Append(Optimization).Append("\n");
            sb.Append("  OutputTypes: ").Append(OutputTypes).Append("\n");
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
            return this.Equals(input as FPOOptimizationParameters);
        }

        /// <summary>
        /// Returns true if FPOOptimizationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of FPOOptimizationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FPOOptimizationParameters input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Strategy == input.Strategy ||
                    (this.Strategy != null &&
                    this.Strategy.Equals(input.Strategy))
                ) && 
                (
                    this.Optimization == input.Optimization ||
                    (this.Optimization != null &&
                    this.Optimization.Equals(input.Optimization))
                ) && 
                (
                    this.OutputTypes == input.OutputTypes ||
                    (this.OutputTypes != null &&
                    this.OutputTypes.Equals(input.OutputTypes))
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
                if (this.Account != null)
                {
                    hashCode = (hashCode * 59) + this.Account.GetHashCode();
                }
                if (this.Strategy != null)
                {
                    hashCode = (hashCode * 59) + this.Strategy.GetHashCode();
                }
                if (this.Optimization != null)
                {
                    hashCode = (hashCode * 59) + this.Optimization.GetHashCode();
                }
                if (this.OutputTypes != null)
                {
                    hashCode = (hashCode * 59) + this.OutputTypes.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
