using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace niyw.cotroller.Data
{
    /* This is used if database provider does't define
     * IcotrollerDbSchemaMigrator implementation.
     */
    public class NullcotrollerDbSchemaMigrator : IcotrollerDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}