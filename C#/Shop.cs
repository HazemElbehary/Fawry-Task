public static class Shop
{
    public static void Checkout(Customer customer, Cart cart)
    {
        if (cart.IsEmpty)
            throw new Exception("Cart is empty");

        if (cart.HasExpiredItems())
            throw new Exception("Cart has expired items");

        if (cart.HasOutOfStock())
            throw new Exception("Some products are out of stock");

        var shippingItems = cart.GetShipmentDetails();
        double shippingCost = shippingItems.Count * 10;

        double subtotal = cart.Subtotal;
        double total = subtotal + shippingCost;

        customer.Deduct(total);
        cart.ReduceStock();

        ShippingService.Ship(shippingItems);

        Console.WriteLine("** Checkout receipt **");
        foreach (var item in cart.Items)
        {
            Console.WriteLine($"{item.Quantity}x {item.Product.Name,-12} {item.TotalPrice,6:0}");
        }

        Console.WriteLine("----------------------");
        Console.WriteLine($"{"Subtotal",-12}{subtotal,6:0}");
        Console.WriteLine($"{"Shipping",-12}{shippingCost,6:0}");
        Console.WriteLine($"{"Amount",-12}{total,6:0}");
    }
}
