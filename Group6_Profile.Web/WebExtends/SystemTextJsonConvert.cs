using System.Text.Json.Serialization;
using System.Text.Json;

namespace Group6_Profile.web.WebExtends
{
    /// <summary>
    /// SystemTextJson  
    /// </summary>
    public class SystemTextJsonConvert
    {
        /// <summary>
        ///  
        /// </summary>
        public class DateTimeConverter : JsonConverter<DateTime>
        {
            /// <summary>
            ///  
            /// </summary>
            /// <param name="reader"></param>
            /// <param name="typeToConvert"></param>
            /// <param name="options"></param>
            /// <returns></returns>
            public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return DateTime.Parse(reader.GetString());
            }
            /// <summary>
            ///  
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="options"></param>
            public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
        /// <summary>
        /// NULL Date
        /// </summary>
        public class DateTimeNullableConverter : JsonConverter<DateTime?>
        {
            /// <summary>
            ///  
            /// </summary>
            /// <param name="reader"></param>
            /// <param name="typeToConvert"></param>
            /// <param name="options"></param>
            /// <returns></returns>
            public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return string.IsNullOrEmpty(reader.GetString()) ? default(DateTime?) : DateTime.Parse(reader.GetString());
            }
            /// <summary>
            ///  
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="options"></param>
            public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value?.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }


        /// <summary>
        /// long类型转成字符串
        /// </summary>
        public class LongConverter : JsonConverter<long>
        {
            /// <summary>
            /// 读json  将前端传过来的字符串转成long类型
            /// </summary>
            /// <param name="reader"></param>
            /// <param name="typeToConvert"></param>
            /// <param name="options"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                    return long.Parse(reader.GetString());
                else
                    return reader.GetInt64();
            }
            /// <summary>
            /// 写json 转成long 类型转给前端
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="options"></param>
            public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value == 0 ? null : value.ToString());
            }
        }
        /// <summary>
        /// 可空long类型转换
        /// </summary>
        public class LongNullableConverter : JsonConverter<long?>
        {
            /// <summary>
            /// 读取参数   将前端传过来的字符串转成long类型
            /// </summary>
            /// <param name="reader"></param>
            /// <param name="typeToConvert"></param>
            /// <param name="options"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                    return string.IsNullOrEmpty(reader.GetString()) ? default(long?) : long.Parse(reader.GetString());
                else
                    return reader.GetInt64();
            }
            /// <summary>
            /// 写json  转成long 类型转给前端
            /// </summary>
            /// <param name="writer"></param>
            /// <param name="value"></param>
            /// <param name="options"></param>
            /// <exception cref="NotImplementedException"></exception>
            public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value?.ToString());
            }
        }
    }
}
