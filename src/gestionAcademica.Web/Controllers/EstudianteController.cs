using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gestionAcademica.Web.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class EstudianteController : ControllerBase
{
    private readonly IEstudianteService _service;

    public EstudianteController(IEstudianteService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EstudianteDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EstudianteDto>> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Estudiante>> Create(EstudianteDto estudianteDto)
    {
        var result = await _service.CreateAsync(estudianteDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Update(EstudianteDto estudianteDto)
    {
        var result = await _service.UpdateAsync(estudianteDto);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
}
