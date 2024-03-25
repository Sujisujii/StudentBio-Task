using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using StudentBio.Exercises;
using StudentBio.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace StudentBio.Students;

[Authorize(StudentBioPermissions.Students.Default)]
public class StudentAppService :
    CrudAppService<
        Student, //The Book entity
        StudentDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateStudentDto>, //Used to create/update a book
    IStudentAppService //implement the IBookAppService
{
    private readonly IExerciseRepository _exerciseRepository;

    public StudentAppService(
        IRepository<Student, Guid> repository,
        IExerciseRepository exerciseRepository)
        : base(repository)
    {
        _exerciseRepository = exerciseRepository;
        GetPolicyName = StudentBioPermissions.Students.Default;
        GetListPolicyName = StudentBioPermissions.Students.Default;
        CreatePolicyName = StudentBioPermissions.Students.Create;
        UpdatePolicyName = StudentBioPermissions.Students.Edit;
        DeletePolicyName = StudentBioPermissions.Students.Delete;
    }

    public override async Task<StudentDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query = from student in queryable
                    join exercise in await _exerciseRepository.GetQueryableAsync() on student.ExerciseId equals exercise.Id
                    where student.Id == id
                    select new { student, exercise };

        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Student), id);
        }

        var studentDto = ObjectMapper.Map<Student, StudentDto>(queryResult.student);
        studentDto.ExerciseStudentExerciseId = queryResult.exercise.StudentExerciseId;

        studentDto.ExerciseName = queryResult.exercise.Name;
        studentDto.ExerciseDueDate = queryResult.exercise.DueDate;
        studentDto.ExerciseIsCompleted = queryResult.exercise.IsCompleted;

        return studentDto;
    }

    public override async Task<PagedResultDto<StudentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors                          
        var query = from student in queryable
                    join exercise in await _exerciseRepository.GetQueryableAsync() on student.ExerciseId equals exercise.Id
                    select new { student, exercise };

        //Paging
        query = query
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of BookDto objects
        var studentDtos = queryResult.Select(x =>
        {
            var studentDto = ObjectMapper.Map<Student, StudentDto>(x.student);

            studentDto.ExerciseStudentExerciseId = x.exercise.StudentExerciseId;
            studentDto.ExerciseName = x.exercise.Name;


            studentDto.ExerciseDueDate = x.exercise.DueDate;
            studentDto.ExerciseIsCompleted = x.exercise.IsCompleted;


            return studentDto;
        }).ToList();

        //Get the total count with another query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<StudentDto>(
            totalCount,
            studentDtos
        );
    }

    public async Task<ListResultDto<ExerciseLookupDto>> GetExerciseLookupAsync()
    {
        var exercises = await _exerciseRepository.GetListAsync();

        return new ListResultDto<ExerciseLookupDto>(
            ObjectMapper.Map<List<Exercise>, List<ExerciseLookupDto>>(exercises)
        );
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"student.{nameof(Student.Name)}";
        }

        if (sorting.Contains("exerciseName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "exerciseName",
                "exercise.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"student.{sorting}";
    }
}
