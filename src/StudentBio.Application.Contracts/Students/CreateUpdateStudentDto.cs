using System;
using System.ComponentModel.DataAnnotations;

namespace StudentBio.Students;

public class CreateUpdateStudentDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int ClassStudentId { get; set; }

   
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
    [Required]
    public ClassStudentExercise ClassExercise { get; set; } = ClassStudentExercise.Tamil;

    public Guid ExerciseId { get; set; }


}
