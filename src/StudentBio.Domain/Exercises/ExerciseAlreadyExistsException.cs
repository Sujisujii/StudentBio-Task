using Volo.Abp;

namespace StudentBio.Exercises;

public class ExerciseAlreadyExistsException : BusinessException
{
    public ExerciseAlreadyExistsException(string name)
        : base(StudentBioDomainErrorCodes.ExerciseAlreadyExists)
    {
        WithData("name", name);
    }
}
