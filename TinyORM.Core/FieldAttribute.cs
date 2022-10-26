namespace TinyORM.Core;

[AttributeUsage(AttributeTargets.Property)]
public class FieldAttribute : TinyORMAttribute
{
  public FieldAttribute(string name, object? defaultValue = null)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
    DefaultValue = defaultValue;
  }

  public string Name { get; }
  
  public object? DefaultValue { get; }
}