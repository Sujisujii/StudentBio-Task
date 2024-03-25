using System;
using System.ComponentModel.DataAnnotations;

namespace StudentBio.Exercises;

public class UpdateExerciseDto
{
    [Required]

    public int StudentExerciseId { get; set; }
    [Required]

    [StringLength(ExerciseConsts.MaxNameLength)]

    public string Name { get; private set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }



}
