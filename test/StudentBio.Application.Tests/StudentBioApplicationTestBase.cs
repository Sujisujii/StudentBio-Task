using Volo.Abp.Modularity;

namespace StudentBio;

public abstract class StudentBioApplicationTestBase<TStartupModule> : StudentBioTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
