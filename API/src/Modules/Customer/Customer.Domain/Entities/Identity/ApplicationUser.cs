using Microsoft.AspNetCore.Identity;

namespace Customer.Domain.Entities.Identity
{
  public class ApplicationUser : IdentityUser<Guid>
  {
    public bool IsActive { get; set; }
    public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
  }
}
