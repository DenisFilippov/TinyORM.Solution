using TinyORM.Core;

namespace TinyORM.Tests.Core;

[Entity]
[Table("public", "persons")]
public class PersonEntity
{
  [PrimaryKey]
  [Field("id")]
  public int Id { get; set; }
  
  [Index("name_unq", true)]
  [Index("some_indx")]
  [Field("name")]
  public string Name { get; set; }
  
  [Index("age_indx")]
  [Index("some_indx")]
  [Field("age", 0)]
  public int Age { get; set; }
}