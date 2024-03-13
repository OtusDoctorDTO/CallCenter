using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

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
            return Ok(_mapper.Map<PatientModel>(await _service.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PatientModel courseModel)
        {
            return Ok(await _service.Create(_mapper.Map<PatientDto>(courseModel)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, PatientModel courseModel)
        {
            await _service.Update(id, _mapper.Map<PatientDto>(courseModel));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetList(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<PatientModel>>(await _service.GetPaged(page, itemsPerPage)));
        }
    }
}