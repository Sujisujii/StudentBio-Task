using AutoMapper;
using StudentBio.Exercises;
using StudentBio.Students;

namespace StudentBio;

public class StudentBioApplicationAutoMapperProfile : Profile
{
    public StudentBioApplicationAutoMapperProfile()
    {

        CreateMap<Student, StudentDto>();
        CreateMap<CreateUpdateStudentDto, Student>();
        CreateMap<Exercise, ExerciseDto>();
        CreateMap<Exercise, ExerciseLookupDto>();


        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
