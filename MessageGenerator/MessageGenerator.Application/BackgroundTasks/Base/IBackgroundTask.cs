using Quartz;

namespace MessageGenerator.Application.BackgroundTasks.Base
{
    public interface IBackgroundTask : IJob
    {
        string CronExpression { get; }
    }
}
