namespace TinyORM.Core;

public class EntityNotFoundException : Exception
{
  public Type Type { get; }

  public EntityNotFoundException(Type type)
  {
    Type = type;
  }
}