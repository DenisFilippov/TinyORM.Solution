namespace TinyORM.Core;

public record Index(string Name, bool IsUnique, SortEnum SortType = SortEnum.Acs)
{
  public List<Field> Fields { get; init; } = new();
}