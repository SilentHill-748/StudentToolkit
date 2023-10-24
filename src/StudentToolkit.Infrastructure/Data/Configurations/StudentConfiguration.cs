namespace StudentToolkit.Infrastructure.Data.Configurations;

internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder
            .Property(x => x.Id)
            .HasColumnName("student_id");

        builder
            .Property(x => x.GroupId)
            .HasColumnName("group_id")
            .IsRequired();

        builder
            .Property(x => x.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.MiddleName)
            .HasColumnName("middle_name")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(x => x.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(50)
            .IsRequired();
    }
}
