using TinyORM.Core;

namespace TinyORM.Tests.Core;

public class UnitTest1
{
  [SetUp]
  public void Setup()
  {
  }

  [Test]
  public void MakeEntityTest()
  {
    var personEntity = TypeConverter.Convert(typeof(PersonEntity));
    var saleEntity = TypeConverter.Convert(typeof(SaleEntity));
    Assert.That(personEntity, Is.Not.Null);
    Assert.That(saleEntity, Is.Not.Null);
  }
}