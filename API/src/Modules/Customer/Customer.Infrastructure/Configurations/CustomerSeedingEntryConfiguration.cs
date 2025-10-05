
using Customer.Domain.Entities;

namespace Customer.Infrastructure.Configurations;

public class CustomerSeedingEntryConfiguration : IEntityTypeConfiguration<CustomerSeedingEntry>
{
  public void Configure(EntityTypeBuilder<CustomerSeedingEntry> builder)
  {
    builder.ToTable("__CustomerSeedingEntry", "cust");
    builder.HasKey(x => x.Name);

    builder.Property(x => x.Name)
      .HasColumnName("name")
      .HasColumnType("varchar")
      .HasMaxLength(255);
  }
}
