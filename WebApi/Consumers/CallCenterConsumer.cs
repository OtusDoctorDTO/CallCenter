using HelpersDTO.CallCenter.DTO;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System.Threading.Tasks;

namespace WebApi.Consumers
{
    public class CallCenterConsumer : IConsumer<SavePatientDTORequest>
    {
        private readonly ILogger<CallCenterConsumer> logger;
        private readonly IPatientService service;

        public CallCenterConsumer(ILogger<CallCenterConsumer> logger, IPatientService service)
        {
            this.logger = logger;
            this.service = service;
        }

        public async Task Consume(ConsumeContext<SavePatientDTORequest> context)
        {
            logger.LogInformation("Получен запрос SavePatientDTORequest {message}", context.Message);
            var result = new SavePatientDTOResponse()
            {
                Guid = context.Message.Guid,
                Success = true,
                ConnectionId = context.Message.ConnectionId
            };
            try
            {
                result.Guid = await service.Create(context.Message.Patient);
            }
            catch (System.Exception e)
            {
                logger.LogError(e, "При сохранении пациента произошла ошибка");
            }
            await context.RespondAsync(result);
        }
    }
}