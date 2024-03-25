using System;
using Volo.Abp.Application.Dtos;

namespace StudentBio.Students;

public class StudentDto : AuditedEntityDto<Guid>
{
    public Guid ExerciseId { get; set; }
    public int ExerciseStudentExerciseId { get; set; }

    public string ExerciseName { get; set; }

    public DateTime ExerciseDueDate { get; set; }
    public bool ExerciseIsCompleted { get; set; }
    public string Name { get; set; }
    public int ClassStudentId { get; set; }

    public DateTime DateOfBirth { get; set; }
    public ClassStudentExercise ClassExercise { get; set; }

}
