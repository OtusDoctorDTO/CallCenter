using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController: ControllerBase
    {
        private IPatientService _service;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService service, ILogger<PatientController> logger)
        {
            _service = service;
            _logger = logger;
        }

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

        [HttpPost]
        public async Task<IActionResult> Add(PatientDto courseModel)
        {
            try
            {
                return Ok(await _service.Create(courseModel));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка Add");
                return BadRequest();
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, PatientDto courseModel)
        {          
            try
            {
                await _service.Update(id, courseModel);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Произошла ошибка Edit");
                return BadRequest();
            }
        }
        
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
    }
}