namespace Sqs.Customers.Domain.Abstractions.Interfaces
{
    public interface IUoW : IDisposable
    {
        bool Commit();
    }
}
