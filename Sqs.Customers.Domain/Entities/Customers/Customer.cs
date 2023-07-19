using System.Text.Json.Serialization;

namespace Sqs.Customers.Domain.Entities.Customers
{
    public sealed class Customer
    {
        protected Customer() 
        {
            // Needed by ORM
        }
        public Customer( 
            string name, string email, string gitHubUsername)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            GitHubUsername = gitHubUsername;
        }

        [JsonPropertyName("pk")]
        public string Pk => Id.ToString();

        [JsonPropertyName("sk")]
        public string Sk => Id.ToString();
        public  Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public  string GitHubUsername { get; set; }

        public void AddName(string name) 
        {
          this.Name = name;
        }
        public void AddEmail(string email) 
        {
            this.Email = email;
        }
        public void AddGitHubUserName(string gitHubUsername) 
        {
            this.GitHubUsername = gitHubUsername;   
        }
    }
}
