namespace Domain.Shared;

public abstract class BaseEntity
{
  public Datetime CreatedOn { get; set; }
  public DateTime? UpdatedOn { get; set; }
}
