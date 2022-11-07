using Microsoft.Data.Sqlite;
using TinyORM.Core;

namespace TinyORM.Sqlite;

public static class SqliteConnectionExt
{
  public static IEnumerable<T> Select<T>(this SqliteConnection connection, string sql) where T : new()
  {
    var context = Context.Instance();
    var entity = context[typeof(T)];
    using var command = new SqliteCommand(sql, connection);
    using var reader = command.ExecuteReader();
    var result = new List<T>();
    while (reader.Read())
    {
      var item = new T();
      
      foreach (var field in entity.Fields)
      {
        var propertyInfo = typeof(T).GetProperties().FirstOrDefault(r => r.Name == field.PropertyName);
        if (propertyInfo == null) continue;
        propertyInfo.SetValue(item, reader[field.Name]);
      }
      
      result.Add(item);
    }

    return result;
  }
}