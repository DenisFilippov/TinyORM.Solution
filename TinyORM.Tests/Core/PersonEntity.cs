using TinyORM.Core;

namespace TinyORM.Tests.Core;

[Entity]
[Table("public", "persons")]
public class PersonEntity
{
  [Field("id")]
  public long Id { get; set; }
  
  [Field("name")]
  public string Name { get; set; }
  
  [Field("age", 0)]
  public long Age { get; set; }
}