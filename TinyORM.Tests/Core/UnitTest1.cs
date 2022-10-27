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
    var personTable = TypeConverter.Convert(typeof(PersonEntity));
    var saleTable = TypeConverter.Convert(typeof(SaleEntity));
    Assert.That(personTable, Is.Not.Null);
    Assert.That(saleTable, Is.Not.Null);
  }
}