namespace Financial.Domain.Entities.Catalogs;

public sealed class PaymentMethod : CatalogEntity
{
    private PaymentMethod()
    {
    }

    public PaymentMethod(int id, string code, string name, bool isActive = true)
        : base(id, code, name, isActive)
    {
    }
}
