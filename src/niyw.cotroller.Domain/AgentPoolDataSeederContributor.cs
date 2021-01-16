using System;
using System.Threading.Tasks;
using niyw.cotroller.AgentPools;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace niyw.cotroller
{
    public class AgentPoolDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Pool, Guid> _poolRepository;

        public AgentPoolDataSeederContributor(IRepository<Pool, Guid> poolRepository)
        {
            _poolRepository = poolRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _poolRepository.GetCountAsync() <= 0)
            {
                await _poolRepository.InsertAsync(
                    new Pool
                    {
                        Name = "Demo Windows App Pool",
                        PoolType=TaskAgentPoolType.Automation,
                        CreatedOn=new DateTime(2021,1,2),
                        PoolId=3000
                    },
                    autoSave: true
                );

                await _poolRepository.InsertAsync(
                    new Pool
                    {
                        Name = "Demo Linux Pool",
                        PoolType = TaskAgentPoolType.Deployment,
                        CreatedOn = new DateTime(2021, 1, 5),
                        PoolId=4000
                    },
                    autoSave: true
                );
            }
        }
    }
}
