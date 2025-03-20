using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinAgenda.src.Application.DTOs.Specialty;
using ClinAgenda.src.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ClinAgenda.src.WebAPI.Controllers
{

    [ApiController]
    [Route("api/specialty")]
    public class SpecialtyController : ControllerBase
    {
        private readonly SpecialtyUseCase _specialtyUsecase;
        public SpecialtyController(SpecialtyUseCase service)
        {
            _specialtyUsecase = service;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetSpecialtyAsync([FromQuery] int itemsPerPage = 10, [FromQuery] int page = 1)
        {
            var specialty = await _specialtyUsecase.GetSpecialtyAsync(itemsPerPage, page);
            return Ok(specialty);
        }
        [HttpPost("insert")]
        public async Task<IActionResult> CreateSpecialtyAsync([FromBody] SpecialtyInsertDTO specialty)
        {
            var createdSpecialty = await _specialtyUsecase.CreateSpecialtyAsync(specialty);
            var infosSpecialtyCreated = await _specialtyUsecase.GetSpecialtyByIdAsync(createdSpecialty);
            return Ok(infosSpecialtyCreated);
        }
        [HttpGet("listById/{id}")]
        public async Task<IActionResult> GetSpecialtyByIdAsync(int id)
        {
            var specialty = await _specialtyUsecase.GetSpecialtyByIdAsync(id);

            if (specialty == null)
            {
                return NotFound($"Especialidade com ID {id} não encontrada.");
            }

            return Ok(specialty);
        }
    }
}