using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentBio.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace StudentBio.Exercises;

[Authorize(StudentBioPermissions.Exercises.Default)]
public class ExerciseAppService : StudentBioAppService, IExerciseAppService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly ExerciseManager _exerciseManager;

    public ExerciseAppService(
        IExerciseRepository exerciseRepository,
        ExerciseManager exerciseManager)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseManager = exerciseManager;
    }

    //...SERVICE METHODS WILL COME HERE...
    public async Task<ExerciseDto> GetAsync(Guid id)
    {
        var exercise = await _exerciseRepository.GetAsync(id);
        return ObjectMapper.Map<Exercise, ExerciseDto>(exercise);
    }
    public async Task<PagedResultDto<ExerciseDto>> GetListAsync(GetExerciseListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Exercise.Name);
        }

        var exercises = await _exerciseRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _exerciseRepository.CountAsync()
            : await _exerciseRepository.CountAsync(
                exercise => exercise.Name.Contains(input.Filter));

        return new PagedResultDto<ExerciseDto>(
            totalCount,
            ObjectMapper.Map<List<Exercise>, List<ExerciseDto>>(exercises)
        );
    }
    [Authorize(StudentBioPermissions.Exercises.Create)]
    public async Task<ExerciseDto> CreateAsync(CreateExerciseDto input)
    {
        var exercise = await _exerciseManager.CreateAsync(
            input.StudentExerciseId,
            input.Name,
            input.DueDate,
            input.IsCompleted
        );

        await _exerciseRepository.InsertAsync(exercise);

        return ObjectMapper.Map<Exercise, ExerciseDto>(exercise);
    }
    [Authorize(StudentBioPermissions.Exercises.Edit)]
    public async Task UpdateAsync(Guid id, UpdateExerciseDto input)
    {
        var exercise = await _exerciseRepository.GetAsync(id);

        if (exercise.Name != input.Name)
        {
            await _exerciseManager.ChangeNameAsync(exercise, input.Name);
        }
        exercise.StudentExerciseId = input.StudentExerciseId;
        exercise.DueDate = input.DueDate;
        exercise.IsCompleted = input.IsCompleted;

        await _exerciseRepository.UpdateAsync(exercise);
    }
    [Authorize(StudentBioPermissions.Exercises.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _exerciseRepository.DeleteAsync(id);
    }

}
