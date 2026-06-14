namespace Financial.Domain.Entities.Catalogs;

public sealed class CustomerType : CatalogEntity
{
    private CustomerType()
    {
    }

    public CustomerType(int id, string code, string name, bool isActive = true)
        : base(id, code, name, isActive)
    {
    }
}
