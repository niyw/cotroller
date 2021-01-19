using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using niyw.cotroller.AgentPools;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BackgroundWorkers.Quartz;
using Volo.Abp.ObjectMapping;

namespace niyw.cotroller.Web.Workers
{
    public class AgentPoolWorker : QuartzBackgroundWorkerBase
    {
        private readonly IPoolAppService _poolAppService = null;
        private readonly IConfiguration _configuration = null;
        private readonly IObjectMapper _objectMapper = null;
        public AgentPoolWorker(IPoolAppService poolAppService, IConfiguration configuration, IObjectMapper objectMapper)
        {
            _poolAppService = poolAppService;
            _objectMapper = objectMapper;
            JobDetail = JobBuilder.Create<AgentPoolWorker>().WithIdentity(nameof(AgentPoolWorker)).Build();
            Trigger = TriggerBuilder.Create().WithIdentity(nameof(AgentPoolWorker)).WithSimpleSchedule(s => s.WithIntervalInMinutes(1).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires()).Build();

            ScheduleJob = async scheduler =>
            {
                if (!await scheduler.CheckExists(JobDetail.Key))
                {
                    await scheduler.ScheduleJob(JobDetail, Trigger);
                }
            };
            _configuration = configuration;
        }

        public override Task Execute(IJobExecutionContext context)
        {
            Logger.LogInformation("Executed AgentPoolWoker, get latest agent pool from azure devops..!");
            try
            {
                var psrr = new PagedAndSortedResultRequestDto { MaxResultCount = 100, SkipCount = 0 };
                var poolDto = _poolAppService.GetListAsync(psrr).Result;
                var poolEntityList = GetAgentPools();
                foreach (var poolEntity in poolEntityList)
                {
                    var findPool = poolDto.Items.FirstOrDefault(p => p.Id == poolEntity.Id);
                    if (findPool == null)
                        _poolAppService.CreateAsync(poolEntity);
                    else
                        _poolAppService.UpdateAsync(findPool.Id, poolEntity);
                }
                Logger.LogInformation("AgentPoolWoker executed successed!");
            }
            catch (Exception ex) {
                Logger.LogError(ex,"Executed AgentPoolWorker failed");
            }
            Logger.LogInformation("AgentPoolWoker executed completed!");
            return Task.CompletedTask;
        }
        private List<CreateUpdatePoolDto> GetAgentPools()
        {
            var poolEntityList = new List<CreateUpdatePoolDto>();

            var tfsConfig = _configuration.GetSection("TfsServer").Get<TfsConfig>();

            var accessToken = $":{tfsConfig.PAT}";
            accessToken = $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(accessToken))}";
            var url = $"{tfsConfig.Host}/{tfsConfig.Collection}/_apis/distributedtask/pools?api-version=6.0";
            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", accessToken);
                    using (HttpResponseMessage response = client.GetAsync(url).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseStr = response.Content.ReadAsStringAsync().Result;
                            dynamic jobj = Newtonsoft.Json.Linq.JObject.Parse(responseStr);
                            Newtonsoft.Json.Linq.JArray poollist = jobj?.value;
                            if (poollist != null)
                            {
                                for (int i = 0; i < poollist.Count; i++)
                                {
                                    //PoolEntity entity = poollist[i].ToObject<PoolEntity>();
                                    //var crudPoolDto = _objectMapper.Map<PoolEntity, CreateUpdatePoolDto>(entity);
                                    var crudPoolDto = poollist[i].ToObject<CreateUpdatePoolDto>();
                                    poolEntityList.Add(crudPoolDto);
                                }
                            }
                        }
                    }

                }
                catch (Exception Ex)
                {
                    string a = Ex.Message;
                }
            }
            return poolEntityList;

        }
    }
    public class TfsConfig
    {
        public string Host { get; set; }
        public string Collection { get; set; }
        public string PAT { get; set; }
    }
}
