namespace TinyORM.Core;

public class Context
{
  private readonly IDictionary<string, Entity> _tableCollection = new Dictionary<string, Entity>();

  public void AddEntity(Type entityType)
  {
    ArgumentNullException.ThrowIfNull(entityType, nameof(entityType));

    var table = TypeConverter.Convert(entityType);
    if (!_tableCollection.ContainsKey(table.DisplayName)) _tableCollection.Add(table.DisplayName, table);
  }
}