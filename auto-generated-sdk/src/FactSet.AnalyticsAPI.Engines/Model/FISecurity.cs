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
    /// FISecurity
    /// </summary>
    [DataContract(Name = "FISecurity")]
    public partial class FISecurity : IEquatable<FISecurity>, IValidatableObject
    {
        /// <summary>
        /// Call Method
        /// </summary>
        /// <value>Call Method</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CallMethodEnum
        {
            /// <summary>
            /// Enum NoCall for value: No Call
            /// </summary>
            [EnumMember(Value = "No Call")]
            NoCall = 1,

            /// <summary>
            /// Enum IntrinsicValue for value: Intrinsic Value
            /// </summary>
            [EnumMember(Value = "Intrinsic Value")]
            IntrinsicValue = 2,

            /// <summary>
            /// Enum FirstCall for value: First Call
            /// </summary>
            [EnumMember(Value = "First Call")]
            FirstCall = 3,

            /// <summary>
            /// Enum FirstPar for value: First Par
            /// </summary>
            [EnumMember(Value = "First Par")]
            FirstPar = 4

        }

        /// <summary>
        /// Call Method
        /// </summary>
        /// <value>Call Method</value>
        [DataMember(Name = "callMethod", EmitDefaultValue = false)]
        public CallMethodEnum? CallMethod { get; set; }
        /// <summary>
        /// Face type
        /// </summary>
        /// <value>Face type</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FaceTypeEnum
        {
            /// <summary>
            /// Enum Current for value: Current
            /// </summary>
            [EnumMember(Value = "Current")]
            Current = 1,

            /// <summary>
            /// Enum Original for value: Original
            /// </summary>
            [EnumMember(Value = "Original")]
            Original = 2

        }

        /// <summary>
        /// Face type
        /// </summary>
        /// <value>Face type</value>
        [DataMember(Name = "faceType", EmitDefaultValue = false)]
        public FaceTypeEnum? FaceType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="FISecurity" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected FISecurity() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FISecurity" /> class.
        /// </summary>
        /// <param name="settlement">Settlement date.</param>
        /// <param name="callMethod">Call Method.</param>
        /// <param name="referenceSecurity">referenceSecurity.</param>
        /// <param name="bankLoans">bankLoans.</param>
        /// <param name="municipalBonds">municipalBonds.</param>
        /// <param name="loss">loss.</param>
        /// <param name="prepay">prepay.</param>
        /// <param name="matrixSpreadAdjustment">Matrix Spread Adjustment.</param>
        /// <param name="matrixMultiplier">Matrix Multiplier.</param>
        /// <param name="structuredProducts">structuredProducts.</param>
        /// <param name="calcFromMethod">Calculation Method.  Methods : Active Spread, Actual Spread, Actual Spread To Worst Call, OAS, Price, Yield, Yield To No Call, Act/Act Yield To No Call, Bond Equivalent Yield,  Yield To Worst Call, Discount Yield, Discount Margin, Implied Volatility, Bullet Spread, Bullet Spread To Worst Call, Pricing Matrix.</param>
        /// <param name="calcFromValue">Calculation from value (required).</param>
        /// <param name="face">Face (default to 1D).</param>
        /// <param name="faceType">Face type (default to FaceTypeEnum.Current).</param>
        /// <param name="symbol">Symbol (required).</param>
        /// <param name="discountCurve">Discount curve.</param>
        public FISecurity(string settlement = default(string), CallMethodEnum? callMethod = default(CallMethodEnum?), FIReferenceSecurity referenceSecurity = default(FIReferenceSecurity), FIBankLoans bankLoans = default(FIBankLoans), FIMunicipalBonds municipalBonds = default(FIMunicipalBonds), FILoss loss = default(FILoss), FIPrepay prepay = default(FIPrepay), double matrixSpreadAdjustment = default(double), double matrixMultiplier = default(double), FIStructuredProductsForSecurities structuredProducts = default(FIStructuredProductsForSecurities), string calcFromMethod = default(string), double calcFromValue = default(double), double face = 1D, FaceTypeEnum? faceType = FaceTypeEnum.Current, string symbol = default(string), string discountCurve = default(string))
        {
            this.CalcFromValue = calcFromValue;
            // to ensure "symbol" is required (not null)
            this.Symbol = symbol ?? throw new ArgumentNullException("symbol is a required property for FISecurity and cannot be null");
            this.Settlement = settlement;
            this.CallMethod = callMethod;
            this.ReferenceSecurity = referenceSecurity;
            this.BankLoans = bankLoans;
            this.MunicipalBonds = municipalBonds;
            this.Loss = loss;
            this.Prepay = prepay;
            this.MatrixSpreadAdjustment = matrixSpreadAdjustment;
            this.MatrixMultiplier = matrixMultiplier;
            this.StructuredProducts = structuredProducts;
            this.CalcFromMethod = calcFromMethod;
            this.Face = face;
            this.FaceType = faceType;
            this.DiscountCurve = discountCurve;
        }

        /// <summary>
        /// Settlement date
        /// </summary>
        /// <value>Settlement date</value>
        [DataMember(Name = "settlement", EmitDefaultValue = false)]
        public string Settlement { get; set; }

        /// <summary>
        /// Gets or Sets ReferenceSecurity
        /// </summary>
        [DataMember(Name = "referenceSecurity", EmitDefaultValue = false)]
        public FIReferenceSecurity ReferenceSecurity { get; set; }

        /// <summary>
        /// Gets or Sets BankLoans
        /// </summary>
        [DataMember(Name = "bankLoans", EmitDefaultValue = false)]
        public FIBankLoans BankLoans { get; set; }

        /// <summary>
        /// Gets or Sets MunicipalBonds
        /// </summary>
        [DataMember(Name = "municipalBonds", EmitDefaultValue = false)]
        public FIMunicipalBonds MunicipalBonds { get; set; }

        /// <summary>
        /// Gets or Sets Loss
        /// </summary>
        [DataMember(Name = "loss", EmitDefaultValue = false)]
        public FILoss Loss { get; set; }

        /// <summary>
        /// Gets or Sets Prepay
        /// </summary>
        [DataMember(Name = "prepay", EmitDefaultValue = false)]
        public FIPrepay Prepay { get; set; }

        /// <summary>
        /// Matrix Spread Adjustment
        /// </summary>
        /// <value>Matrix Spread Adjustment</value>
        [DataMember(Name = "matrixSpreadAdjustment", EmitDefaultValue = false)]
        public double MatrixSpreadAdjustment { get; set; }

        /// <summary>
        /// Matrix Multiplier
        /// </summary>
        /// <value>Matrix Multiplier</value>
        [DataMember(Name = "matrixMultiplier", EmitDefaultValue = false)]
        public double MatrixMultiplier { get; set; }

        /// <summary>
        /// Gets or Sets StructuredProducts
        /// </summary>
        [DataMember(Name = "structuredProducts", EmitDefaultValue = false)]
        public FIStructuredProductsForSecurities StructuredProducts { get; set; }

        /// <summary>
        /// Calculation Method.  Methods : Active Spread, Actual Spread, Actual Spread To Worst Call, OAS, Price, Yield, Yield To No Call, Act/Act Yield To No Call, Bond Equivalent Yield,  Yield To Worst Call, Discount Yield, Discount Margin, Implied Volatility, Bullet Spread, Bullet Spread To Worst Call, Pricing Matrix
        /// </summary>
        /// <value>Calculation Method.  Methods : Active Spread, Actual Spread, Actual Spread To Worst Call, OAS, Price, Yield, Yield To No Call, Act/Act Yield To No Call, Bond Equivalent Yield,  Yield To Worst Call, Discount Yield, Discount Margin, Implied Volatility, Bullet Spread, Bullet Spread To Worst Call, Pricing Matrix</value>
        [DataMember(Name = "calcFromMethod", EmitDefaultValue = false)]
        public string CalcFromMethod { get; set; }

        /// <summary>
        /// Calculation from value
        /// </summary>
        /// <value>Calculation from value</value>
        [DataMember(Name = "calcFromValue", IsRequired = true, EmitDefaultValue = false)]
        public double CalcFromValue { get; set; }

        /// <summary>
        /// Face
        /// </summary>
        /// <value>Face</value>
        [DataMember(Name = "face", EmitDefaultValue = false)]
        public double Face { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        /// <value>Symbol</value>
        [DataMember(Name = "symbol", IsRequired = true, EmitDefaultValue = false)]
        public string Symbol { get; set; }

        /// <summary>
        /// Discount curve
        /// </summary>
        /// <value>Discount curve</value>
        [DataMember(Name = "discountCurve", EmitDefaultValue = false)]
        public string DiscountCurve { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FISecurity {\n");
            sb.Append("  Settlement: ").Append(Settlement).Append("\n");
            sb.Append("  CallMethod: ").Append(CallMethod).Append("\n");
            sb.Append("  ReferenceSecurity: ").Append(ReferenceSecurity).Append("\n");
            sb.Append("  BankLoans: ").Append(BankLoans).Append("\n");
            sb.Append("  MunicipalBonds: ").Append(MunicipalBonds).Append("\n");
            sb.Append("  Loss: ").Append(Loss).Append("\n");
            sb.Append("  Prepay: ").Append(Prepay).Append("\n");
            sb.Append("  MatrixSpreadAdjustment: ").Append(MatrixSpreadAdjustment).Append("\n");
            sb.Append("  MatrixMultiplier: ").Append(MatrixMultiplier).Append("\n");
            sb.Append("  StructuredProducts: ").Append(StructuredProducts).Append("\n");
            sb.Append("  CalcFromMethod: ").Append(CalcFromMethod).Append("\n");
            sb.Append("  CalcFromValue: ").Append(CalcFromValue).Append("\n");
            sb.Append("  Face: ").Append(Face).Append("\n");
            sb.Append("  FaceType: ").Append(FaceType).Append("\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
            sb.Append("  DiscountCurve: ").Append(DiscountCurve).Append("\n");
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
            return this.Equals(input as FISecurity);
        }

        /// <summary>
        /// Returns true if FISecurity instances are equal
        /// </summary>
        /// <param name="input">Instance of FISecurity to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FISecurity input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Settlement == input.Settlement ||
                    (this.Settlement != null &&
                    this.Settlement.Equals(input.Settlement))
                ) && 
                (
                    this.CallMethod == input.CallMethod ||
                    this.CallMethod.Equals(input.CallMethod)
                ) && 
                (
                    this.ReferenceSecurity == input.ReferenceSecurity ||
                    (this.ReferenceSecurity != null &&
                    this.ReferenceSecurity.Equals(input.ReferenceSecurity))
                ) && 
                (
                    this.BankLoans == input.BankLoans ||
                    (this.BankLoans != null &&
                    this.BankLoans.Equals(input.BankLoans))
                ) && 
                (
                    this.MunicipalBonds == input.MunicipalBonds ||
                    (this.MunicipalBonds != null &&
                    this.MunicipalBonds.Equals(input.MunicipalBonds))
                ) && 
                (
                    this.Loss == input.Loss ||
                    (this.Loss != null &&
                    this.Loss.Equals(input.Loss))
                ) && 
                (
                    this.Prepay == input.Prepay ||
                    (this.Prepay != null &&
                    this.Prepay.Equals(input.Prepay))
                ) && 
                (
                    this.MatrixSpreadAdjustment == input.MatrixSpreadAdjustment ||
                    this.MatrixSpreadAdjustment.Equals(input.MatrixSpreadAdjustment)
                ) && 
                (
                    this.MatrixMultiplier == input.MatrixMultiplier ||
                    this.MatrixMultiplier.Equals(input.MatrixMultiplier)
                ) && 
                (
                    this.StructuredProducts == input.StructuredProducts ||
                    (this.StructuredProducts != null &&
                    this.StructuredProducts.Equals(input.StructuredProducts))
                ) && 
                (
                    this.CalcFromMethod == input.CalcFromMethod ||
                    (this.CalcFromMethod != null &&
                    this.CalcFromMethod.Equals(input.CalcFromMethod))
                ) && 
                (
                    this.CalcFromValue == input.CalcFromValue ||
                    this.CalcFromValue.Equals(input.CalcFromValue)
                ) && 
                (
                    this.Face == input.Face ||
                    this.Face.Equals(input.Face)
                ) && 
                (
                    this.FaceType == input.FaceType ||
                    this.FaceType.Equals(input.FaceType)
                ) && 
                (
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
                ) && 
                (
                    this.DiscountCurve == input.DiscountCurve ||
                    (this.DiscountCurve != null &&
                    this.DiscountCurve.Equals(input.DiscountCurve))
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
                if (this.Settlement != null)
                    hashCode = hashCode * 59 + this.Settlement.GetHashCode();
                hashCode = hashCode * 59 + this.CallMethod.GetHashCode();
                if (this.ReferenceSecurity != null)
                    hashCode = hashCode * 59 + this.ReferenceSecurity.GetHashCode();
                if (this.BankLoans != null)
                    hashCode = hashCode * 59 + this.BankLoans.GetHashCode();
                if (this.MunicipalBonds != null)
                    hashCode = hashCode * 59 + this.MunicipalBonds.GetHashCode();
                if (this.Loss != null)
                    hashCode = hashCode * 59 + this.Loss.GetHashCode();
                if (this.Prepay != null)
                    hashCode = hashCode * 59 + this.Prepay.GetHashCode();
                hashCode = hashCode * 59 + this.MatrixSpreadAdjustment.GetHashCode();
                hashCode = hashCode * 59 + this.MatrixMultiplier.GetHashCode();
                if (this.StructuredProducts != null)
                    hashCode = hashCode * 59 + this.StructuredProducts.GetHashCode();
                if (this.CalcFromMethod != null)
                    hashCode = hashCode * 59 + this.CalcFromMethod.GetHashCode();
                hashCode = hashCode * 59 + this.CalcFromValue.GetHashCode();
                hashCode = hashCode * 59 + this.Face.GetHashCode();
                hashCode = hashCode * 59 + this.FaceType.GetHashCode();
                if (this.Symbol != null)
                    hashCode = hashCode * 59 + this.Symbol.GetHashCode();
                if (this.DiscountCurve != null)
                    hashCode = hashCode * 59 + this.DiscountCurve.GetHashCode();
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
