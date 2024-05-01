﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public Guid RoleId { get; set; }
    }
}
