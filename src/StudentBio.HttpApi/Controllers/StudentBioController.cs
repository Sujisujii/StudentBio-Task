using StudentBio.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace StudentBio.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StudentBioController : AbpControllerBase
{
    protected StudentBioController()
    {
        LocalizationResource = typeof(StudentBioResource);
    }
}
