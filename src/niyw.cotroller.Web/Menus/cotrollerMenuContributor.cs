using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using niyw.cotroller.Localization;
using niyw.cotroller.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace niyw.cotroller.Web.Menus
{
    public class cotrollerMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<cotrollerResource>();
            var agentPoolLocalizer = context.GetLocalizer<AgentPoolsResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(cotrollerMenus.Home, l["Menu:Home"], "~/"));

            context.Menu.AddItem(new ApplicationMenuItem("AgentPools", agentPoolLocalizer["Menu:AgentPools"], icon: "fa fa-book")
                .AddItem(new ApplicationMenuItem("AgentPools.Pools", agentPoolLocalizer["Menu:Pools"], url: "/AgentPools"))
                );

        }
    }
}
