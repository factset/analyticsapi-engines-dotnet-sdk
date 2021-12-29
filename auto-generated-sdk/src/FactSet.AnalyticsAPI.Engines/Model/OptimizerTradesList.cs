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
    /// OptimizerTradesList
    /// </summary>
    [DataContract(Name = "OptimizerTradesList")]
    public partial class OptimizerTradesList : IEquatable<OptimizerTradesList>, IValidatableObject
    {
        /// <summary>
        /// Identifier type
        /// </summary>
        /// <value>Identifier type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IdentifierTypeEnum
        {
            /// <summary>
            /// Enum Asset for value: Asset
            /// </summary>
            [EnumMember(Value = "Asset")]
            Asset = 1,

            /// <summary>
            /// Enum Cusip for value: Cusip
            /// </summary>
            [EnumMember(Value = "Cusip")]
            Cusip = 2,

            /// <summary>
            /// Enum Isin for value: Isin
            /// </summary>
            [EnumMember(Value = "Isin")]
            Isin = 3,

            /// <summary>
            /// Enum RiskModel for value: RiskModel
            /// </summary>
            [EnumMember(Value = "RiskModel")]
            RiskModel = 4,

            /// <summary>
            /// Enum SedolChk for value: SedolChk
            /// </summary>
            [EnumMember(Value = "SedolChk")]
            SedolChk = 5,

            /// <summary>
            /// Enum Sedol for value: Sedol
            /// </summary>
            [EnumMember(Value = "Sedol")]
            Sedol = 6,

            /// <summary>
            /// Enum SymbologyCusip for value: SymbologyCusip
            /// </summary>
            [EnumMember(Value = "SymbologyCusip")]
            SymbologyCusip = 7,

            /// <summary>
            /// Enum Ticker for value: Ticker
            /// </summary>
            [EnumMember(Value = "Ticker")]
            Ticker = 8,

            /// <summary>
            /// Enum TickerRegion for value: TickerRegion
            /// </summary>
            [EnumMember(Value = "TickerRegion")]
            TickerRegion = 9,

            /// <summary>
            /// Enum User for value: User
            /// </summary>
            [EnumMember(Value = "User")]
            User = 10

        }


        /// <summary>
        /// Identifier type
        /// </summary>
        /// <value>Identifier type</value>
        [DataMember(Name = "identifierType", EmitDefaultValue = false)]
        public IdentifierTypeEnum? IdentifierType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="OptimizerTradesList" /> class.
        /// </summary>
        /// <param name="identifierType">Identifier type.</param>
        /// <param name="includeCash">Include cash.</param>
        public OptimizerTradesList(IdentifierTypeEnum? identifierType = default(IdentifierTypeEnum?), bool includeCash = default(bool))
        {
            this.IdentifierType = identifierType;
            this.IncludeCash = includeCash;
        }

        /// <summary>
        /// Include cash
        /// </summary>
        /// <value>Include cash</value>
        [DataMember(Name = "includeCash", EmitDefaultValue = true)]
        public bool IncludeCash { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class OptimizerTradesList {\n");
            sb.Append("  IdentifierType: ").Append(IdentifierType).Append("\n");
            sb.Append("  IncludeCash: ").Append(IncludeCash).Append("\n");
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
            return this.Equals(input as OptimizerTradesList);
        }

        /// <summary>
        /// Returns true if OptimizerTradesList instances are equal
        /// </summary>
        /// <param name="input">Instance of OptimizerTradesList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OptimizerTradesList input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.IdentifierType == input.IdentifierType ||
                    this.IdentifierType.Equals(input.IdentifierType)
                ) && 
                (
                    this.IncludeCash == input.IncludeCash ||
                    this.IncludeCash.Equals(input.IncludeCash)
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
                hashCode = (hashCode * 59) + this.IdentifierType.GetHashCode();
                hashCode = (hashCode * 59) + this.IncludeCash.GetHashCode();
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
