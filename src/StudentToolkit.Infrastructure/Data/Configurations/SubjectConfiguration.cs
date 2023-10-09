namespace StudentToolkit.Infrastructure.Data.Configurations;

public sealed class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("subjects");

        builder
            .Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}
