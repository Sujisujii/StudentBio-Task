using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace StudentBio.Exercises;

public interface IExerciseAppService : IApplicationService
{
    Task<ExerciseDto> GetAsync(Guid id);

    Task<PagedResultDto<ExerciseDto>> GetListAsync(GetExerciseListDto input);

    Task<ExerciseDto> CreateAsync(CreateExerciseDto input);

    Task UpdateAsync(Guid id, UpdateExerciseDto input);

    Task DeleteAsync(Guid id);
}
