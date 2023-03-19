namespace Sqs.Infrastructure.DTO
{
    public sealed class CreateCustomerDTO
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string GitHubUsername { get; init; }
    }
}
