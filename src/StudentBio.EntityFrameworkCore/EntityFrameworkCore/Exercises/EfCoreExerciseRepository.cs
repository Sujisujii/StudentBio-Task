using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using StudentBio.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace StudentBio.Exercises;

public class EfCoreExerciseRepository
    : EfCoreRepository<StudentBioDbContext, Exercise, Guid>,
        IExerciseRepository
{
    public EfCoreExerciseRepository(
        IDbContextProvider<StudentBioDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }

    public async Task<Exercise> FindByNameAsync(string name)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(exercise => exercise.Name == name);
    }

    public async Task<List<Exercise>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .WhereIf(
                !filter.IsNullOrWhiteSpace(),
                exercise=> exercise.Name.Contains(filter)
                )
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
