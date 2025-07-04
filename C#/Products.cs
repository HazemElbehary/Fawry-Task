public abstract class Product
{
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; set; }

    protected Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}

public class Cheese : Product, IExpirable, IShippable
{
    public DateTime ExpiryDate { get; }
    private double weightKg;

    public Cheese(string name, double price, int quantity, DateTime expiry, double weightKg)
        : base(name, price, quantity)
    {
        ExpiryDate = expiry;
        this.weightKg = weightKg;
    }

    public bool IsExpired() => DateTime.Now > ExpiryDate;
    public string GetName() => Name;
    public double GetWeight() => weightKg;
}

public class Biscuits : Product, IExpirable, IShippable
{
    public DateTime ExpiryDate { get; }
    private double weightKg;

    public Biscuits(string name, double price, int quantity, DateTime expiry, double weightKg)
        : base(name, price, quantity)
    {
        ExpiryDate = expiry;
        this.weightKg = weightKg;
    }

    public bool IsExpired() => DateTime.Now > ExpiryDate;
    public string GetName() => Name;
    public double GetWeight() => weightKg;
}

public class TV : Product, IShippable
{
    private double weightKg;

    public TV(string name, double price, int quantity, double weightKg)
        : base(name, price, quantity)
    {
        this.weightKg = weightKg;
    }

    public string GetName() => Name;
    public double GetWeight() => weightKg;
}

public class MobileScratchCard : Product
{
    public MobileScratchCard(string name, double price, int quantity)
        : base(name, price, quantity) { }
}
