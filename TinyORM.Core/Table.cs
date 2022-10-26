namespace TinyORM.Core;

public class Table
{
  public Table(string schema, string name)
  {
    Schema = schema ?? throw new ArgumentNullException(schema);
    Name = name ?? throw new ArgumentNullException(name);
  }
  
  public string Schema { get; }
  
  public string Name { get; }
  
  public List<Field> Fields { get; } = new();

  public List<Index> Indexes { get; } = new();
}