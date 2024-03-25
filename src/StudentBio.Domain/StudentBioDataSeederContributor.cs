//using System;
//using System.Threading.Tasks;
//using StudentBio.Exercises;
//using StudentBio.Students;
//using Volo.Abp.Data;
//using Volo.Abp.DependencyInjection;
//using Volo.Abp.Domain.Repositories;

//namespace StudentBio;

//public class StudentBioDataSeederContributor
//    : IDataSeedContributor, ITransientDependency
//{
//    private readonly IRepository<Student, Guid> _studentRepository;
//    private readonly IExerciseRepository _exerciseRepository;
//    private readonly ExerciseManager _exerciseManager;

//    public StudentBioDataSeederContributor(
//        IRepository<Student, Guid> studentRepository,
//        IExerciseRepository exerciseRepository,
//        ExerciseManager exerciseManager)
//    {
//        _studentRepository = studentRepository;
//        _exerciseRepository = exerciseRepository;
//        _exerciseManager = exerciseManager;
//    }

//    public async Task SeedAsync(DataSeedContext context)
//    {
//        if (await _studentRepository.GetCountAsync() > 0)
//        {
//            return;
//        }

//        var suji = await _exerciseRepository.InsertAsync(
//            await _exerciseManager.CreateAsync(
//               1,
//                "Suji",
//                new DateTime(1903, 06, 25),
//                true
//            )
//        );

//        var kani = await _exerciseRepository.InsertAsync(
//            await _exerciseManager.CreateAsync(
//                               2,
//                "Kani",
//                new DateTime(1903, 06, 25),
//                true
//            )
//        );

//        await _studentRepository.InsertAsync(
//            new Student
//            {
//                ExerciseId = suji.Id, // SET THE AUTHOR
//                Name = "Sujitha",
//                ClassStudentId=1001,
//                DateOfBirth = new DateTime(1949, 6, 8),

//                ClassExercise = ClassStudentExercise.English
//            },
//            autoSave: true
//        );

//        await _studentRepository.InsertAsync(
//            new Student
//            {
//                ExerciseId = kani.Id, // SET THE AUTHOR
//                Name = "Sujitha",
//                ClassStudentId = 1001,
//                DateOfBirth = new DateTime(1949, 6, 8),

//                ClassExercise = ClassStudentExercise.Maths
//            },
//            autoSave: true
//        );
//    }
//}




using System;
using System.Threading.Tasks;
using StudentBio.Exercises;
using StudentBio.Students;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace StudentBio;

public class StudentBioDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Student, Guid> _studentRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly ExerciseManager _exerciseManager;

    public StudentBioDataSeederContributor(
        IRepository<Student, Guid> studentRepository,
        IExerciseRepository exerciseRepository,
        ExerciseManager exerciseManager)
    {
        _studentRepository = studentRepository;
        _exerciseRepository = exerciseRepository;
        _exerciseManager = exerciseManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _studentRepository.GetCountAsync() > 0)
        {
            return;
        }

        var suji = await _exerciseRepository.InsertAsync(
            await _exerciseManager.CreateAsync(
                1,
                "Suji",
                new DateTime(2024, 06, 25),
                true
            )
        );

        var kani = await _exerciseRepository.InsertAsync(
            await _exerciseManager.CreateAsync(
                2,
                "Kani",
                new DateTime(1952, 03, 11),
                false
            )
        );

        await _studentRepository.InsertAsync(
            new Student
            {
                ExerciseId = suji.Id, // SET THE AUTHOR
                Name = "Sujitha",
                ClassStudentId=1001,
                ClassExercise = ClassStudentExercise.English,
                DateOfBirth = new DateTime(1998, 8, 10),
            },
            autoSave: true
        );

        await _studentRepository.InsertAsync(
            new Student
            {
                ExerciseId = kani.Id, // SET THE AUTHOR
                Name = "Kanisha",
                ClassStudentId = 1002,
                ClassExercise = ClassStudentExercise.English,
                DateOfBirth = new DateTime(1998, 8, 9),
            },
            autoSave: true
        );
    }
}
