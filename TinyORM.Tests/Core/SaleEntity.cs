using TinyORM.Core;

namespace TinyORM.Tests.Core;

[Table("public", name: "sales")]
public class SaleEntity
{
  [PrimaryKey]
  [Field("id")]
  public int Id { get; set; }
  
  [Index("idPerson_indx")]
  [Field("idPerson")]
  public int IdPerson { get; set; }
  
  [Index("sum_indx")]
  [Field("summ")]
  public double Summ { get; set; }
}