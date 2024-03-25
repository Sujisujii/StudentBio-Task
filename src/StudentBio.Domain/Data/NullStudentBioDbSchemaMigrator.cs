using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace StudentBio.Data;

/* This is used if database provider does't define
 * IStudentBioDbSchemaMigrator implementation.
 */
public class NullStudentBioDbSchemaMigrator : IStudentBioDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
