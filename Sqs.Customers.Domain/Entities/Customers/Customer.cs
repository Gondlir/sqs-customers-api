namespace Sqs.Customers.Domain.Entities.Customers
{
    public sealed class Customer
    {
        public Customer( 
            string name, string email, string gitHubUsername)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            GitHubUsername = gitHubUsername;
        }

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
