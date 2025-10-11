using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Entities.Identity
{
  public class ApplicationUserRole: IdentityUserRole<Guid>
  {
    public virtual ApplicationUser? User { get; set; }
    public virtual ApplicationRole? Role { get; set; }
  }
}
