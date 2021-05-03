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
    /// ConfigurationAccount
    /// </summary>
    [DataContract(Name = "ConfigurationAccount")]
    public partial class ConfigurationAccount : IEquatable<ConfigurationAccount>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationAccount" /> class.
        /// </summary>
        /// <param name="benchmarkCode">Benchmark code..</param>
        /// <param name="benchmarkName">Benchmark name..</param>
        /// <param name="maxEndDate">Maximum end date..</param>
        /// <param name="minStartDate">Minimum start date..</param>
        /// <param name="lockingDate">Locking date..</param>
        /// <param name="name">Account name..</param>
        public ConfigurationAccount(string benchmarkCode = default(string), string benchmarkName = default(string), string maxEndDate = default(string), string minStartDate = default(string), string lockingDate = default(string), string name = default(string))
        {
            this.BenchmarkCode = benchmarkCode;
            this.BenchmarkName = benchmarkName;
            this.MaxEndDate = maxEndDate;
            this.MinStartDate = minStartDate;
            this.LockingDate = lockingDate;
            this.Name = name;
        }

        /// <summary>
        /// Benchmark code.
        /// </summary>
        /// <value>Benchmark code.</value>
        [DataMember(Name = "benchmarkCode", EmitDefaultValue = false)]
        public string BenchmarkCode { get; set; }

        /// <summary>
        /// Benchmark name.
        /// </summary>
        /// <value>Benchmark name.</value>
        [DataMember(Name = "benchmarkName", EmitDefaultValue = false)]
        public string BenchmarkName { get; set; }

        /// <summary>
        /// Maximum end date.
        /// </summary>
        /// <value>Maximum end date.</value>
        [DataMember(Name = "maxEndDate", EmitDefaultValue = false)]
        public string MaxEndDate { get; set; }

        /// <summary>
        /// Minimum start date.
        /// </summary>
        /// <value>Minimum start date.</value>
        [DataMember(Name = "minStartDate", EmitDefaultValue = false)]
        public string MinStartDate { get; set; }

        /// <summary>
        /// Locking date.
        /// </summary>
        /// <value>Locking date.</value>
        [DataMember(Name = "lockingDate", EmitDefaultValue = false)]
        public string LockingDate { get; set; }

        /// <summary>
        /// Account name.
        /// </summary>
        /// <value>Account name.</value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ConfigurationAccount {\n");
            sb.Append("  BenchmarkCode: ").Append(BenchmarkCode).Append("\n");
            sb.Append("  BenchmarkName: ").Append(BenchmarkName).Append("\n");
            sb.Append("  MaxEndDate: ").Append(MaxEndDate).Append("\n");
            sb.Append("  MinStartDate: ").Append(MinStartDate).Append("\n");
            sb.Append("  LockingDate: ").Append(LockingDate).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as ConfigurationAccount);
        }

        /// <summary>
        /// Returns true if ConfigurationAccount instances are equal
        /// </summary>
        /// <param name="input">Instance of ConfigurationAccount to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ConfigurationAccount input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BenchmarkCode == input.BenchmarkCode ||
                    (this.BenchmarkCode != null &&
                    this.BenchmarkCode.Equals(input.BenchmarkCode))
                ) && 
                (
                    this.BenchmarkName == input.BenchmarkName ||
                    (this.BenchmarkName != null &&
                    this.BenchmarkName.Equals(input.BenchmarkName))
                ) && 
                (
                    this.MaxEndDate == input.MaxEndDate ||
                    (this.MaxEndDate != null &&
                    this.MaxEndDate.Equals(input.MaxEndDate))
                ) && 
                (
                    this.MinStartDate == input.MinStartDate ||
                    (this.MinStartDate != null &&
                    this.MinStartDate.Equals(input.MinStartDate))
                ) && 
                (
                    this.LockingDate == input.LockingDate ||
                    (this.LockingDate != null &&
                    this.LockingDate.Equals(input.LockingDate))
                ) && 
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
                int hashCode = 41;
                if (this.BenchmarkCode != null)
                    hashCode = hashCode * 59 + this.BenchmarkCode.GetHashCode();
                if (this.BenchmarkName != null)
                    hashCode = hashCode * 59 + this.BenchmarkName.GetHashCode();
                if (this.MaxEndDate != null)
                    hashCode = hashCode * 59 + this.MaxEndDate.GetHashCode();
                if (this.MinStartDate != null)
                    hashCode = hashCode * 59 + this.MinStartDate.GetHashCode();
                if (this.LockingDate != null)
                    hashCode = hashCode * 59 + this.LockingDate.GetHashCode();
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
            yield break;
        }
    }

}
