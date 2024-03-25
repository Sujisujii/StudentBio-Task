using StudentBio.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace StudentBio.Permissions;

public class StudentBioPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var studentBioGroup = context.AddGroup(StudentBioPermissions.GroupName, L("Permission:StudentBio"));

        var studentsPermission = studentBioGroup.AddPermission(StudentBioPermissions.Students.Default, L("Permission:Students"));
        studentsPermission.AddChild(StudentBioPermissions.Students.Create, L("Permission:Students.Create"));
        studentsPermission.AddChild(StudentBioPermissions.Students.Edit, L("Permission:Students.Edit"));
        studentsPermission.AddChild(StudentBioPermissions.Students.Delete, L("Permission:Students.Delete"));


        var exercisesPermission = studentBioGroup.AddPermission(
        StudentBioPermissions.Exercises.Default, L("Permission:Exercises"));
        exercisesPermission.AddChild(
            StudentBioPermissions.Exercises.Create, L("Permission:Exercises.Create"));
        exercisesPermission.AddChild(
            StudentBioPermissions.Exercises.Edit, L("Permission:Exercises.Edit"));
        exercisesPermission.AddChild(
            StudentBioPermissions.Exercises.Delete, L("Permission:Exercises.Delete"));


    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StudentBioResource>(name);
    }
}
