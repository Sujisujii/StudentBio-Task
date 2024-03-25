//using System;
//using System.Threading.Tasks;
//using Microsoft.VisualBasic;
//using Shouldly;
//using Volo.Abp.Modularity;
//using Xunit;

//namespace StudentBio.Exercises;

//public abstract class ExerciseAppService_Tests<TStartupModule> : StudentBioApplicationTestBase<TStartupModule>
//    where TStartupModule : IAbpModule
//{
//    private readonly IExerciseAppService _exerciseAppService;

//    protected ExerciseAppService_Tests()
//    {
//        _exerciseAppService = GetRequiredService<IExerciseAppService>();
//    }

//    [Fact]
//    public async Task Should_Get_All_Exercises_Without_Any_Filter()
//    {
//        var result = await _exerciseAppService.GetListAsync(new GetExerciseListDto());

//        result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
//        result.Items.ShouldContain(exercise => exercise.Name == "Suji");
//        result.Items.ShouldContain(exercise => exercise.Name == "Kani");
//    }

//    [Fact]
//    public async Task Should_Get_Filtered_Exercises()
//    {
//        var result = await _exerciseAppService.GetListAsync(
//            new GetExerciseListDto { Filter = "Suji" });

//        result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
//        result.Items.ShouldContain(exercise => exercise.Name == "Suji");
//        result.Items.ShouldNotContain(exercise => exercise.Name == "Kani");
//    }

//    [Fact]
//    public async Task Should_Create_A_New_Exercise()
//    {
//        var exerciseDto = await _exerciseAppService.CreateAsync(
//            new CreateExerciseDto
//            {
//                StudentExerciseId = 1,

//                Name = "Suji",

//                DueDate = new DateTime(1850, 05, 22),
//                IsCompleted = true
//            }
//        );

//        exerciseDto.Id.ShouldNotBe(Guid.Empty);
//        exerciseDto.Name.ShouldBe("Suji");
//    }

//    [Fact]
//    public async Task Should_Not_Allow_To_Create_Duplicate_Exercise()
//    {
//        await Assert.ThrowsAsync<ExerciseAlreadyExistsException>(async () =>
//        {
//            await _exerciseAppService.CreateAsync(
//                new CreateExerciseDto
//                {
//                    StudentExerciseId = 1,
//                    Name = "Kani",
//                    DueDate = DateTime.Now,
//                    IsCompleted = false
//                }
//            );
//        });
//    }

//    //TODO: Test other methods...
//}
