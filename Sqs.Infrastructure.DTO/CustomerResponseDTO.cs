namespace Sqs.Infrastructure.DTO
{
    public sealed class CustomerCreated
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string GitHubUsername { get; init; }
        public override string ToString() => "CustomerCreated";
    }
    public sealed class CustomerUpdated
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string GitHubUsername { get; init; }
        public override string ToString() => "CustomerUpdated";
    }
    public sealed class CustomerDeleted
    {
        public Guid Id { get; set; }
        public override string ToString() => "CustomerDeleted";
    }
}
