public class Cart
{
    private List<CartItem> items = new();
    public IReadOnlyList<CartItem> Items => items;

    public void Add(Product product, int quantity)
    {
        if (quantity > product.Quantity)
            throw new Exception($"There is only {product.Quantity} of {product.Name} and you ordered {quantity}");

        items.Add(new CartItem(product, quantity));
    }

    public bool IsEmpty => !items.Any();

    public double Subtotal => items.Sum(i => i.TotalPrice);

    public List<ShipmentDetail> GetShipmentDetails()
    {
        var list = new List<ShipmentDetail>();

        foreach (var item in items)
        {
            if (item.Product is IShippable s)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    list.Add(new ShipmentDetail(s.GetName(), s.GetWeight()));
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