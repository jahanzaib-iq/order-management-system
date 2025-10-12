using Microsoft.AspNetCore.Identity;
namespace Customer.Domain.Entities.Identity
{
  public class ApplicationRole : IdentityRole<Guid>
  {
    public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
  }
}
