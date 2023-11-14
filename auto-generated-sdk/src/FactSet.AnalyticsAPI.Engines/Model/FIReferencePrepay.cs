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
    /// FIReferencePrepay
    /// </summary>
    [DataContract(Name = "FIReferencePrepay")]
    public partial class FIReferencePrepay : IEquatable<FIReferencePrepay>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FIReferencePrepay" /> class.
        /// </summary>
        /// <param name="prepayName">Reference Prepay Name.</param>
        public FIReferencePrepay(string prepayName = default(string))
        {
            this.PrepayName = prepayName;
        }

        /// <summary>
        /// Reference Prepay Name
        /// </summary>
        /// <value>Reference Prepay Name</value>
        [DataMember(Name = "prepayName", EmitDefaultValue = false)]
        public string PrepayName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FIReferencePrepay {\n");
            sb.Append("  PrepayName: ").Append(PrepayName).Append("\n");
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
            return this.Equals(input as FIReferencePrepay);
        }

        /// <summary>
        /// Returns true if FIReferencePrepay instances are equal
        /// </summary>
        /// <param name="input">Instance of FIReferencePrepay to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FIReferencePrepay input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PrepayName == input.PrepayName ||
                    (this.PrepayName != null &&
                    this.PrepayName.Equals(input.PrepayName))
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
                if (this.PrepayName != null)
                    hashCode = hashCode * 59 + this.PrepayName.GetHashCode();
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
