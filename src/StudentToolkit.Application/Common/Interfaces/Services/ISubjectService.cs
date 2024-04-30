namespace StudentToolkit.Application.Common.Interfaces.Services;

public interface ISubjectService
{
    Task AddSubjectAsync(SubjectDto subjectDto);
    Task AddSubjectsAsync(IEnumerable<SubjectDto> subjectDtos);

    Task DeleteSubjectAsync(SubjectDto subjectDto);
    Task DeleteAllSubjectsAsync();

    Task UpdateSubjectAsync(SubjectDto subjectDto);
    Task UpdateSubjects(IEnumerable<SubjectDto> subjectDtos);

    Task<SubjectDto> GetSubjectByIdAsync(Guid id);
    IEnumerable<SubjectDto> GetAllSubjects();
}
