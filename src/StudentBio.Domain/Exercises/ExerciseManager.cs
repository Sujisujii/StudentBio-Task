using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace StudentBio.Exercises;

public class ExerciseManager : DomainService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseManager(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<Exercise> CreateAsync(
        int studentExerciseId,
        string name,
        DateTime dueDate,
        bool isCompleted)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingAuthor = await _exerciseRepository.FindByNameAsync(name);
        if (existingAuthor != null)
        {
            throw new ExerciseAlreadyExistsException(name);
        }

        return new Exercise(
            GuidGenerator.Create(),
            studentExerciseId,
            name,
            dueDate,
            isCompleted
        );
    }

    public async Task ChangeNameAsync(
        Exercise exercise,
        string newName)
    {
        Check.NotNull(exercise, nameof(exercise));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingExercise= await _exerciseRepository.FindByNameAsync(newName);
        if (existingExercise != null && existingExercise.Id != exercise.Id)
        {
            throw new ExerciseAlreadyExistsException(newName);
        }

        exercise.ChangeName(newName);
    }
}
