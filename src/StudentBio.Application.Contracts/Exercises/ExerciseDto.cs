using System;
using Volo.Abp.Application.Dtos;

namespace StudentBio.Exercises;

public class ExerciseDto : EntityDto<Guid>
{

    public int StudentExerciseId { get; set; }
    public string Name { get; private set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }



}