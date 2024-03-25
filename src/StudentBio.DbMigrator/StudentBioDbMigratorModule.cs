using StudentBio.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace StudentBio.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StudentBioEntityFrameworkCoreModule),
    typeof(StudentBioApplicationContractsModule)
    )]
public class StudentBioDbMigratorModule : AbpModule
{
}
