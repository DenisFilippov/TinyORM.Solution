namespace TinyORM.Core;

[AttributeUsage(AttributeTargets.Class)]
public class TableAttribute : TinyORMAttribute
{
  public TableAttribute(string schema, string name)
  {
    Schema = schema ?? throw new ArgumentNullException(nameof(schema));
    Name = name ?? throw new ArgumentNullException(nameof(name));
  }

  public string Schema { get; }

  public string Name { get; }
}