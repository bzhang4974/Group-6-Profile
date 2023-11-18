using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group6_Profile.DTO.MessageBody
{
    /// <summary>
    /// Response Message
    /// </summary>
    public class MessageModel<T>
    {
        /// <summary>
        /// IsSuccess
        /// </summary>
        [JsonPropertyName("success")]
        public bool IsSuccess { get; set; } = false;
        /// <summary>
        /// Message
        /// </summary>
        [JsonPropertyName("msg")]
        public string Message { get; set; } = "";
        /// <summary>
        /// Response
        /// </summary>
        [JsonPropertyName("response")]
        public T Response { get; set; }

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="msg">msg</param>
        /// <returns></returns>
        public static MessageModel<T> Success(string msg)
        {
            return Create(true, msg, default);
        }
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="msg">msg</param>
        /// <param name="response">Response Data</param>
        /// <returns></returns>
        public static MessageModel<T> Success(string msg, T response)
        {
            return Create(true, msg, response);
        }
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="success">Is Success</param>
        /// <param name="msg">Message</param>
        /// <param name="response">response data</param>
        /// <returns></returns>
        public static MessageModel<T> Ok(T response, string msg = default)
        {
            return Create(true, msg ?? "success", response);
        }
        /// <summary>
        /// Fail
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns></returns>
        public static MessageModel<T> Fail(string msg)
        {
            return Create(false, msg, default);
        }
        /// <summary>
        /// Fail
        /// </summary>
        /// <param name="msg">Message</param>
        /// <param name="response">Response Data</param>
        /// <returns></returns>
        public static MessageModel<T> Fail(string msg, T response)
        {
            return Create(false, msg, response);
        }
        /// <summary>
        /// Response 
        /// </summary>
        /// <param name="success">success/fail</param>
        /// <param name="msg">message</param>
        /// <param name="response">data</param>
        /// <returns></returns>
        public static MessageModel<T> Create(bool success, string msg, T response)
        {
            return new MessageModel<T>() { Message = msg, Response = response, IsSuccess = success };
        }
    }
}
