using StudentBio.Samples;
using Xunit;

namespace StudentBio.EntityFrameworkCore.Applications;

[Collection(StudentBioTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<StudentBioEntityFrameworkCoreTestModule>
{

}
