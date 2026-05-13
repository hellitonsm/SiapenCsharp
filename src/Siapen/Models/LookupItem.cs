namespace Siapen.Models;

public class LookupItem
{
    public int Id { get; }
    public string DisplayName { get; }

    public LookupItem(int id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }

    public override string ToString() => DisplayName;
}