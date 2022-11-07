using System.Runtime.CompilerServices;

namespace TinyORM.Core;

public class Context
{
  private readonly IDictionary<Type, Entity> _entityCollection;
  private static Context _instance = null;

  private Context()
  {
    _entityCollection = new Dictionary<Type, Entity>();
  }

  public void AddEntity(Type entityType)
  {
    ArgumentNullException.ThrowIfNull(entityType, nameof(entityType));

    var table = TypeConverter.Convert(entityType);
    if (!_entityCollection.ContainsKey(entityType)) _entityCollection.Add(entityType, table);
  }

  public Entity this[Type type] => _entityCollection[type];

  [MethodImpl(MethodImplOptions.Synchronized)]
  public static Context Instance()
  {
    if (_instance == null)
    {
      _instance = new Context();
    }

    return _instance;
  }
}