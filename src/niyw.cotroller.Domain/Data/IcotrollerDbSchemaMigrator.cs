using System.Threading.Tasks;

namespace niyw.cotroller.Data
{
    public interface IcotrollerDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
