using StudentBio.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace StudentBio.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class StudentBioPageModel : AbpPageModel
{
    protected StudentBioPageModel()
    {
        LocalizationResourceType = typeof(StudentBioResource);
    }
}
