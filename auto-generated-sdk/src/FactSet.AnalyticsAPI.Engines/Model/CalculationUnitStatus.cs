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
    /// CalculationUnitStatus
    /// </summary>
    [DataContract(Name = "CalculationUnitStatus")]
    public partial class CalculationUnitStatus : IEquatable<CalculationUnitStatus>, IValidatableObject
    {
        /// <summary>
        /// The status of calculation unit.
        /// </summary>
        /// <value>The status of calculation unit.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Queued for value: Queued
            /// </summary>
            [EnumMember(Value = "Queued")]
            Queued = 1,

            /// <summary>
            /// Enum Executing for value: Executing
            /// </summary>
            [EnumMember(Value = "Executing")]
            Executing = 2,

            /// <summary>
            /// Enum Success for value: Success
            /// </summary>
            [EnumMember(Value = "Success")]
            Success = 3,

            /// <summary>
            /// Enum Failed for value: Failed
            /// </summary>
            [EnumMember(Value = "Failed")]
            Failed = 4,

            /// <summary>
            /// Enum Cancelled for value: Cancelled
            /// </summary>
            [EnumMember(Value = "Cancelled")]
            Cancelled = 5

        }

        /// <summary>
        /// The status of calculation unit.
        /// </summary>
        /// <value>The status of calculation unit.</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationUnitStatus" /> class.
        /// </summary>
        /// <param name="status">The status of calculation unit..</param>
        /// <param name="errors">The error in a calculation unit..</param>
        /// <param name="result">The result URL of the calculation..</param>
        /// <param name="progress">The progress of the calculation unit..</param>
        /// <param name="points">The points for the calculation unit..</param>
        public CalculationUnitStatus(StatusEnum? status = default(StatusEnum?), List<Error> errors = default(List<Error>), string result = default(string), string progress = default(string), int points = default(int))
        {
            this.Status = status;
            this.Errors = errors;
            this.Result = result;
            this.Progress = progress;
            this.Points = points;
        }

        /// <summary>
        /// The error in a calculation unit.
        /// </summary>
        /// <value>The error in a calculation unit.</value>
        [DataMember(Name = "errors", EmitDefaultValue = false)]
        public List<Error> Errors { get; set; }

        /// <summary>
        /// The result URL of the calculation.
        /// </summary>
        /// <value>The result URL of the calculation.</value>
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public string Result { get; set; }

        /// <summary>
        /// The progress of the calculation unit.
        /// </summary>
        /// <value>The progress of the calculation unit.</value>
        [DataMember(Name = "progress", EmitDefaultValue = false)]
        public string Progress { get; set; }

        /// <summary>
        /// The points for the calculation unit.
        /// </summary>
        /// <value>The points for the calculation unit.</value>
        [DataMember(Name = "points", EmitDefaultValue = false)]
        public int Points { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalculationUnitStatus {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("  Result: ").Append(Result).Append("\n");
            sb.Append("  Progress: ").Append(Progress).Append("\n");
            sb.Append("  Points: ").Append(Points).Append("\n");
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
            return this.Equals(input as CalculationUnitStatus);
        }

        /// <summary>
        /// Returns true if CalculationUnitStatus instances are equal
        /// </summary>
        /// <param name="input">Instance of CalculationUnitStatus to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalculationUnitStatus input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Errors == input.Errors ||
                    this.Errors != null &&
                    input.Errors != null &&
                    this.Errors.SequenceEqual(input.Errors)
                ) && 
                (
                    this.Result == input.Result ||
                    (this.Result != null &&
                    this.Result.Equals(input.Result))
                ) && 
                (
                    this.Progress == input.Progress ||
                    (this.Progress != null &&
                    this.Progress.Equals(input.Progress))
                ) && 
                (
                    this.Points == input.Points ||
                    this.Points.Equals(input.Points)
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
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
                if (this.Result != null)
                    hashCode = hashCode * 59 + this.Result.GetHashCode();
                if (this.Progress != null)
                    hashCode = hashCode * 59 + this.Progress.GetHashCode();
                hashCode = hashCode * 59 + this.Points.GetHashCode();
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
