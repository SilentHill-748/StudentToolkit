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
            .Property(x => x.GroupCode)
            .HasColumnName("group_code")
            .HasMaxLength(11)
            .IsRequired();
    }
}
