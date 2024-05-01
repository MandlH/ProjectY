using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
