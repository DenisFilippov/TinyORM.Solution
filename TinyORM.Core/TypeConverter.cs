using System.Reflection;

namespace TinyORM.Core;

internal static class TypeConverter
{
  private static T? FirstOrNull<T>(IEnumerable<TinyORMAttribute> attributes) where T : TinyORMAttribute
  {
    return attributes.FirstOrDefault(r => r is T) as T ?? null;
  }

  public static Entity Convert(Type type)
  {
    ArgumentNullException.ThrowIfNull(type, nameof(type));

    var typeAttributes = type.GetCustomAttributes<TinyORMAttribute>().ToArray();

    var entityAttribute = FirstOrNull<EntityAttribute>(typeAttributes);
    if (entityAttribute == null)
      throw new ArgumentException("Type not marked with \"Entity\" attribute", nameof(type));

    var tableAttribute = typeAttributes.FirstOrDefault(r => r is TableAttribute) as TableAttribute ?? null;
    if (tableAttribute == null)
      throw new ArgumentException("Type not marked with \"Table\" attribute", nameof(type));

    var result = new Entity(tableAttribute.Schema, tableAttribute.Name);

    var properties = type.GetProperties();
    foreach (var property in properties)
    {
      var propertyAttributes = property.GetCustomAttributes<TinyORMAttribute>().ToArray();

      var fieldAttribute = FirstOrNull<FieldAttribute>(propertyAttributes);
      if (fieldAttribute != null)
      {
        var primaryKeyAttribute = FirstOrNull<PrimaryKeyAttribute>(propertyAttributes);

        var field = new Field(fieldAttribute.Name, property.Name, property.PropertyType, primaryKeyAttribute != null,
          fieldAttribute.DefaultValue);
        result.Fields.Add(field);
      }

      foreach (var tinyOrmAttribute in propertyAttributes.Where(r => r is IndexAttribute))
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