using System;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace StudentBio.Students;

public abstract class StudentAppService_Tests<TStartupModule> : StudentBioApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IStudentAppService _studentAppService;

    protected StudentAppService_Tests()
    {
        _studentAppService = GetRequiredService<IStudentAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
        //Act
        var result = await _studentAppService.GetListAsync(
            new PagedAndSortedResultRequestDto()
        );

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(b => b.Name == "Sujitha");
    }
    [Fact]
    public async Task Should_Create_A_Valid_Student()
    {
        //Act
        var result = await _studentAppService.CreateAsync(
            new CreateUpdateStudentDto
            {
                Name = "Deebika",
                ClassStudentId=1003,
                DateOfBirth = DateTime.Now,
                ClassExercise = ClassStudentExercise.Maths
            }
        );

        //Assert
        result.Id.ShouldNotBe(Guid.Empty);
        result.Name.ShouldBe("Deebika");
    }
    [Fact]
    public async Task Should_Not_Create_A_Student_Without_Name()
    {
        var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
        {
            await _studentAppService.CreateAsync(
                new CreateUpdateStudentDto
                {
                    Name = "",
                    ClassStudentId=1003,
                    DateOfBirth = DateTime.Now,
                    ClassExercise = ClassStudentExercise.Maths
                }
            );
        });

        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
    }

}
