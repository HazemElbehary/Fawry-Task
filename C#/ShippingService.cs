public static class ShippingService
{
    public static void Ship(List<ShipmentDetail> items)
    {
        if (!items.Any()) return;

        Console.WriteLine("** Shipment notice **");
        foreach (var group in items.GroupBy(i => i.Name))
        {
            int count = group.Count();
            double totalWeightGrams = group.Sum(i => i.Weight) * 1000;
            Console.WriteLine($"{count}x {group.Key,-12} {totalWeightGrams,6:0}g");
        }

        double totalWeight = items.Sum(i => i.Weight);
        Console.WriteLine($"Total package weight {totalWeight:0.0}kg");
    }
}
