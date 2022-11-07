using System.Runtime.CompilerServices;

namespace TinyORM.Core;

public class Context
{
  private static Context? _instance;
  private readonly IDictionary<Type, Entity> _entityCollection;

  private Context()
  {
    _entityCollection = new Dictionary<Type, Entity>();
  }

  public Entity this[Type type] => _entityCollection[type];

  public void AddEntity(Type entityType)
  {
    ArgumentNullException.ThrowIfNull(entityType, nameof(entityType));

    var table = TypeConverter.Convert(entityType);
    if (!_entityCollection.ContainsKey(entityType)) _entityCollection.Add(entityType, table);
  }

  [MethodImpl(MethodImplOptions.Synchronized)]
  public static Context Instance()
  {
    return _instance ??= new Context();
  }
}