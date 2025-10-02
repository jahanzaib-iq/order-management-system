

using Microsoft.EntityFrameworkCore;

namespace Order.Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Domain.Entities.Order>
{
  public void Configure(EntityTypeBuilder<Domain.Entities.Order> builder)
  {

    builder.ToTable("OrderDetails","order");
    builder.HasKey(x => x.Id);


    builder.Property(x => x.Id)
      .HasColumnName("order_id")
      .HasColumnType("int")
      .UseIdentityColumn(1);

    builder.Property(x => x.CustomerName)
      .HasColumnName("customer_name")
      .HasColumnType("varchar")
      .HasMaxLength(255)
      .IsRequired();

    builder.Property(x => x.Product)
      .HasColumnName("product")
      .HasColumnType("varchar")
      .HasMaxLength(200)
      .IsRequired();

    builder.Property(x => x.CustomerName)
      .HasColumnName("status_id")
      .HasColumnType("varchar")
      .HasMaxLength(10)
      .IsRequired();


    builder.HasOne(o => o.Status)
    .WithMany()
    .HasForeignKey(o => o.StatusId);

  }
}
