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
        /// <param name="universe">universe.</param>
        /// <param name="dates">dates.</param>
        /// <param name="formulas">formulas.</param>
        public QuantCalculationParameters(object universe = default(object), object dates = default(object), List<object> formulas = default(List<object>))
        {
            this.Universe = universe;
            this.Dates = dates;
            this.Formulas = formulas;
        }

        /// <summary>
        /// Gets or Sets Universe
        /// </summary>
        [DataMember(Name = "universe", EmitDefaultValue = false)]
        public object Universe { get; set; }

        /// <summary>
        /// Gets or Sets Dates
        /// </summary>
        [DataMember(Name = "dates", EmitDefaultValue = false)]
        public object Dates { get; set; }

        /// <summary>
        /// Gets or Sets Formulas
        /// </summary>
        [DataMember(Name = "formulas", EmitDefaultValue = false)]
        public List<object> Formulas { get; set; }

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
