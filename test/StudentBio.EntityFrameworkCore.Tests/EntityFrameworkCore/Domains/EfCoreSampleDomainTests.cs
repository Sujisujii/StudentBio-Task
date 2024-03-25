using StudentBio.Samples;
using Xunit;

namespace StudentBio.EntityFrameworkCore.Domains;

[Collection(StudentBioTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<StudentBioEntityFrameworkCoreTestModule>
{

}
