using Microsoft.Data.Sqlite;
using SQLitePCL;
using TinyORM.Core;
using TinyORM.Sqlite;

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

  [Test]
  public void SqliteSelect()
  {
    var context = Context.Instance();
    context.SqliteInitialize();
    context.AddEntity(typeof(PersonEntity));
    context.AddEntity(typeof(SaleEntity));

    using var connection = new SqliteConnection("Data Source=E:\\Projects\\CSharp\\TinyORM.Solution\\test.db");
    
    connection.Open();

    var persons = connection
      .Select<PersonEntity>("select * from persons");

    Assert.Multiple(() =>
    {
      Assert.That(persons, Is.Not.Null);
      Assert.That(3, Is.EqualTo(persons.Count()));
    });
  }
}