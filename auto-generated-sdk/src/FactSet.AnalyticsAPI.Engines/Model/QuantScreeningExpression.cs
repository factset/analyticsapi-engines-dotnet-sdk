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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// QuantScreeningExpression
    /// </summary>
    [DataContract(Name = "QuantScreeningExpression")]
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    public partial class QuantScreeningExpression : QuantFormula, IEquatable<QuantScreeningExpression>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantScreeningExpression" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected QuantScreeningExpression() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantScreeningExpression" /> class.
        /// </summary>
        /// <param name="expr">expr (required).</param>
        /// <param name="name">name (required).</param>
        /// <param name="type">type (required) (default to &quot;QuantScreeningExpression&quot;).</param>
        /// <param name="source">source (required).</param>
        public QuantScreeningExpression(string expr = default(string), string name = default(string), string type = "QuantScreeningExpression", SourceEnum source = default(SourceEnum)) : base(type, source)
        {
            // to ensure "expr" is required (not null)
            this.Expr = expr ?? throw new ArgumentNullException("expr is a required property for QuantScreeningExpression and cannot be null");
            // to ensure "name" is required (not null)
            this.Name = name ?? throw new ArgumentNullException("name is a required property for QuantScreeningExpression and cannot be null");
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
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QuantScreeningExpression {\n");
            sb.Append("  ").Append(base.ToString().Replace("\n", "\n  ")).Append("\n");
            sb.Append("  Expr: ").Append(Expr).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
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
            return this.Equals(input as QuantScreeningExpression);
        }

        /// <summary>
        /// Returns true if QuantScreeningExpression instances are equal
        /// </summary>
        /// <param name="input">Instance of QuantScreeningExpression to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QuantScreeningExpression input)
        {
            if (input == null)
                return false;

            return base.Equals(input) && 
                (
                    this.Expr == input.Expr ||
                    (this.Expr != null &&
                    this.Expr.Equals(input.Expr))
                ) && base.Equals(input) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                int hashCode = base.GetHashCode();
                if (this.Expr != null)
                    hashCode = hashCode * 59 + this.Expr.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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
            return this.BaseValidate(validationContext);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        protected IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> BaseValidate(ValidationContext validationContext)
        {
            foreach(var x in BaseValidate(validationContext)) yield return x;
            yield break;
        }
    }

}
