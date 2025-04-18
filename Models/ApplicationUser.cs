using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName {  get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
    }
}
