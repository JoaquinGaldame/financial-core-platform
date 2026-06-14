namespace Financial.Domain.Entities.Catalogs;

public abstract class CatalogEntity
{
    public int Id { get; protected set; }

    public string Code { get; protected set; } = string.Empty;

    public string Name { get; protected set; } = string.Empty;

    public bool IsActive { get; protected set; } = true;

    protected CatalogEntity()
    {
    }

    protected CatalogEntity(int id, string code, string name, bool isActive = true)
    {
        Id = id;
        Code = code;
        Name = name;
        IsActive = isActive;
    }
}
