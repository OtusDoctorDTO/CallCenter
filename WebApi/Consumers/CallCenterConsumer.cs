using MassTransit;
using System.Threading.Tasks;

namespace WebApi.Consumers
{
    public class CallCenterConsumer : IConsumer<CallCenterConsumer>
    {
        private readonly IMessageLogic messageLogic;

        public CallCenterConsumer(IMessageLogic messageLogic)
        {
            this.messageLogic = messageLogic;
        }

        public async Task Consume(ConsumeContext<CallCenterConsumer> context)
        {

            await messageLogic.SomeMethod("");
        }
    }
}