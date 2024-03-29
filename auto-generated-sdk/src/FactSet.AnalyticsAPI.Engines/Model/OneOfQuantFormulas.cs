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
using JsonSubTypes;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FactSet.AnalyticsAPI.Engines.Client.OpenAPIDateConverter;
using System.Reflection;

namespace FactSet.AnalyticsAPI.Engines.Model
{
    /// <summary>
    /// OneOfQuantFormulas
    /// </summary>
    [JsonConverter(typeof(OneOfQuantFormulasJsonConverter))]
    [DataContract(Name = "OneOfQuantFormulas")]
    public partial class OneOfQuantFormulas : AbstractOpenAPISchema, IEquatable<OneOfQuantFormulas>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantFormulas" /> class
        /// with the <see cref="QuantAllUniversalScreenParameters" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantAllUniversalScreenParameters.</param>
        public OneOfQuantFormulas(QuantAllUniversalScreenParameters actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantFormulas" /> class
        /// with the <see cref="QuantFqlExpression" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantFqlExpression.</param>
        public OneOfQuantFormulas(QuantFqlExpression actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantFormulas" /> class
        /// with the <see cref="QuantScreeningExpression" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantScreeningExpression.</param>
        public OneOfQuantFormulas(QuantScreeningExpression actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOfQuantFormulas" /> class
        /// with the <see cref="QuantUniversalScreenParameter" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of QuantUniversalScreenParameter.</param>
        public OneOfQuantFormulas(QuantUniversalScreenParameter actualInstance)
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
                if (value.GetType() == typeof(QuantAllUniversalScreenParameters))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(QuantFqlExpression))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(QuantScreeningExpression))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(QuantUniversalScreenParameter))
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: QuantAllUniversalScreenParameters, QuantFqlExpression, QuantScreeningExpression, QuantUniversalScreenParameter");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `QuantAllUniversalScreenParameters`. If the actual instanct is not `QuantAllUniversalScreenParameters`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantAllUniversalScreenParameters</returns>
        public QuantAllUniversalScreenParameters GetQuantAllUniversalScreenParameters()
        {
            return (QuantAllUniversalScreenParameters)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `QuantFqlExpression`. If the actual instanct is not `QuantFqlExpression`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantFqlExpression</returns>
        public QuantFqlExpression GetQuantFqlExpression()
        {
            return (QuantFqlExpression)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `QuantScreeningExpression`. If the actual instanct is not `QuantScreeningExpression`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantScreeningExpression</returns>
        public QuantScreeningExpression GetQuantScreeningExpression()
        {
            return (QuantScreeningExpression)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `QuantUniversalScreenParameter`. If the actual instanct is not `QuantUniversalScreenParameter`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of QuantUniversalScreenParameter</returns>
        public QuantUniversalScreenParameter GetQuantUniversalScreenParameter()
        {
            return (QuantUniversalScreenParameter)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneOfQuantFormulas {\n");
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
            return JsonConvert.SerializeObject(this.ActualInstance, OneOfQuantFormulas.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of OneOfQuantFormulas
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of OneOfQuantFormulas</returns>
        public static OneOfQuantFormulas FromJson(string jsonString)
        {
            OneOfQuantFormulas newOneOfQuantFormulas = null;

            if (jsonString == null)
            {
                return newOneOfQuantFormulas;
            }
            int match = 0;
            List<string> matchedTypes = new List<string>();

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantAllUniversalScreenParameters).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantAllUniversalScreenParameters>(jsonString, OneOfQuantFormulas.SerializerSettings));
                }
                else
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantAllUniversalScreenParameters>(jsonString, OneOfQuantFormulas.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantAllUniversalScreenParameters");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantAllUniversalScreenParameters: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantFqlExpression).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantFqlExpression>(jsonString, OneOfQuantFormulas.SerializerSettings));
                }
                else
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantFqlExpression>(jsonString, OneOfQuantFormulas.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantFqlExpression");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantFqlExpression: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantScreeningExpression).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantScreeningExpression>(jsonString, OneOfQuantFormulas.SerializerSettings));
                }
                else
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantScreeningExpression>(jsonString, OneOfQuantFormulas.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantScreeningExpression");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantScreeningExpression: {1}", jsonString, exception.ToString()));
            }

            try
            {
                // if it does not contains "AdditionalProperties", use SerializerSettings to deserialize
                if (typeof(QuantUniversalScreenParameter).GetProperty("AdditionalProperties") == null)
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantUniversalScreenParameter>(jsonString, OneOfQuantFormulas.SerializerSettings));
                }
                else
                {
                    newOneOfQuantFormulas = new OneOfQuantFormulas(JsonConvert.DeserializeObject<QuantUniversalScreenParameter>(jsonString, OneOfQuantFormulas.AdditionalPropertiesSerializerSettings));
                }
                matchedTypes.Add("QuantUniversalScreenParameter");
                match++;
            }
            catch (Exception exception)
            {
                // deserialization failed, try the next one
                System.Diagnostics.Debug.WriteLine(String.Format("Failed to deserialize `{0}` into QuantUniversalScreenParameter: {1}", jsonString, exception.ToString()));
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
            return newOneOfQuantFormulas;
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as OneOfQuantFormulas);
        }

        /// <summary>
        /// Returns true if OneOfQuantFormulas instances are equal
        /// </summary>
        /// <param name="input">Instance of OneOfQuantFormulas to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OneOfQuantFormulas input)
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
    /// Custom JSON converter for OneOfQuantFormulas
    /// </summary>
    public class OneOfQuantFormulasJsonConverter : JsonConverter
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="serializer">JSON Serializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((String)(typeof(OneOfQuantFormulas).GetMethod("ToJson").Invoke(value, null)));
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
                return OneOfQuantFormulas.FromJson(JObject.Load(reader).ToString(Formatting.None));
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
