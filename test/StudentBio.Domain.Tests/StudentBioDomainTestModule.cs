using Volo.Abp.Modularity;

namespace StudentBio;

[DependsOn(
    typeof(StudentBioDomainModule),
    typeof(StudentBioTestBaseModule)
)]
public class StudentBioDomainTestModule : AbpModule
{

}
