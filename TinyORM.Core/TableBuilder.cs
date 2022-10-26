using System.Reflection;

namespace TinyORM.Core;

public class TableBuilder
{
  public Table Build(Type type)
  {
    ArgumentNullException.ThrowIfNull(type, nameof(type));

    var typeAttributes = type.GetCustomAttributes<TinyORMAttribute>().ToArray();
    var tableAttribute = typeAttributes.FirstOrDefault(r => r is TableAttribute) as TableAttribute ?? null;
    if (tableAttribute == null)
      throw new ArgumentException("Type not marked with \"Table\" attribute", nameof(type));

    var result = new Table(tableAttribute.Schema, tableAttribute.Name);

    var properties = type.GetProperties();
    foreach (var property in properties)
    {
      var propertyAttributes = property.GetCustomAttributes<TinyORMAttribute>().ToArray();
      
      var fieldAttribute = propertyAttributes.FirstOrDefault(r => r is FieldAttribute) as FieldAttribute ?? null;
      if (fieldAttribute != null)
      {
        var primaryKeyAttribute = propertyAttributes.FirstOrDefault(r => r is PrimaryKeyAttribute) as PrimaryKeyAttribute ?? null;

        var field = new Field(fieldAttribute.Name, property.Name, property.PropertyType, primaryKeyAttribute != null, fieldAttribute.DefaultValue);
        result.Fields.Add(field);
      }

      var indexAttributes = propertyAttributes.Where(r => r is IndexAttribute);
      foreach (var tinyOrmAttribute in indexAttributes)
      {
        var indexAttribute = tinyOrmAttribute as IndexAttribute;
        if (indexAttribute == null) continue;
        
        var index = result.Indexes.FirstOrDefault(r => r.Name == indexAttribute.Name);
        if (index == null)
        {
          index = new Index(indexAttribute.Name, indexAttribute.IsUnique, indexAttribute.SortType);
          result.Indexes.Add(index);
        }

        var field = result.Fields.First(r => r.PropertyName == property.Name);
        index.Fields.Add(field);
      }
    }
    
    return result;
  }
}