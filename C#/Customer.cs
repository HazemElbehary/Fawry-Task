public class Customer
{
    public string Name { get; }
    public double Balance { get; private set; }

    public Customer(string name, double balance)
    {
        Name = name;
        Balance = balance;
    }

    public void Deduct(double amount)
    {
        if (amount > Balance)
            throw new Exception("Insufficient balance");
        Balance -= amount;
    }
}