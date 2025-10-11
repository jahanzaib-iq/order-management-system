
namespace Customer.Infrastructure.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
  public void Configure(EntityTypeBuilder<Country> builder)
  {
    builder.ToTable("country", "cust");
    builder.HasKey(c => c.CountryId);

    builder.Property(x => x.CountryId)
       .HasColumnName("cnt_id")
       .HasColumnType("char")
       .HasMaxLength(3)
       .IsRequired();

    builder.Property(s => s.CountryName)
      .HasColumnName("cnt_name")
      .HasColumnType("varchar")
      .HasMaxLength(100)
      .IsRequired();

    //-----------------// Define ForeignKey relationships below this//-----------------//

    builder.HasMany(c => c.States)
               .WithOne(s => s.Country)
               .HasForeignKey(s => s.CountryId)
               .OnDelete(DeleteBehavior.Restrict);
  }
}
