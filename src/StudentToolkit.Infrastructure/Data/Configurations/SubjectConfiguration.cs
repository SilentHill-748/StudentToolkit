namespace StudentToolkit.Infrastructure.Data.Configurations;

internal sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subjects");

        builder
            .Property(x => x.Id)
            .HasColumnName("subject_id");

        builder
            .Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();
    }
}
