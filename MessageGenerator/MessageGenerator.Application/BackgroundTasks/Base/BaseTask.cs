using MediatR;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

namespace MessageGenerator.Application.BackgroundTasks.Base
{
    public abstract class BaseTask<TRequest> : IBackgroundTask where TRequest : IBaseRequest, new()
    {
        private readonly ILogger logger;
        private readonly IMediator mediator;

        public BaseTask(ILogger logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        public abstract string CronExpression { get; }

        public async Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation($"Task started");
            try
            {
                await mediator.Send(new TRequest(), context.CancellationToken);
                logger.LogInformation($"Task complete");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                logger.LogInformation($"Task failed");
            }
        }
    }
}
