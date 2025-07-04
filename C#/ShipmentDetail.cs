public class ShipmentDetail
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public ShipmentDetail(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
}