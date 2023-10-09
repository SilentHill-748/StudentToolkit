namespace StudentToolkit.Infrastructure.Data.Configurations;

public sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("teachers");

        builder
            .Property(x => x.Id)
            .HasColumnName("teacher_id");

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
