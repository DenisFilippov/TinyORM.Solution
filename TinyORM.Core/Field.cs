namespace TinyORM.Core;

internal record Field(string Name, string PropertyName, Type Type, bool IsInPrimaryKey, object? DefaultValue);