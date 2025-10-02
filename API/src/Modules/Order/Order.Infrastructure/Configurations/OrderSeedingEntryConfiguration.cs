
namespace Order.Infrastructure.Configurations;

public class OrderSeedingEntryConfiguration : IEntityTypeConfiguration<OrderSeedingEntry>
{
  public void Configure(EntityTypeBuilder<OrderSeedingEntry> builder)
  {
    builder.ToTable("__OrderSeedingEntry", "order");
    builder.HasKey(x => x.Name);

    builder.Property(x => x.Name)
      .HasColumnName("name")
      .HasColumnType("varchar")
      .HasMaxLength(255);
  }
}
