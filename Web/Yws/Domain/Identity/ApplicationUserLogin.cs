using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
}
