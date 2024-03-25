using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace StudentBio.Exercises;

public class Exercise : FullAuditedAggregateRoot<Guid>
{

    public int StudentExerciseId { get; set; }
    public string Name { get; private set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

    private Exercise()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Exercise(
        Guid id,
        int studentExerciseId,
        string name,
        DateTime dueDate,
        bool isCompleted)
        : base(id)
    {
        SetName(name);
       StudentExerciseId= studentExerciseId;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }

    internal Exercise ChangeName(string name)
    {
        SetName(name);
        return this;
    }

    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: ExerciseConsts.MaxNameLength
        );
    }
}
