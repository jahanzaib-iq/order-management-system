namespace Customer.Domain.Entities
{
  public class Customer
  {
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerAddress { get; set; } = string.Empty;

    public bool IsActive { get; set; }

  }
}
