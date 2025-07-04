public static class Program
{
    public static void Main()
    {
        var cheese = new Cheese("Cheese", 100, 5, DateTime.Now.AddDays(2), 0.2);
        var biscuits = new Biscuits("Biscuits", 150, 10, DateTime.Now.AddDays(1), 0.7);
        var tv = new TV("TV", 5000, 2, 8.0);
        var scratchCard = new MobileScratchCard("ScratchCard", 20, 100);

        var customer = new Customer("Hazem", 1000);
        var cart = new Cart();

        cart.Add(cheese, 2);
        cart.Add(biscuits, 1);
        cart.Add(scratchCard, 1);

        Shop.Checkout(customer, cart);
    }
}
