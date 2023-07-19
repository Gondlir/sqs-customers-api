using System.Text.Json.Serialization;

namespace Sqs.Infrastructure.DTO
{
    public sealed class CreateCustomerDTO
    {
        [JsonPropertyName("pk")]
        public string Pk => Id.ToString();

        [JsonPropertyName("sk")]
        public string Sk => Id.ToString();
        public Guid Id { get; init; } = default!;
        public string Name { get; init; }
        public string Email { get; init; }
        public string GitHubUsername { get; init; }
        public DateTime UpdateAt { get; set; }
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
