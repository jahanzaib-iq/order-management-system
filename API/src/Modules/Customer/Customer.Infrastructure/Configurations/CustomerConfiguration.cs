
namespace Customer.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Entities.Customer>
{
  public void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
  {

    builder.ToTable("Customer","cust");
    builder.HasKey(x => x.Id);


    builder.Property(x => x.Id)
      .HasColumnName("customer_id")
      .HasColumnType("int")
      .UseIdentityColumn(1);

    builder.Property(x => x.CustomerName)
      .HasColumnName("customer_name")
      .HasColumnType("varchar")
      .HasMaxLength(255)
      .IsRequired();

    builder.Property(x => x.CustomerAddress)
      .HasColumnName("customer_address")
      .HasColumnType("varchar")
      .HasMaxLength(500)
      .IsRequired();

  }
}
