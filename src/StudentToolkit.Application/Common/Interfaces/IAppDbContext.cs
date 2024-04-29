namespace StudentToolkit.Application.Common.Interfaces;

public interface IAppDbContext
{
    public DbSet<Group> Groups { get; }
    public DbSet<Student> Students { get; }
    public DbSet<Absence> Absences { get; }
    public DbSet<Subject> Subjects { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
