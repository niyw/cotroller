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
    public class ProjectWorker : QuartzBackgroundWorkerBase
    {
        private readonly IProjectAppService _projectAppService = null;
        private readonly IConfiguration _configuration = null;
        private readonly IObjectMapper _objectMapper = null;
        public ProjectWorker(IProjectAppService projectAppService, IConfiguration configuration, IObjectMapper objectMapper)
        {
            _projectAppService = projectAppService;
            _objectMapper = objectMapper;
            JobDetail = JobBuilder.Create<ProjectWorker>().WithIdentity(nameof(ProjectWorker)).Build();
            Trigger = TriggerBuilder.Create().WithIdentity(nameof(ProjectWorker)).WithSimpleSchedule(s => s.WithIntervalInMinutes(15).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires()).Build();

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
            Logger.LogInformation("Executed ProjectWoker, get latest agent pool from azure devops..!");
            try
            {
                var psrr = new PagedAndSortedResultRequestDto { MaxResultCount = 200, SkipCount = 0 };
                var projectDto = _projectAppService.GetListAsync(psrr).Result;
                var projectEntityList = GetProjects();
                foreach (var poolEntity in projectEntityList)
                {
                    var findPool = projectDto.Items.FirstOrDefault(p => p.Id == poolEntity.Id);
                    if (findPool == null)
                        _projectAppService.CreateAsync(poolEntity);
                    else
                        _projectAppService.UpdateAsync(findPool.Id, poolEntity);
                }
                Logger.LogInformation("ProjectWoker executed successed!");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Executed ProjectWoker failed");
            }
            Logger.LogInformation("ProjectWoker executed completed!");
            return Task.CompletedTask;
        }
        private List<CreateUpdateProjectDto> GetProjects()
        {
            var projectEntityList = new List<CreateUpdateProjectDto>();
            var tfsConfig = _configuration.GetSection("TfsServer").Get<TfsConfig>();
            var accessToken = $":{tfsConfig.PAT}";
            accessToken = $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes(accessToken))}";
            var url = $"{tfsConfig.Host}/{tfsConfig.Collection}/_apis/projects?api-version=6.0";
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
                            Newtonsoft.Json.Linq.JArray projectlist = jobj?.value;
                            if (projectlist != null)
                            {
                                for (int i = 0; i < projectlist.Count; i++)
                                {
                                    var crudPoolDto = projectlist[i].ToObject<CreateUpdateProjectDto>();
                                    projectEntityList.Add(crudPoolDto);
                                }
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
            return projectEntityList;
        }
    }
}
