
namespace Customer.Infrastructure.Configurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
  public void Configure(EntityTypeBuilder<State> builder)
  {
    builder.ToTable("states", "cust");
    builder.HasKey(s => s.StateId);

    builder.Property(x => x.StateId)
      .HasColumnName("state_id")
      .HasColumnType("char")
      .HasMaxLength(3)
      .IsRequired();

    builder.Property(s => s.StateName)
      .HasColumnName("state_name")
      .HasColumnType("varchar")
      .HasMaxLength(100)
      .IsRequired();

    builder.Property(s => s.CountryId)
               .IsRequired()
               .HasColumnName("cnt_id")
               .HasColumnType("char")
               .HasMaxLength(3);

    //-----------------// Define ForeignKey relationships below this//-----------------//

    builder.HasOne(s => s.Country)
               .WithMany(c => c.States)
               .HasForeignKey(s => s.CountryId)
               .OnDelete(DeleteBehavior.Restrict);

    builder.HasMany(s => s.Cities)
               .WithOne(c => c.State)
               .HasForeignKey(c => c.StateId)
               .OnDelete(DeleteBehavior.Restrict);
  }
}
