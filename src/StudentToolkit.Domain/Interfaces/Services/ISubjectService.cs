namespace StudentToolkit.Domain.Interfaces.Services;

public interface ISubjectService
{
    Task AddSubjectAsync(SubjectDto subjectDto);
    Task AddSubjectsAsync(IEnumerable<SubjectDto> subjectDtos);

    Task DeleteSubjectAsync(SubjectDto subjectDto);
    Task DeleteAllSubjectsAsync();

    Task UpdateSubjectAsync(SubjectDto subjectDto);
    Task UpdateSubjectsAsync(IEnumerable<SubjectDto> subjectDtos);

    Task<SubjectDto> GetSubjectByIdAsync(Guid id);
    IEnumerable<SubjectDto> GetAllSubjects();
}
