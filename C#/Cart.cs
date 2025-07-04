public class Cart
{
    private List<CartItem> items = new();
    public IReadOnlyList<CartItem> Items => items;

    public void Add(Product product, int quantity)
    {
        if (quantity > product.Quantity)
            throw new Exception($"Not enough stock for {product.Name}");

        items.Add(new CartItem(product, quantity));
    }

    public bool IsEmpty => !items.Any();

    public double Subtotal => items.Sum(i => i.TotalPrice);

    public List<(string name, double weight)> GetShipmentDetails()
    {
        var list = new List<(string, double)>();

        foreach (var item in items)
        {
            if (item.Product is IShippable s)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    list.Add((s.GetName(), s.GetWeight()));
                }
            }
        }

        return list;
    }

    public bool HasExpiredItems()
    {
        return items.Any(i => i.Product is IExpirable e && e.IsExpired());
    }

    public bool HasOutOfStock()
    {
        return items.Any(i => i.Quantity > i.Product.Quantity);
    }

    public void ReduceStock()
    {
        foreach (var item in items)
        {
            item.Product.Quantity -= item.Quantity;
        }
    }
}