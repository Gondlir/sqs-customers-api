using Sqs.Customers.Domain.Abstractions.Commands;
namespace Sqs.Customers.Domain.Entities.Customers
{
    public sealed class UpdateCustomerCommand : ICommand
    {
        public UpdateCustomerCommand(Guid id, string? name, string? email, string? gitHubUsername)
        {
            Id = id;
            Name = name;
            Email = email;
            GitHubUsername = gitHubUsername;
        }
        public Guid Id { get; private init; }
        public string? Name { get; private init; }
        public string? Email { get; private init; }
        public string? GitHubUsername { get; private init; }
        public (Guid CustomerId, string Name, string GitHubUserName) Response { get; set; }
    }
}
