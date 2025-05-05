using System.Text.Json;

namespace UIWeb.Infrastructure.Extensions
{
  public static class SessionExtension // Extension metotlar genelde static tanımlanır.
  {
    /// <summary>
    /// Sessiona için veri eklemek için kullanılır.
    /// </summary>
    /// <typeparam name="T">Generic ifade gelebilir.</typeparam>
    /// <param name="session">Genişletilen ifade, kullanmak için çağırılır.</param>
    /// <param name="key">Session'a eklenecek değerin anahtarı.</param>
    /// <param name="value">Session'a eklenecek değer.</param>
    public static void SetJson<T>(this ISession session, string key, T value)
    {
      session.SetString(key, JsonSerializer.Serialize(value));
    }

    /// <summary>
    /// Session'dan veri getirmek için kullanılır.
    /// </summary>
    /// <typeparam name="T">Generic ifade gelebilir</typeparam>
    /// <param name="session">Genişletilen ifade, kullanmak için çağırılır.</param>
    /// <param name="key">Session'dan getirilecek değerin anahtarı.</param>
    /// <returns>Session'dan dönen değer generic olarak gelir.</returns>
    public static T? GeJson<T>(this ISession session, string key)
    {
      var data = session.GetString(key);
      return data is null
        ? default(T)
        : JsonSerializer.Deserialize<T>(data);
    }
  }
}