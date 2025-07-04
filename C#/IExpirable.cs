public interface IExpirable
{
    DateTime ExpiryDate { get; }
    bool IsExpired();
}