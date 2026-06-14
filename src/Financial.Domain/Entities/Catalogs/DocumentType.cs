namespace Financial.Domain.Entities.Catalogs;

public sealed class DocumentType : CatalogEntity
{
    private DocumentType()
    {
    }

    public DocumentType(int id, string code, string name, bool isActive = true)
        : base(id, code, name, isActive)
    {
    }
}
