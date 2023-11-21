/*
 * Engines API
 *
 * Allow clients to fetch Analytics through APIs.
 *
 * The version of the OpenAPI document: v3:[pa,spar,vault,pub,quant,fi,axp,afi,npo,bpm,fpo],v1:[fiab]
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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;
using System.Reflection;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// OneOfQuantUniverse
    /// </summary>
    [JsonConverter(typeof(OneOfQuantUniverseJsonConverter))]
    [DataContract(Name = "OneOfQuantUniverse")]
    public partial class OneOfQuantUniverse : AbstractOpenAPISchema, IEquatable<OneOfQuantUniverse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantUniverse" /> class
        /// with the <see cref="QuantIdentifierUniverse" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantIdentifierUniverse.</param>
        public OneOfQuantUniverse(QuantIdentifierUniverse actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantUniverse" /> class
        /// with the <see cref="QuantScreeningExpressionUniverse" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantScreeningExpressionUniverse.</param>
        public OneOfQuantUniverse(QuantScreeningExpressionUniverse actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantUniverse" /> class
        /// with the <see cref="QuantUniversalScreenUniverse" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantUniversalScreenUniverse.</param>
        public OneOfQuantUniverse(QuantUniversalScreenUniverse actualInstance)
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
                if (value.GetType() == typeof(QuantIdentifierUniverse))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(QuantScreeningExpressionUniverse))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(QuantUniversalScreenUniverse))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: QuantIdentifierUniverse, QuantScreeningExpressionUniverse, QuantUniversalScreenUniverse");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `QuantIdentifierUniverse`. If the actual instanct is not `QuantIdentifierUniverse`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantIdentifierUniverse</returns>
        public QuantIdentifierUniverse GetQuantIdentifierUniverse()
        {
            return (QuantIdentifierUniverse)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `QuantScreeningExpressionUniverse`. If the actual instanct is not `QuantScreeningExpressionUniverse`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantScreeningExpressionUniverse</returns>
        public QuantScreeningExpressionUniverse GetQuantScreeningExpressionUniverse()
        {
            return (QuantScreeningExpressionUniverse)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `QuantUniversalScreenUniverse`. If the actual instanct is not `QuantUniversalScreenUniverse`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantUniversalScreenUniverse</returns>
        public QuantUniversalScreenUniverse GetQuantUniversalScreenUniverse()
        {
            return (QuantUniversalScreenUniverse)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneOfQuantUniverse {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, OneOfQuantUniverse.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of OneOfQuantUniverse
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of OneOfQuantUniverse</returns>
        public static OneOfQuantUniverse FromJson(string jsonString)
        {
            OneOfQuantUniverse newOneOfQuantUniverse = null;

            if (jsonString == null)
            {
                return newOneOfQuantUniverse;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantIdentifierUniverse).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantUniverse = new OneOfQuantUniverse(JsonConvert.DeserializeObject<QuantIdentifierUniverse>(jsonString, OneOfQuantUniverse.SerializerSettings));
                }
                else
                {
                    newOneOfQuantUniverse = new OneOfQuantUniverse(JsonConvert.DeserializeObject<QuantIdentifierUniverse>(jsonString, OneOfQuantUniverse.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantIdentifierUniverse");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantIdentifierUniverse: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantScreeningExpressionUniverse).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantUniverse = new OneOfQuantUniverse(JsonConvert.DeserializeObject<QuantScreeningExpressionUniverse>(jsonString, OneOfQuantUniverse.SerializerSettings));
                }
                else
                {
                    newOneOfQuantUniverse = new OneOfQuantUniverse(JsonConvert.DeserializeObject<QuantScreeningExpressionUniverse>(jsonString, OneOfQuantUniverse.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantScreeningExpressionUniverse");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantScreeningExpressionUniverse: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantUniversalScreenUniverse).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantUniverse = new OneOfQuantUniverse(JsonConvert.DeserializeObject<QuantUniversalScreenUniverse>(jsonString, OneOfQuantUniverse.SerializerSettings));
                }
                else
                {
                    newOneOfQuantUniverse = new OneOfQuantUniverse(JsonConvert.DeserializeObject<QuantUniversalScreenUniverse>(jsonString, OneOfQuantUniverse.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantUniversalScreenUniverse");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantUniversalScreenUniverse: {1}", jsonString, exception.ToString()));
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
            return newOneOfQuantUniverse;
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OneOfQuantUniverse);
        }

        /// <summary>
        /// Returns true if OneOfQuantUniverse instances are equal
        /// </summary>
        /// <param name="input">Instance of OneOfQuantUniverse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OneOfQuantUniverse input)
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
    /// Custom JSON converter for OneOfQuantUniverse
    /// </summary>
    public class OneOfQuantUniverseJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((String)(typeof(OneOfQuantUniverse).GetMethod("ToJson").Invoke(value, null)));
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
                return OneOfQuantUniverse.FromJson(JObject.Load(reader).ToString(Formatting.None));
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
