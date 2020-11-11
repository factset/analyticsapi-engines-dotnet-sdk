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
    /// TradesList
    /// </summary>
    [DataContract]
    public partial class TradesList :  IEquatable<TradesList>, IValidatableObject
    {
        /// <summary>
        /// Identifier type
        /// </summary>
        /// <value>Identifier type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IdentifiertypeEnum
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
        [DataMember(Name="identifiertype", EmitDefaultValue=false)]
        public IdentifiertypeEnum? Identifiertype { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TradesList" /> class.
        /// </summary>
        /// <param name="identifiertype">Identifier type.</param>
        /// <param name="includecash">Include cash.</param>
        public TradesList(IdentifiertypeEnum? identifiertype = default(IdentifiertypeEnum?), bool includecash = default(bool))
        {
            this.Identifiertype = identifiertype;
            this.Includecash = includecash;
        }
        
        /// <summary>
        /// Include cash
        /// </summary>
        /// <value>Include cash</value>
        [DataMember(Name="includecash", EmitDefaultValue=false)]
        public bool Includecash { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TradesList {\n");
            sb.Append("  Identifiertype: ").Append(Identifiertype).Append("\n");
            sb.Append("  Includecash: ").Append(Includecash).Append("\n");
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
            return this.Equals(input as TradesList);
        }

        /// <summary>
        /// Returns true if TradesList instances are equal
        /// </summary>
        /// <param name="input">Instance of TradesList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TradesList input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Identifiertype == input.Identifiertype ||
                    this.Identifiertype.Equals(input.Identifiertype)
                ) && 
                (
                    this.Includecash == input.Includecash ||
                    this.Includecash.Equals(input.Includecash)
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
                hashCode = hashCode * 59 + this.Identifiertype.GetHashCode();
                hashCode = hashCode * 59 + this.Includecash.GetHashCode();
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
