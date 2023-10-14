using StudentToolkit.Infrastructure.Data.Configurations.Converters;

namespace StudentToolkit.Infrastructure.Data.Configurations;

public sealed class AbsenceConfiguration : IEntityTypeConfiguration<Absence>
{
    public void Configure(EntityTypeBuilder<Absence> builder)
    {
        builder.ToTable("absences");

        builder
            .Property(x => x.Date)
            .HasConversion<DateOnlyConverter>()
            .IsRequired();

        builder
            .Property(x => x.Reason)
            .HasMaxLength(100)
            .HasColumnName("reason");

        builder
            .Property(x => x.Hours)
            .HasColumnName("hours")
            .IsRequired();
    }
}
