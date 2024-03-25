using StudentBio.Students;
using Xunit;

namespace StudentBio.EntityFrameworkCore.Applications.Students;

[Collection(StudentBioTestConsts.CollectionDefinitionName)]
public class EfCoreStudentAppService_Tests : StudentAppService_Tests<StudentBioEntityFrameworkCoreTestModule>
{

}
