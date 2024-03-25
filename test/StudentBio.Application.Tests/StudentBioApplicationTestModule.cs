using Volo.Abp.Modularity;

namespace StudentBio;

[DependsOn(
    typeof(StudentBioApplicationModule),
    typeof(StudentBioDomainTestModule)
)]
public class StudentBioApplicationTestModule : AbpModule
{

}
