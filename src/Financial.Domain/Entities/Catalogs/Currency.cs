namespace Financial.Domain.Entities.Catalogs;

public sealed class Currency
{
    public int Id { get; private set; }

    public string Code { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public string Symbol { get; private set; } = string.Empty;

    public bool IsActive { get; private set; } = true;

    private Currency()
    {
    }

    public Currency(int id, string code, string name, string symbol, bool isActive = true)
    {
        Id = id;
        Code = code;
        Name = name;
        Symbol = symbol;
        IsActive = isActive;
    }
}
