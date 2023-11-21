using System.ComponentModel.DataAnnotations;

namespace Tourism.Model
{
    public class UserProfile
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
