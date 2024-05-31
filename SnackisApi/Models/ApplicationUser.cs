using Microsoft.AspNetCore.Identity;

namespace SnackisApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Id {  get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
