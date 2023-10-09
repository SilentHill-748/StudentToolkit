namespace StudentToolkit.Infrastructure.Data.Configurations;

public sealed class AbsenceConfiguration : IEntityTypeConfiguration<Absence>
{
    public void Configure(EntityTypeBuilder<Absence> builder)
    {
        builder.ToTable("absences");

        builder
            .Property(x => x.Date)
            .HasColumnType("DATE")
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
