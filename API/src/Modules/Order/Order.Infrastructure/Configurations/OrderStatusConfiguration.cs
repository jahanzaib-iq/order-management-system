
namespace Order.Infrastructure.Configurations;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
  public void Configure(EntityTypeBuilder<OrderStatus> builder)
  {
    builder.ToTable("OrderStatus", "order");
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id)
      .HasColumnName("status_id")
      .HasColumnType("int")
      .UseIdentityColumn(1);

    builder.Property(x => x.Name)
      .HasColumnName("name")
      .HasColumnType("varchar")
      .HasMaxLength(10);
  }

}



