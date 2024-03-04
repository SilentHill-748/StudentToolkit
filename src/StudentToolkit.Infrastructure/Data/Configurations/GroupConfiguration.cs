namespace StudentToolkit.Infrastructure.Data.Configurations;

internal sealed class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");

        builder
            .Property(x => x.Id)
            .HasColumnName("group_id");

        builder
            .HasIndex(x => x.GroupCode)
            .IsUnique(); 

        builder
            .Property(x => x.GroupCode)
            .HasColumnName("group_code")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.EducationDirection)
            .HasColumnName("education_direction")
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(x => x.EducationFormat)
            .HasColumnName("education_format")
            .IsRequired();

        builder
            .Property(x => x.EducationType)
            .HasColumnName("education_type")
            .IsRequired();

        builder
            .Property(x => x.AdmissionYear)
            .HasColumnName("admission_year")
            .IsRequired();
    }
}
