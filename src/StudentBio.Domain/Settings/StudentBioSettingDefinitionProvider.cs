using Volo.Abp.Settings;

namespace StudentBio.Settings;

public class StudentBioSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(StudentBioSettings.MySetting1));
    }
}
