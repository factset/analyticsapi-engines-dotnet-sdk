/*
 * Engines API
 *
 * Allow clients to fetch Engines Analytics through APIs.
 *
 * The version of the OpenAPI document: 3
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
    /// CalculationMeta
    /// </summary>
    [DataContract(Name = "CalculationMeta")]
    public partial class CalculationMeta : IEquatable<CalculationMeta>, IValidatableObject
    {
        /// <summary>
        /// Defines Contentorganization
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ContentorganizationEnum
        {
            /// <summary>
            /// Enum None for value: None
            /// </summary>
            [EnumMember(Value = "None")]
            None = 1,

            /// <summary>
            /// Enum Row for value: Row
            /// </summary>
            [EnumMember(Value = "Row")]
            Row = 2,

            /// <summary>
            /// Enum Column for value: Column
            /// </summary>
            [EnumMember(Value = "Column")]
            Column = 3,

            /// <summary>
            /// Enum SimplifiedRow for value: SimplifiedRow
            /// </summary>
            [EnumMember(Value = "SimplifiedRow")]
            SimplifiedRow = 4

        }

        /// <summary>
        /// Gets or Sets Contentorganization
        /// </summary>
        [DataMember(Name = "contentorganization", EmitDefaultValue = false)]
        public ContentorganizationEnum? Contentorganization { get; set; }
        /// <summary>
        /// Defines StachContentOrganization
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StachContentOrganizationEnum
        {
            /// <summary>
            /// Enum None for value: None
            /// </summary>
            [EnumMember(Value = "None")]
            None = 1,

            /// <summary>
            /// Enum Row for value: Row
            /// </summary>
            [EnumMember(Value = "Row")]
            Row = 2,

            /// <summary>
            /// Enum Column for value: Column
            /// </summary>
            [EnumMember(Value = "Column")]
            Column = 3,

            /// <summary>
            /// Enum SimplifiedRow for value: SimplifiedRow
            /// </summary>
            [EnumMember(Value = "SimplifiedRow")]
            SimplifiedRow = 4

        }

        /// <summary>
        /// Gets or Sets StachContentOrganization
        /// </summary>
        [DataMember(Name = "stachContentOrganization", EmitDefaultValue = false)]
        public StachContentOrganizationEnum? StachContentOrganization { get; set; }
        /// <summary>
        /// Defines Contenttype
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ContenttypeEnum
        {
            /// <summary>
            /// Enum Json for value: Json
            /// </summary>
            [EnumMember(Value = "Json")]
            Json = 1,

            /// <summary>
            /// Enum Binary for value: Binary
            /// </summary>
            [EnumMember(Value = "Binary")]
            Binary = 2

        }

        /// <summary>
        /// Gets or Sets Contenttype
        /// </summary>
        [DataMember(Name = "contenttype", EmitDefaultValue = false)]
        public ContenttypeEnum? Contenttype { get; set; }
        /// <summary>
        /// Defines Format
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FormatEnum
        {
            /// <summary>
            /// Enum JsonStach for value: JsonStach
            /// </summary>
            [EnumMember(Value = "JsonStach")]
            JsonStach = 1,

            /// <summary>
            /// Enum Table for value: Table
            /// </summary>
            [EnumMember(Value = "Table")]
            Table = 2,

            /// <summary>
            /// Enum Tableau for value: Tableau
            /// </summary>
            [EnumMember(Value = "Tableau")]
            Tableau = 3,

            /// <summary>
            /// Enum BinaryStach for value: BinaryStach
            /// </summary>
            [EnumMember(Value = "BinaryStach")]
            BinaryStach = 4,

            /// <summary>
            /// Enum Bison for value: Bison
            /// </summary>
            [EnumMember(Value = "Bison")]
            Bison = 5,

            /// <summary>
            /// Enum Binary for value: Binary
            /// </summary>
            [EnumMember(Value = "Binary")]
            Binary = 6,

            /// <summary>
            /// Enum Pdf for value: Pdf
            /// </summary>
            [EnumMember(Value = "Pdf")]
            Pdf = 7,

            /// <summary>
            /// Enum Pptx for value: Pptx
            /// </summary>
            [EnumMember(Value = "Pptx")]
            Pptx = 8,

            /// <summary>
            /// Enum Feather for value: Feather
            /// </summary>
            [EnumMember(Value = "Feather")]
            Feather = 9

        }

        /// <summary>
        /// Gets or Sets Format
        /// </summary>
        [DataMember(Name = "format", EmitDefaultValue = false)]
        public FormatEnum? Format { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculationMeta" /> class.
        /// </summary>
        /// <param name="contentorganization">contentorganization (default to ContentorganizationEnum.SimplifiedRow).</param>
        /// <param name="stachContentOrganization">stachContentOrganization (default to StachContentOrganizationEnum.SimplifiedRow).</param>
        /// <param name="contenttype">contenttype (default to ContenttypeEnum.Json).</param>
        /// <param name="format">format (default to FormatEnum.JsonStach).</param>
        public CalculationMeta(ContentorganizationEnum? contentorganization = ContentorganizationEnum.SimplifiedRow, StachContentOrganizationEnum? stachContentOrganization = StachContentOrganizationEnum.SimplifiedRow, ContenttypeEnum? contenttype = ContenttypeEnum.Json, FormatEnum? format = FormatEnum.JsonStach)
        {
            this.Contentorganization = contentorganization;
            this.StachContentOrganization = stachContentOrganization;
            this.Contenttype = contenttype;
            this.Format = format;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalculationMeta {\n");
            sb.Append("  Contentorganization: ").Append(Contentorganization).Append("\n");
            sb.Append("  StachContentOrganization: ").Append(StachContentOrganization).Append("\n");
            sb.Append("  Contenttype: ").Append(Contenttype).Append("\n");
            sb.Append("  Format: ").Append(Format).Append("\n");
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
            return this.Equals(input as CalculationMeta);
        }

        /// <summary>
        /// Returns true if CalculationMeta instances are equal
        /// </summary>
        /// <param name="input">Instance of CalculationMeta to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalculationMeta input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Contentorganization == input.Contentorganization ||
                    this.Contentorganization.Equals(input.Contentorganization)
                ) && 
                (
                    this.StachContentOrganization == input.StachContentOrganization ||
                    this.StachContentOrganization.Equals(input.StachContentOrganization)
                ) && 
                (
                    this.Contenttype == input.Contenttype ||
                    this.Contenttype.Equals(input.Contenttype)
                ) && 
                (
                    this.Format == input.Format ||
                    this.Format.Equals(input.Format)
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
                hashCode = hashCode * 59 + this.Contentorganization.GetHashCode();
                hashCode = hashCode * 59 + this.StachContentOrganization.GetHashCode();
                hashCode = hashCode * 59 + this.Contenttype.GetHashCode();
                hashCode = hashCode * 59 + this.Format.GetHashCode();
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
