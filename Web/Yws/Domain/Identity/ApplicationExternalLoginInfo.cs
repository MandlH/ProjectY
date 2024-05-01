using System.Security.Claims;

namespace Domain.Identity
{
    internal class ApplicationExternalLoginInfo
    {
        public string DefaultUserName { get; set; }

        public string Email { get; set; }

        public ClaimsIdentity ExternalIdentity { get; set; }

        public ApplicationUserLogin Login { get; set; }
    }
}
