using Volo.Abp.Application.Dtos;

namespace StudentBio.Exercises;

public class GetExerciseListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
