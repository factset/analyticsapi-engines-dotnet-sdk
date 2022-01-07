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
using System.Reflection;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// OneOfQuantDates
    /// </summary>
    [JsonConverter(typeof(OneOfQuantDatesJsonConverter))]
    [DataContract(Name = "OneOfQuantDates")]
    public partial class OneOfQuantDates : AbstractOpenAPISchema, IEquatable<OneOfQuantDates>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantDates" /> class
        /// with the <see cref="QuantDateList" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantDateList.</param>
        public OneOfQuantDates(QuantDateList actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantDates" /> class
        /// with the <see cref="QuantFdsDate" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantFdsDate.</param>
        public OneOfQuantDates(QuantFdsDate actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(QuantDateList))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(QuantFdsDate))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: QuantDateList, QuantFdsDate");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `QuantDateList`. If the actual instanct is not `QuantDateList`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantDateList</returns>
        public QuantDateList GetQuantDateList()
        {
            return (QuantDateList)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `QuantFdsDate`. If the actual instanct is not `QuantFdsDate`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantFdsDate</returns>
        public QuantFdsDate GetQuantFdsDate()
        {
            return (QuantFdsDate)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneOfQuantDates {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this.ActualInstance, OneOfQuantDates.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of OneOfQuantDates
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of OneOfQuantDates</returns>
        public static OneOfQuantDates FromJson(string jsonString)
        {
            OneOfQuantDates newOneOfQuantDates = null;

            if (jsonString == null)
            {
                return newOneOfQuantDates;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantDateList).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantDates = new OneOfQuantDates(JsonConvert.DeserializeObject<QuantDateList>(jsonString, OneOfQuantDates.SerializerSettings));
                }
                else
                {
                    newOneOfQuantDates = new OneOfQuantDates(JsonConvert.DeserializeObject<QuantDateList>(jsonString, OneOfQuantDates.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantDateList");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantDateList: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantFdsDate).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantDates = new OneOfQuantDates(JsonConvert.DeserializeObject<QuantFdsDate>(jsonString, OneOfQuantDates.SerializerSettings));
                }
                else
                {
                    newOneOfQuantDates = new OneOfQuantDates(JsonConvert.DeserializeObject<QuantFdsDate>(jsonString, OneOfQuantDates.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantFdsDate");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantFdsDate: {1}", jsonString, exception.ToString()));
            }

            if (match == 0)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` cannot be deserialized into any schema defined.");
            }
            else if (match > 1)
            {
                throw new InvalidDataException("The JSON string `" + jsonString + "` incorrectly matches more than one schema (should be exactly one match): " + matchedTypes);
            }

            // deserialization is considered successful at this point if no exception has been thrown.
            return newOneOfQuantDates;
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OneOfQuantDates);
        }

        /// <summary>
        /// Returns true if OneOfQuantDates instances are equal
        /// </summary>
        /// <param name="input">Instance of OneOfQuantDates to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OneOfQuantDates input)
        {
            if (input == null)
                return false;

            return this.ActualInstance.Equals(input.ActualInstance);
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
                if (this.ActualInstance != null)
                    hashCode = hashCode * 59 + this.ActualInstance.GetHashCode();
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

    /// <summary>
    /// Custom JSON converter for OneOfQuantDates
    /// </summary>
    public class OneOfQuantDatesJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((String)(typeof(OneOfQuantDates).GetMethod("ToJson").Invoke(value, null)));
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="objectType">Object type</param>
        /// <param name="existingValue">Existing value</param>
        /// <param name="serializer">JSON Serializer</param>
        /// <returns>The object converted from the JSON string</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.Null)
            {
                return OneOfQuantDates.FromJson(JObject.Load(reader).ToString(Formatting.None));
            }
            return null;
        }

        /// <summary>
        /// Check if the object can be converted
        /// </summary>
        /// <param name="objectType">Object type</param>
        /// <returns>True if the object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
