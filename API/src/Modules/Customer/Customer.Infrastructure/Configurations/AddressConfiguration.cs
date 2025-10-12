namespace Customer.Infrastructure.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Domain.Entities.Address>
{
  public void Configure(EntityTypeBuilder<Address> builder)
  {
    builder.ToTable("addresses", "cust");

    builder.HasKey(a => a.Id);

    builder.Property(x => x.Id)
    .HasColumnName("Id")
    .HasColumnType("uniqueidentifier")
    .HasDefaultValueSql("NEWID()");

    builder.Property(a => a.Line1)
               .IsRequired()
               .HasColumnName("line1")
               .HasColumnType("varchar")
               .HasMaxLength(500);

    builder.Property(a => a.PostalCode)
           .IsRequired()
           .HasMaxLength(20);

    builder.Property(a => a.CustomerId)
               .IsRequired()
               .HasColumnName("customer_id")
               .HasColumnType("uniqueidentifier");

    builder.Property(a => a.CountryId)
               .IsRequired()
               .HasColumnName("cnt_id")
               .HasColumnType("char")
               .HasMaxLength(3);

    builder.Property(a => a.StateId)
               .IsRequired()
               .HasColumnName("state_id")
               .HasColumnType("char")
               .HasMaxLength(3);

    builder.Property(a => a.CityId)
               .IsRequired()
               .HasColumnName("city_id")
               .HasColumnType("char")
               .HasMaxLength(3);

    //-----------------// Define ForeignKey relationships below this//-----------------//

    builder.HasOne(a => a.Customer)
              .WithMany(c => c.Addresses)
              .HasForeignKey(a => a.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne(a => a.City)
           .WithMany()
           .HasForeignKey(a => a.CityId)
           .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(a => a.State)
           .WithMany()
           .HasForeignKey(a => a.StateId)
           .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(a => a.Country)
           .WithMany()
           .HasForeignKey(a => a.CountryId)
           .OnDelete(DeleteBehavior.Restrict);
  }
}
