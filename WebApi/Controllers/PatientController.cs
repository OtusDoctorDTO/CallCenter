using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts;
using System;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController: ControllerBase
    {
        private readonly IPatientService _service;
        private readonly ILogger<PatientController> _logger;
        private readonly IBus _bus;
        IRequestClient<SavePatientDTORequest> _client;

        public PatientController(IBus bus, IPatientService service, ILogger<PatientController> logger, IRequestClient<SavePatientDTORequest> client)
        {
            _service = service;
            _logger = logger;
            _bus = bus;
            _client = client;
        }

        /// <summary>
        /// Получить все данные пациента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var patient = await _service.GetById(id);
                return Ok(patient);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка Get");
                return BadRequest();
            }
        }

        /// <summary>
        /// Добавить нового пациента
        /// </summary>
        /// <param name="pacientDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(PatientDto pacientDTO)
        {
            try
            {
                return Ok(await _service.Create(pacientDTO));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка Add");
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Изменить данные пациента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pacientDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, PatientDto pacientDTO)
        {          
            try
            {
                await _service.Update(id, pacientDTO);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка Edit");
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Удалить пицента
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка Delete");
                return BadRequest();
            }
        }
        
        /// <summary>
        /// Получить постраничный вывод списка пациентов
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">кол-во позиций</param>
        /// <returns></returns>
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetList(int page, int itemsPerPage)
        {
            try
            {
                return Ok(await _service.GetPaged(page, itemsPerPage));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка GetList");
                return BadRequest();
            }
        }


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
                var responce = await _client.GetResponse<SavePatientDTOResponse>(new SavePatientDTORequest()
                {
                    Patient = pacientDTO,
                    Guid = Guid.NewGuid()
                });
                _logger.LogInformation("Получен ответ {responce}", responce.Message);
                return Ok(responce.Message.Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка Add");
                return BadRequest();
            }
        }
    }
}