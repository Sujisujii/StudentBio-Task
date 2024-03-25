using System.Threading.Tasks;
using StudentBio.Localization;
using StudentBio.MultiTenancy;
using StudentBio.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace StudentBio.Web.Menus;

public class StudentBioMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<StudentBioResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                StudentBioMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        context.Menu.AddItem(
    new ApplicationMenuItem(
        "StudentBio",
        l["Menu:StudentBio"],
        icon: "fas fa-school"
    ).AddItem(
        new ApplicationMenuItem(
            "StudentBio.Students",
            l["Menu:Students"],
        icon: "fas fa-graduation-cap",

            url: "/Students"
        ).RequirePermissions(StudentBioPermissions.Students.Default) // Check the permission!
    ).AddItem( // ADDED THE NEW "AUTHORS" MENU ITEM UNDER THE "BOOK STORE" MENU
        new ApplicationMenuItem(
            "StudentBio.Exercises",
            l["Menu:Exercises"],
        icon: "fas fa-book",

            url: "/Exercises"
        ).RequirePermissions(StudentBioPermissions.Exercises.Default)
    )

);




        return Task.CompletedTask;
    }
}
