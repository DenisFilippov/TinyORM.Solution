using TinyORM.Core;

namespace TinyORM.Tests.Core;

[Entity]
[Table("public", "sales")]
public class SaleEntity
{
  [Field("id")] public int Id { get; set; }

  [Field("idPerson")] public int IdPerson { get; set; }

  [Field("summ")] public double Summ { get; set; }
}