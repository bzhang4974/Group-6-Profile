using System.Text.Json;

namespace Group6_Profile.web.WebExtends
{
    public static class SessionExtensions
    { /// <summary>
      ///  session 
      /// </summary>
      /// <typeparam name="T"></typeparam>
      /// <param name="session"></param>
      /// <param name="key"></param>
      /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        /// <summary>
        /// get session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }
    }
}