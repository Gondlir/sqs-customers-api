using Sqs.Customers.Domain.Abstractions.Commands;

namespace Sqs.Customers.Domain.Entities.Customers.Commands
{
    public sealed class CreateCustomerCommand : ICommand
    {
        public CreateCustomerCommand(string name, string email, string gitHubUsername)
        {
            // Caracteres Validations....
            Name = name;
            Email = email;
            GitHubUsername = gitHubUsername;
        }

        public string Name { get; private init; }
        public string Email { get; private init; }
        public string GitHubUsername { get; private init; }
        public (Guid customerId, string Name, string GitHubUserName) Response { get; set; }
    }
}
