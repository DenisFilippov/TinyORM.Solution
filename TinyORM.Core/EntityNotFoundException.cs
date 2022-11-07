namespace TinyORM.Core;

public class EntityNotFoundException : Exception
{
  public EntityNotFoundException(Type type)
  {
    Type = type;
  }

  public Type Type { get; }
}