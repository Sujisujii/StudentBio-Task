using System.Threading.Tasks;

namespace StudentBio.Data;

public interface IStudentBioDbSchemaMigrator
{
    Task MigrateAsync();
}
