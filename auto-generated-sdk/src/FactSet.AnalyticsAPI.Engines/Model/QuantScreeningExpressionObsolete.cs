/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo,others],v1:[fiab]
 * Contact: testapi@factset.com
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
    /// QuantScreeningExpressionObsolete
    /// </summary>
    [DataContract(Name = "QuantScreeningExpressionObsolete")]
    public partial class QuantScreeningExpressionObsolete : IEquatable<QuantScreeningExpressionObsolete>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantScreeningExpressionObsolete" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantScreeningExpressionObsolete() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantScreeningExpressionObsolete" /> class.
        /// </summary>
        /// <param name="expr">expr (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="dateOffset">dateOffset.</param>
        public QuantScreeningExpressionObsolete(string expr = default(string), string name = default(string), string dateOffset = default(string))
        {
            // to ensure "expr" is required (not null)
            this.Expr = expr ?? throw new ArgumentNullException("expr is a required property for QuantScreeningExpressionObsolete and cannot be null");
            // to ensure "name" is required (not null)
            this.Name = name ?? throw new ArgumentNullException("name is a required property for QuantScreeningExpressionObsolete and cannot be null");
            this.DateOffset = dateOffset;
        }

        /// <summary>
        /// Gets or Sets Expr
        /// </summary>
        [DataMember(Name = "expr", IsRequired = true, EmitDefaultValue = false)]
        public string Expr { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets DateOffset
        /// </summary>
        [DataMember(Name = "dateOffset", EmitDefaultValue = false)]
        public string DateOffset { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantScreeningExpressionObsolete {\n");
            sb.Append("  Expr: ").Append(Expr).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DateOffset: ").Append(DateOffset).Append("\n");
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
            return this.Equals(input as QuantScreeningExpressionObsolete);
        }

        /// <summary>
        /// Returns true if QuantScreeningExpressionObsolete instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantScreeningExpressionObsolete to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantScreeningExpressionObsolete input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Expr == input.Expr ||
                    (this.Expr != null &&
                    this.Expr.Equals(input.Expr))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.DateOffset == input.DateOffset ||
                    (this.DateOffset != null &&
                    this.DateOffset.Equals(input.DateOffset))
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
                if (this.Expr != null)
                    hashCode = hashCode * 59 + this.Expr.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.DateOffset != null)
                    hashCode = hashCode * 59 + this.DateOffset.GetHashCode();
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
