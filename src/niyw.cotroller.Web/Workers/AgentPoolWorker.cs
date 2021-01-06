using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Quartz;

namespace niyw.cotroller.Web.Workers
{
    public class AgentPoolWorker : QuartzBackgroundWorkerBase
    {
        public AgentPoolWorker()
        {
            JobDetail = JobBuilder.Create<AgentPoolWorker>().WithIdentity(nameof(AgentPoolWorker)).Build();
            Trigger = TriggerBuilder.Create().WithIdentity(nameof(AgentPoolWorker)).WithSimpleSchedule(s => s.WithIntervalInMinutes(1).RepeatForever().WithMisfireHandlingInstructionIgnoreMisfires()).Build();


            ScheduleJob = async scheduler =>
            {
                if (!await scheduler.CheckExists(JobDetail.Key))
                {
                    await scheduler.ScheduleJob(JobDetail, Trigger);
                }
            };
        }

        public override Task Execute(IJobExecutionContext context)
        {
            Logger.LogInformation("Executed MyLogWorker..!");
            return Task.CompletedTask;
        }
    }

}
