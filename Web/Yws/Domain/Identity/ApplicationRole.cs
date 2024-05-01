using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
            Users = new List<ApplicationUserRole>();
        }

        public virtual ICollection<ApplicationUserRole> Users { get; private set; }

        public string Name { get; set; }
    }
}
