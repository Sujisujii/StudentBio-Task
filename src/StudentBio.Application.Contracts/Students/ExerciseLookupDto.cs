using System;
using Volo.Abp.Application.Dtos;

namespace StudentBio.Students;

public class ExerciseLookupDto : EntityDto<Guid>
{
    public int StudentExerciseId { get; set; }
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }

}
