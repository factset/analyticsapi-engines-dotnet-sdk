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
    /// QuantCalculationParameters
    /// </summary>
    [DataContract(Name = "QuantCalculationParameters")]
    public partial class QuantCalculationParameters : IEquatable<QuantCalculationParameters>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantCalculationParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantCalculationParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantCalculationParameters" /> class.
        /// </summary>
        /// <param name="universe">universe (required).</param>
        /// <param name="dates">dates (required).</param>
        /// <param name="formulas">formulas.</param>
        /// <param name="screeningExpressionUniverse">screeningExpressionUniverse.</param>
        /// <param name="universalScreenUniverse">universalScreenUniverse.</param>
        /// <param name="identifierUniverse">identifierUniverse.</param>
        /// <param name="fdsDate">fdsDate.</param>
        /// <param name="dateList">dateList.</param>
        /// <param name="screeningExpression">screeningExpression.</param>
        /// <param name="fqlExpression">fqlExpression.</param>
        /// <param name="universalScreenParameter">universalScreenParameter.</param>
        /// <param name="allUniversalScreenParameters">allUniversalScreenParameters.</param>
        public QuantCalculationParameters(OneOfQuantUniversalScreenUniverseQuantScreeningExpressionUniverseQuantIdentifierUniverse universe = default(OneOfQuantUniversalScreenUniverseQuantScreeningExpressionUniverseQuantIdentifierUniverse), OneOfQuantFdsDateQuantDateList dates = default(OneOfQuantFdsDateQuantDateList), List<OneOfQuantScreeningExpressionQuantFqlExpressionQuantUniversalScreenParameterQuantAllUniversalScreenParameters> formulas = default(List<OneOfQuantScreeningExpressionQuantFqlExpressionQuantUniversalScreenParameterQuantAllUniversalScreenParameters>), QuantScreeningExpressionUniverse1 screeningExpressionUniverse = default(QuantScreeningExpressionUniverse1), QuantUniversalScreenUniverse1 universalScreenUniverse = default(QuantUniversalScreenUniverse1), QuantIdentifierUniverse1 identifierUniverse = default(QuantIdentifierUniverse1), QuantFdsDate1 fdsDate = default(QuantFdsDate1), QuantDateList1 dateList = default(QuantDateList1), List<QuantScreeningExpression1> screeningExpression = default(List<QuantScreeningExpression1>), List<QuantFqlExpression1> fqlExpression = default(List<QuantFqlExpression1>), List<QuantUniversalScreenParameter1> universalScreenParameter = default(List<QuantUniversalScreenParameter1>), List<Object> allUniversalScreenParameters = default(List<Object>))
        {
            // to ensure "universe" is required (not null)
            this.Universe = universe ?? throw new ArgumentNullException("universe is a required property for QuantCalculationParameters and cannot be null");
            // to ensure "dates" is required (not null)
            this.Dates = dates ?? throw new ArgumentNullException("dates is a required property for QuantCalculationParameters and cannot be null");
            this.Formulas = formulas;
            this.ScreeningExpressionUniverse = screeningExpressionUniverse;
            this.UniversalScreenUniverse = universalScreenUniverse;
            this.IdentifierUniverse = identifierUniverse;
            this.FdsDate = fdsDate;
            this.DateList = dateList;
            this.ScreeningExpression = screeningExpression;
            this.FqlExpression = fqlExpression;
            this.UniversalScreenParameter = universalScreenParameter;
            this.AllUniversalScreenParameters = allUniversalScreenParameters;
        }

        /// <summary>
        /// Gets or Sets Universe
        /// </summary>
        [DataMember(Name = "universe", IsRequired = true, EmitDefaultValue = false)]
        public OneOfQuantUniversalScreenUniverseQuantScreeningExpressionUniverseQuantIdentifierUniverse Universe { get; set; }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name = "dates", IsRequired = true, EmitDefaultValue = false)]
        public OneOfQuantFdsDateQuantDateList Dates { get; set; }

        /// <summary>
        /// Gets or Sets Formulas
        /// </summary>
        [DataMember(Name = "formulas", EmitDefaultValue = false)]
        public List<OneOfQuantScreeningExpressionQuantFqlExpressionQuantUniversalScreenParameterQuantAllUniversalScreenParameters> Formulas { get; set; }

        /// <summary>
        /// Gets or Sets ScreeningExpressionUniverse
        /// </summary>
        [DataMember(Name = "screeningExpressionUniverse", EmitDefaultValue = false)]
        public QuantScreeningExpressionUniverse1 ScreeningExpressionUniverse { get; set; }

        /// <summary>
        /// Gets or Sets UniversalScreenUniverse
        /// </summary>
        [DataMember(Name = "universalScreenUniverse", EmitDefaultValue = false)]
        public QuantUniversalScreenUniverse1 UniversalScreenUniverse { get; set; }

        /// <summary>
        /// Gets or Sets IdentifierUniverse
        /// </summary>
        [DataMember(Name = "identifierUniverse", EmitDefaultValue = false)]
        public QuantIdentifierUniverse1 IdentifierUniverse { get; set; }

        /// <summary>
        /// Gets or Sets FdsDate
        /// </summary>
        [DataMember(Name = "fdsDate", EmitDefaultValue = false)]
        public QuantFdsDate1 FdsDate { get; set; }

        /// <summary>
        /// Gets or Sets DateList
        /// </summary>
        [DataMember(Name = "dateList", EmitDefaultValue = false)]
        public QuantDateList1 DateList { get; set; }

        /// <summary>
        /// Gets or Sets ScreeningExpression
        /// </summary>
        [DataMember(Name = "screeningExpression", EmitDefaultValue = false)]
        public List<QuantScreeningExpression1> ScreeningExpression { get; set; }

        /// <summary>
        /// Gets or Sets FqlExpression
        /// </summary>
        [DataMember(Name = "fqlExpression", EmitDefaultValue = false)]
        public List<QuantFqlExpression1> FqlExpression { get; set; }

        /// <summary>
        /// Gets or Sets UniversalScreenParameter
        /// </summary>
        [DataMember(Name = "universalScreenParameter", EmitDefaultValue = false)]
        public List<QuantUniversalScreenParameter1> UniversalScreenParameter { get; set; }

        /// <summary>
        /// Gets or Sets AllUniversalScreenParameters
        /// </summary>
        [DataMember(Name = "allUniversalScreenParameters", EmitDefaultValue = false)]
        public List<Object> AllUniversalScreenParameters { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantCalculationParameters {\n");
            sb.Append("  Universe: ").Append(Universe).Append("\n");
            sb.Append("  Dates: ").Append(Dates).Append("\n");
            sb.Append("  Formulas: ").Append(Formulas).Append("\n");
            sb.Append("  ScreeningExpressionUniverse: ").Append(ScreeningExpressionUniverse).Append("\n");
            sb.Append("  UniversalScreenUniverse: ").Append(UniversalScreenUniverse).Append("\n");
            sb.Append("  IdentifierUniverse: ").Append(IdentifierUniverse).Append("\n");
            sb.Append("  FdsDate: ").Append(FdsDate).Append("\n");
            sb.Append("  DateList: ").Append(DateList).Append("\n");
            sb.Append("  ScreeningExpression: ").Append(ScreeningExpression).Append("\n");
            sb.Append("  FqlExpression: ").Append(FqlExpression).Append("\n");
            sb.Append("  UniversalScreenParameter: ").Append(UniversalScreenParameter).Append("\n");
            sb.Append("  AllUniversalScreenParameters: ").Append(AllUniversalScreenParameters).Append("\n");
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
            return this.Equals(input as QuantCalculationParameters);
        }

        /// <summary>
        /// Returns true if QuantCalculationParameters instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantCalculationParameters to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantCalculationParameters input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Universe == input.Universe ||
                    (this.Universe != null &&
                    this.Universe.Equals(input.Universe))
                ) && 
                (
                    this.Dates == input.Dates ||
                    (this.Dates != null &&
                    this.Dates.Equals(input.Dates))
                ) && 
                (
                    this.Formulas == input.Formulas ||
                    this.Formulas != null &&
                    input.Formulas != null &&
                    this.Formulas.SequenceEqual(input.Formulas)
                ) && 
                (
                    this.ScreeningExpressionUniverse == input.ScreeningExpressionUniverse ||
                    (this.ScreeningExpressionUniverse != null &&
                    this.ScreeningExpressionUniverse.Equals(input.ScreeningExpressionUniverse))
                ) && 
                (
                    this.UniversalScreenUniverse == input.UniversalScreenUniverse ||
                    (this.UniversalScreenUniverse != null &&
                    this.UniversalScreenUniverse.Equals(input.UniversalScreenUniverse))
                ) && 
                (
                    this.IdentifierUniverse == input.IdentifierUniverse ||
                    (this.IdentifierUniverse != null &&
                    this.IdentifierUniverse.Equals(input.IdentifierUniverse))
                ) && 
                (
                    this.FdsDate == input.FdsDate ||
                    (this.FdsDate != null &&
                    this.FdsDate.Equals(input.FdsDate))
                ) && 
                (
                    this.DateList == input.DateList ||
                    (this.DateList != null &&
                    this.DateList.Equals(input.DateList))
                ) && 
                (
                    this.ScreeningExpression == input.ScreeningExpression ||
                    this.ScreeningExpression != null &&
                    input.ScreeningExpression != null &&
                    this.ScreeningExpression.SequenceEqual(input.ScreeningExpression)
                ) && 
                (
                    this.FqlExpression == input.FqlExpression ||
                    this.FqlExpression != null &&
                    input.FqlExpression != null &&
                    this.FqlExpression.SequenceEqual(input.FqlExpression)
                ) && 
                (
                    this.UniversalScreenParameter == input.UniversalScreenParameter ||
                    this.UniversalScreenParameter != null &&
                    input.UniversalScreenParameter != null &&
                    this.UniversalScreenParameter.SequenceEqual(input.UniversalScreenParameter)
                ) && 
                (
                    this.AllUniversalScreenParameters == input.AllUniversalScreenParameters ||
                    this.AllUniversalScreenParameters != null &&
                    input.AllUniversalScreenParameters != null &&
                    this.AllUniversalScreenParameters.SequenceEqual(input.AllUniversalScreenParameters)
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
                if (this.Universe != null)
                    hashCode = hashCode * 59 + this.Universe.GetHashCode();
                if (this.Dates != null)
                    hashCode = hashCode * 59 + this.Dates.GetHashCode();
                if (this.Formulas != null)
                    hashCode = hashCode * 59 + this.Formulas.GetHashCode();
                if (this.ScreeningExpressionUniverse != null)
                    hashCode = hashCode * 59 + this.ScreeningExpressionUniverse.GetHashCode();
                if (this.UniversalScreenUniverse != null)
                    hashCode = hashCode * 59 + this.UniversalScreenUniverse.GetHashCode();
                if (this.IdentifierUniverse != null)
                    hashCode = hashCode * 59 + this.IdentifierUniverse.GetHashCode();
                if (this.FdsDate != null)
                    hashCode = hashCode * 59 + this.FdsDate.GetHashCode();
                if (this.DateList != null)
                    hashCode = hashCode * 59 + this.DateList.GetHashCode();
                if (this.ScreeningExpression != null)
                    hashCode = hashCode * 59 + this.ScreeningExpression.GetHashCode();
                if (this.FqlExpression != null)
                    hashCode = hashCode * 59 + this.FqlExpression.GetHashCode();
                if (this.UniversalScreenParameter != null)
                    hashCode = hashCode * 59 + this.UniversalScreenParameter.GetHashCode();
                if (this.AllUniversalScreenParameters != null)
                    hashCode = hashCode * 59 + this.AllUniversalScreenParameters.GetHashCode();
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
