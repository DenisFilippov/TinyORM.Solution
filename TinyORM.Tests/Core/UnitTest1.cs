using TinyORM.Core;

namespace TinyORM.Tests.Core;

public class UnitTest1
{
  [SetUp]
  public void Setup()
  {
  }

  [Test]
  public void MakeTableTest()
  {
    var personTable = new TableBuilder().Build(typeof(PersonEntity));
    var saleTable = new TableBuilder().Build(typeof(SaleEntity));
    Assert.That(personTable, Is.Not.Null);
    Assert.That(saleTable, Is.Not.Null);
  }
}