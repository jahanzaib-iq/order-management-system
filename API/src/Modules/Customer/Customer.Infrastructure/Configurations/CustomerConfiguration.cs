using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Entities.Customer>
{
  public void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
  {
    builder.ToTable("customers", "cust");
    builder.HasKey(x => x.CustomerId);

    builder.Property(x => x.CustomerId)
    .HasColumnName("customer_id")
    .HasColumnType("uniqueidentifier")
    .HasDefaultValueSql("NEWID()");

    builder.Property(c => c.Email)
               .IsRequired()
               .HasColumnName("email")
               .HasColumnType("varchar")
               .HasMaxLength(200);

    builder.Property(c => c.FirstName)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(100);

    builder.Property(c => c.LastName)
           .IsRequired()
           .HasColumnType("varchar")
           .HasMaxLength(100);

    builder.Property(c => c.CreatedOn)
           .IsRequired()
           .HasColumnName("created_on")
           .HasColumnType("datetime");

    builder.Property(c => c.UpdatedOn)
           .HasColumnName("updated_on")
           .HasColumnType("datetime");


    //-----------------// Define ForeignKey relationships below this//-----------------//

    builder.HasMany(c => c.Addresses)
               .WithOne(a => a.Customer)
               .HasForeignKey(a => a.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
  }
}
