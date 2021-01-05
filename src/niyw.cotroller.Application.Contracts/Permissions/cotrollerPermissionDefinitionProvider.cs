using niyw.cotroller.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace niyw.cotroller.Permissions
{
    public class cotrollerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(cotrollerPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(cotrollerPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<cotrollerResource>(name);
        }
    }
}
