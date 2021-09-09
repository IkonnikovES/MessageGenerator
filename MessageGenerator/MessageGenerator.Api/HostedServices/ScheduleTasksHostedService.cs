using MessageGenerator.Application.BackgroundTasks.Base;
using Microsoft.Extensions.Hosting;
using Quartz;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Api.HostedServices
{
    public class ScheduleTasksHostedService : IHostedService
    {
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IEnumerable<IBackgroundTask> backgroundTasks;

        public ScheduleTasksHostedService(ISchedulerFactory schedulerFactory, IEnumerable<IBackgroundTask> backgroundTasks)
        {
            this.schedulerFactory = schedulerFactory;
            this.backgroundTasks = backgroundTasks;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scheduler = await schedulerFactory.GetScheduler(cancellationToken);
            foreach (var backgroundTask in backgroundTasks)
            {
                var type = backgroundTask.GetType();

                var job = JobBuilder.Create(type)
                    .WithIdentity(type.FullName)
                    .WithDescription(type.Name)
                    .Build();

                var trigger = TriggerBuilder.Create()
                    .WithIdentity($"{type.FullName}--Trigger")
                    .WithCronSchedule(backgroundTask.CronExpression)
                    .Build();

                await scheduler.ScheduleJob(job, trigger, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
