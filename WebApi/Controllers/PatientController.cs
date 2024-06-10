using HelpersDTO.CallCenter.DTO;
using HelpersDTO.CallCenter.DTO.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController(ILogger<PatientController> logger, IRequestClient<SavePatientDTORequest> client) : ControllerBase
    {

        /// <summary>
        /// Добавить нового пациента
        /// </summary>
        /// <param name="pacientDTO"></param>
        /// <returns></returns>
        [HttpPost("AddTestConsumer")]
        public async Task<IActionResult> TestAdd(PatientDto pacientDTO)
        {
            try
            {
                var responce = await client.GetResponse<SavePatientDTOResponse>(new SavePatientDTORequest()
                {
                    Patient = pacientDTO,
                    Guid = Guid.NewGuid()
                });
                logger.LogInformation("Получен ответ {responce}", responce.Message);
                return Ok(responce.Message.Id);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Произошла ошибка Add");
                return BadRequest();
            }
        }
    }
}