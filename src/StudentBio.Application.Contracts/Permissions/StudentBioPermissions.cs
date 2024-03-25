namespace StudentBio.Permissions;

public static class StudentBioPermissions
{
    public const string GroupName = "StudentBio";

    public static class Students
    {
        public const string Default = GroupName + ".Students";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    public static class Exercises
    {
        public const string Default = GroupName + ".Exercises";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

}
