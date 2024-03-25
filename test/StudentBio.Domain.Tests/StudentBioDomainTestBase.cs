using Volo.Abp.Modularity;

namespace StudentBio;

/* Inherit from this class for your domain layer tests. */
public abstract class StudentBioDomainTestBase<TStartupModule> : StudentBioTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
