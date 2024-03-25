using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace StudentBio.Web;

[Dependency(ReplaceServices = true)]
public class StudentBioBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "StudentBio";
}
