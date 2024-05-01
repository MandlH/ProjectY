using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Claims = new List<ApplicationUserClaim>();
            Roles = new List<ApplicationUserRole>();
        }

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public ICollection<ApplicationUserRole> Roles { get; set; }

        public ICollection<ApplicationUserClaim> Claims { get; set; }
    }
}
