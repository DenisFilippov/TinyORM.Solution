namespace TinyORM.Core;

public record Field(string Name, string PropertyName, Type Type, bool IsInPrimaryKey, object? DefaultValue);