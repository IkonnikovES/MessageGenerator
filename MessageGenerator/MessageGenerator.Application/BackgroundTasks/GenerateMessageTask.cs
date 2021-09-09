using MediatR;
using MessageGenerator.Application.BackgroundTasks.Base;
using MessageGenerator.Application.Command;
using Microsoft.Extensions.Logging;

namespace MessageGenerator.Application.BackgroundTasks
{
    public class GenerateMessageTask : BaseTask<GenerateRandomMessageCommand>
    {
        public GenerateMessageTask(ILogger<GenerateMessageTask> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        public override string CronExpression => "0/5 * * * * ?";
    }
}
