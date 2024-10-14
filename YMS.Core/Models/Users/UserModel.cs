
namespace YMS.Core.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string? Branch { get; set; }

        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public bool Inactive { get; set; }
    }
}
