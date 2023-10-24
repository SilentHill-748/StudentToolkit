using StudentToolkit.Infrastructure.Data.Configurations.Converters;

namespace StudentToolkit.Infrastructure.Data.Configurations;

internal sealed class AbsenceConfiguration : IEntityTypeConfiguration<Absence>
{
    public void Configure(EntityTypeBuilder<Absence> builder)
    {
        builder.ToTable("absences");

        builder
            .Property(x => x.Id)
            .HasColumnName("absence_id");

        builder
            .Property(x => x.SubjectId)
            .HasColumnName("subject_id")
            .IsRequired();

        builder
            .Property(x => x.StudentId)
            .HasColumnName("student_id")
            .IsRequired();

        builder
            .Property(x => x.Date)
            .HasColumnName("date")
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
