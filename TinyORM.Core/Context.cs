namespace TinyORM.Core;

public class Context
{
  private readonly IDictionary<Type, Entity> _entityCollection;

  internal Context()
  {
    _entityCollection = new Dictionary<Type, Entity>();
  }

  public void AddEntity(Type entityType)
  {
    ArgumentNullException.ThrowIfNull(entityType, nameof(entityType));

    var table = TypeConverter.Convert(entityType);
    if (!_entityCollection.ContainsKey(entityType)) _entityCollection.Add(entityType, table);
  }
}