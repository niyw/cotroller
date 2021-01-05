using Volo.Abp.Settings;

namespace niyw.cotroller.Settings
{
    public class cotrollerSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(cotrollerSettings.MySetting1));
        }
    }
}
