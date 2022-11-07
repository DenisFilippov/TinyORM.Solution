using Microsoft.Data.Sqlite;
using TinyORM.Core;

namespace TinyORM.Sqlite;

public static class SqliteConnectionExt
{
  private static IEnumerable<T> SelectInternal<T>(this SqliteConnection connection, string sql,
    params SqliteParameter[]? parameters) where T : new()
  {
    var context = Context.Instance();
    var entity = context[typeof(T)];

    using var command = new SqliteCommand(sql, connection);
    if (parameters != null && parameters.Length != 0) command.Parameters.AddRange(parameters);
    using var reader = command.ExecuteReader();

    var result = new List<T>();

    var propertyInfoArray = typeof(T).GetProperties();

    while (reader.Read())
    {
      var item = new T();

      foreach (var field in entity.Fields)
      {
        var propertyInfo = propertyInfoArray.FirstOrDefault(r => r.Name == field.PropertyName);
        if (propertyInfo == null) continue;
        propertyInfo.SetValue(item, reader[field.Name]);
      }

      result.Add(item);
    }

    return result;
  }

  public static IEnumerable<T> Select<T>(this SqliteConnection connection, string sql,
    params SqliteParameter[]? parameters) where T : new()
  {
    return SelectInternal<T>(connection, sql, parameters);
  }

  public static async Task<IEnumerable<T>> SelectAsync<T>(this SqliteConnection connection, string sql,
    params SqliteParameter[]? parameters) where T : new()
  {
    return await Task.Run(() => SelectInternal<T>(connection, sql, parameters));
  }
}