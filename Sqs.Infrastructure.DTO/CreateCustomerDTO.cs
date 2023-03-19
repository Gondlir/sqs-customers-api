namespace Sqs.Infrastructure.DTO
{
    public sealed class CreateCustomerDTO
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string GitHubUsername { get; init; }
    }
    public sealed class UpdateCustomerDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public string? GitHubUsername { get; init; }
    }
    public sealed class DeleteCustomerDTO
    {
        public Guid Id { get; init; }
    }
}
