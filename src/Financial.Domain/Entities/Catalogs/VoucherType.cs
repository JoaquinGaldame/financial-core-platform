namespace Financial.Domain.Entities.Catalogs;

public sealed class VoucherType : CatalogEntity
{
    private VoucherType()
    {
    }

    public VoucherType(int id, string code, string name, bool isActive = true)
        : base(id, code, name, isActive)
    {
    }
}
