using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace StudentBio.Students;

public class Student : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public int ClassStudentId { get; set; }
  public DateTime DateOfBirth { get; set; }
    public ClassStudentExercise ClassExercise { get; set; }
    public Guid ExerciseId { get; set; }


}
