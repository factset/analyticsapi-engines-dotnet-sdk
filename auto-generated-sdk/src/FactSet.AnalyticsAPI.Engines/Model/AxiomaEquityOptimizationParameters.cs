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
    /// AxiomaEquityOptimizationParameters
    /// </summary>
    [DataContract]
    public partial class AxiomaEquityOptimizationParameters :  IEquatable<AxiomaEquityOptimizationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AxiomaEquityOptimizationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AxiomaEquityOptimizationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AxiomaEquityOptimizationParameters" /> class.
        /// </summary>
        /// <param name="strategy">strategy (required).</param>
        /// <param name="account">account.</param>
        /// <param name="optimization">optimization.</param>
        /// <param name="outputtypes">outputtypes (required).</param>
        public AxiomaEquityOptimizationParameters(Strategy strategy = default(Strategy), Account account = default(Account), Optimization optimization = default(Optimization), OutputTypes outputtypes = default(OutputTypes))
        {
            // to ensure "strategy" is required (not null)
            this.Strategy = strategy ?? throw new ArgumentNullException("strategy is a required property for AxiomaEquityOptimizationParameters and cannot be null");
            // to ensure "outputtypes" is required (not null)
            this.Outputtypes = outputtypes ?? throw new ArgumentNullException("outputtypes is a required property for AxiomaEquityOptimizationParameters and cannot be null");
            this.Account = account;
            this.Optimization = optimization;
        }
        
        /// <summary>
        /// Gets or Sets Strategy
        /// </summary>
        [DataMember(Name="strategy", EmitDefaultValue=false)]
        public Strategy Strategy { get; set; }

        /// <summary>
        /// Gets or Sets Account
        /// </summary>
        [DataMember(Name="account", EmitDefaultValue=false)]
        public Account Account { get; set; }

        /// <summary>
        /// Gets or Sets Optimization
        /// </summary>
        [DataMember(Name="optimization", EmitDefaultValue=false)]
        public Optimization Optimization { get; set; }

        /// <summary>
        /// Gets or Sets Outputtypes
        /// </summary>
        [DataMember(Name="outputtypes", EmitDefaultValue=false)]
        public OutputTypes Outputtypes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AxiomaEquityOptimizationParameters {\n");
            sb.Append("  Strategy: ").Append(Strategy).Append("\n");
            sb.Append("  Account: ").Append(Account).Append("\n");
            sb.Append("  Optimization: ").Append(Optimization).Append("\n");
            sb.Append("  Outputtypes: ").Append(Outputtypes).Append("\n");
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
            return this.Equals(input as AxiomaEquityOptimizationParameters);
        }

        /// <summary>
        /// Returns true if AxiomaEquityOptimizationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of AxiomaEquityOptimizationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AxiomaEquityOptimizationParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Strategy == input.Strategy ||
                    (this.Strategy != null &&
                    this.Strategy.Equals(input.Strategy))
                ) && 
                (
                    this.Account == input.Account ||
                    (this.Account != null &&
                    this.Account.Equals(input.Account))
                ) && 
                (
                    this.Optimization == input.Optimization ||
                    (this.Optimization != null &&
                    this.Optimization.Equals(input.Optimization))
                ) && 
                (
                    this.Outputtypes == input.Outputtypes ||
                    (this.Outputtypes != null &&
                    this.Outputtypes.Equals(input.Outputtypes))
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
                if (this.Strategy != null)
                    hashCode = hashCode * 59 + this.Strategy.GetHashCode();
                if (this.Account != null)
                    hashCode = hashCode * 59 + this.Account.GetHashCode();
                if (this.Optimization != null)
                    hashCode = hashCode * 59 + this.Optimization.GetHashCode();
                if (this.Outputtypes != null)
                    hashCode = hashCode * 59 + this.Outputtypes.GetHashCode();
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
