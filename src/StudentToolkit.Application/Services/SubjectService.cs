using StudentToolkit.Domain.Exceptions;

namespace StudentToolkit.Application.Services;

public class SubjectService : Service, ISubjectService
{
    public SubjectService(IAppDbContext appDbContext)
        : base(appDbContext)
    { }

    public async Task AddSubjectAsync(SubjectDto subjectDto)
    {
        Subject subjectEntity = subjectDto.Adapt<Subject>();

        await DbContext.Subjects.AddAsync(subjectEntity);
        await DbContext.SaveChangesAsync();
    }

    public async Task AddSubjectsAsync(IEnumerable<SubjectDto> subjectDtos)
    {
        IEnumerable<Subject> subjectEntities =
            subjectDtos.Adapt<IEnumerable<Subject>>();

        await DbContext.Subjects.AddRangeAsync(subjectEntities);
        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteSubjectAsync(SubjectDto subjectDto)
    {
        Subject subjectEntity =
            await InternalGetSubjectByIdAsync(subjectDto.Id);

        DbContext.Subjects.Remove(subjectEntity);

        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAllSubjectsAsync()
    {
        IQueryable<Subject> subjectEntities = DbContext.Subjects;

        DbContext.Subjects.RemoveRange(subjectEntities);
        
        await DbContext.SaveChangesAsync();
    }

    public async Task<SubjectDto> GetSubjectByIdAsync(Guid id)
    {
        Subject subjectEntity =
            await InternalGetSubjectByIdAsync(id, hasTracking: false);

        return subjectEntity.Adapt<SubjectDto>();
    }

    public IEnumerable<SubjectDto> GetAllSubjects()
    {
        return DbContext
            .Subjects
            .AsNoTracking()
            .ProjectToType<SubjectDto>();
    }

    public async Task UpdateSubjectAsync(SubjectDto subjectDto)
    {
        await InternalUpdateSubjectAsync(subjectDto);
        
        await DbContext.SaveChangesAsync();
    }

    public async Task UpdateSubjectsAsync(IEnumerable<SubjectDto> subjectDtos)
    {
        foreach (SubjectDto subjectDto in subjectDtos)
        {
            await InternalUpdateSubjectAsync(subjectDto);
        }

        await DbContext.SaveChangesAsync();
    }

    private async Task InternalUpdateSubjectAsync(SubjectDto subjectDto)
    {
        Subject subjectEntity =
            await InternalGetSubjectByIdAsync(subjectDto.Id);

        subjectEntity.Name = subjectDto.Name;

        DbContext.Subjects.Update(subjectEntity);
    }

    private async Task<Subject> InternalGetSubjectByIdAsync(
        Guid id,
        bool hasTracking = true)
    {
        IQueryable<Subject> subjectEntities = hasTracking
            ? DbContext.Subjects
            : DbContext.Subjects.AsNoTracking();

        return await subjectEntities
            .SingleOrDefaultAsync(subject => subject.Id == id)
                ?? throw new SubjectNotFoundException(id);
    }
}
