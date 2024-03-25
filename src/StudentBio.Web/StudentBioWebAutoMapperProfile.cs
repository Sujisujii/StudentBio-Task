using AutoMapper;
using StudentBio.Exercises;
using StudentBio.Students;

namespace StudentBio.Web;

public class StudentBioWebAutoMapperProfile : Profile
{
    public StudentBioWebAutoMapperProfile()
    {

        CreateMap<StudentDto, CreateUpdateStudentDto>();
        CreateMap<Pages.Exercises.CreateModalModel.CreateExerciseViewModel,
            CreateExerciseDto>();
        CreateMap<ExerciseDto, Pages.Exercises.EditModalModel.EditExerciseViewModel>();
        CreateMap<Pages.Exercises.EditModalModel.EditExerciseViewModel,
                    UpdateExerciseDto>();
        CreateMap<Pages.Students.CreateModalModel.CreateStudentViewModel, CreateUpdateStudentDto>();
        CreateMap<StudentDto, Pages.Students.EditModalModel.EditStudentViewModel>();
        CreateMap<Pages.Students.EditModalModel.EditStudentViewModel, CreateUpdateStudentDto>();


        //Define your AutoMapper configuration here for the Web project.
    }
}
