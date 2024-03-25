using System;
using System.Collections.Generic;
using System.Text;
using StudentBio.Localization;
using Volo.Abp.Application.Services;

namespace StudentBio;

/* Inherit your application services from this class.
 */
public abstract class StudentBioAppService : ApplicationService
{
    protected StudentBioAppService()
    {
        LocalizationResource = typeof(StudentBioResource);
    }
}
