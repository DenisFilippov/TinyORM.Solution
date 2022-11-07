namespace TinyORM.Core;

public class Entity
{
  internal Entity(string? schema, string name)
  {
    Schema = schema;
    Name = name ?? throw new ArgumentNullException(name);
  }

  public string? Schema { get; }

  public string Name { get; }

  public List<Field> Fields { get; } = new();

  public List<Index> Indexes { get; } = new();

  public string DisplayName => string.IsNullOrEmpty(Schema) ? Name : $"{Schema}.{Name}";
}