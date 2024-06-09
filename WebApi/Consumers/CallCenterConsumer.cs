using HelpersDTO.CallCenter.DTO;
using HelpersDTO.Patient;
using MassTransit;
using Microsoft.Extensions.Logging;
using Services.Repositories.Abstractions;
using System.Threading.Tasks;
using Infrastructure.Repositories.Implementations.Mapping;

namespace WebApi.Consumers
{
    public class CallCenterConsumer(ILogger<CallCenterConsumer> logger, IDocumentRepository documentRepository) : IConsumer<CreateNewPassportRequest>
    {
        private readonly ILogger<CallCenterConsumer> logger = logger;
        private readonly IDocumentRepository _documentRepository = documentRepository;

        public async Task Consume(ConsumeContext<CreateNewPassportRequest> context)
        {
            logger.LogInformation("Получен запрос CreateNewPassportRequest {message}", context.Message);
            var result = new SavePatientDTOResponse()
            {
                Guid = context.Message.Guid,
                Success = true,
                ConnectionId = context.Message.ConnectionId
            };
            try
            {
                var document = context.Message.Passport.ToDocument(context.Message.UserId);
                if(document != null)
                    await _documentRepository.CreatePassport(document);
            }
            catch (System.Exception e)
            {
                logger.LogError(e, "При сохранении CreateNewPassportRequest произошла ошибка");
            }
            await context.RespondAsync(result);
        }
    }
}