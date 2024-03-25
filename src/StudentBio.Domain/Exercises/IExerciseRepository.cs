using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace StudentBio.Exercises;

public interface IExerciseRepository : IRepository<Exercise, Guid>
{
    Task<Exercise> FindByNameAsync(string name);

    Task<List<Exercise>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}
