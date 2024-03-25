using Xunit;

namespace StudentBio.EntityFrameworkCore;

[CollectionDefinition(StudentBioTestConsts.CollectionDefinitionName)]
public class StudentBioEntityFrameworkCoreCollection : ICollectionFixture<StudentBioEntityFrameworkCoreFixture>
{

}
