namespace TinyORM.Core;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class IndexAttribute : TinyORMAttribute
{
  public IndexAttribute(string name, bool isUnique = false, SortEnum sortType = SortEnum.Acs)
  {
    Name = name ?? throw new ArgumentNullException(nameof(name));
    IsUnique = isUnique;
    SortType = sortType;
  }

  public string Name { get; }

  public bool IsUnique { get; }

  public SortEnum SortType { get; }
}