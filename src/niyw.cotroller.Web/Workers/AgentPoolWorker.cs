using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using niyw.cotroller.AgentPools;
using Quartz;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BackgroundWorkers.Quartz;

namespace niyw.cotroller.Web.Workers
{
    public class AgentPoolWorker : QuartzBackgroundWorkerBase
    {
        private readonly IPoolAppService _poolAppService = null;
        private readonly IConfiguration _configuration = null;
        public AgentPoolWorker(IPoolAppService poolAppService, IConfiguration configuration)
        {
            _poolAppService = poolAppService;
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
            Logger.LogInformation("Executed MyLogWorker..!");
            var psrr = new PagedAndSortedResultRequestDto { MaxResultCount=100, SkipCount=0 };
            
            var poolDto = _poolAppService.GetListAsync(psrr).Result;
            Logger.LogDebug("---------------------------");
            Logger.LogDebug(poolDto.Items.Count.ToString());
            Logger.LogDebug("---------------------------");

            //Volo.Abp.Http.Client.DynamicProxying.

            return Task.CompletedTask;
        }
        private void GetAgentPools() {

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
                            if (poollist != null) {
                                for (int i = 0; i < poollist.Count; i++) { 

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

        }
    }
    public class TfsConfig
    {
        public string Host { get; set; }
        public string Collection { get; set; }
        public string PAT { get; set; }
    }
}
