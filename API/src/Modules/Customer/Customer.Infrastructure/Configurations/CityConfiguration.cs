

namespace Customer.Infrastructure.Configurations
{
  public class CityConfiguration : IEntityTypeConfiguration<City>
  {
    public void Configure(EntityTypeBuilder<City> builder)
    {
      builder.ToTable("city", "cust");
      builder.HasKey(c => c.CityId);

      builder.Property(x => x.CityId)
        .HasColumnName("city_id")
        .HasColumnType("char")
        .HasMaxLength(3)
        .IsRequired();

      builder.Property(c => c.CityName)
        .HasColumnName("city_name")
        .HasColumnType("varchar")
        .HasMaxLength(100)
        .IsRequired();

      builder.Property(c => c.StateId)
               .IsRequired()
               .HasColumnName("state_id")
               .HasColumnType("char")
               .HasMaxLength(3);

      //-----------------// Define ForeignKey relationships below this//-----------------//

      builder.HasOne(c => c.State)
              .WithMany(s => s.Cities)
              .HasForeignKey(c => c.StateId)
              .OnDelete(DeleteBehavior.Restrict);
    }
  }
}
