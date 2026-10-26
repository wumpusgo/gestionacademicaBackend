using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gestionAcademica.Web.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProgramaAcademicoController : ControllerBase
{
    private readonly IProgramaAcademicoService _service;

    public ProgramaAcademicoController(IProgramaAcademicoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProgramaAcademicoDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProgramaAcademicoDto>> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("estudiante/{estudianteId}")]
    public async Task<ActionResult<IEnumerable<ProgramaAcademicoDto>>> GetByEstudianteId(
        Guid estudianteId
    )
    {
        var result = await _service.GetByEstudianteIdAsync(estudianteId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("registeredClasses/{estudianteId}")]
    public async Task<ActionResult<IEnumerable<ProgramaAcademicoDto>>> GetClasesByEstudianteId(
        Guid estudianteId
    )
    {
        var result = await _service.GetClasesByEstudianteIdAsync(estudianteId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("avaliableClasses/{estudianteId}")]
    public async Task<
        ActionResult<IEnumerable<ProgramaAcademicoDto>>
    > GetAvaillableClasesByEstudianteId(Guid estudianteId)
    {
        var result = await _service.GetAvailableClasesByEstudianteIdAsync(estudianteId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ProgramaAcademicoDto>> Create(
        ProgramaAcademicoDto programaAcademico
    )
    {
        var result = await _service.CreateAsync(programaAcademico);
        return Ok(result);
    }

    [HttpPost("createProgram")]
    public async Task<ActionResult<bool>> CreateNewProgram(
        [FromBody] CreateNewProgramRequest request
    )
    {
        var result = await _service.CreateNewProgram(
            request.IdEstudiante,
            request.ProgramasAcademicos
        );
        if (!result)
        {
            return BadRequest("The list must contain 3 records.");
        }
        return Ok(result);
    }

    public record CreateNewProgramRequest(
        Guid IdEstudiante,
        List<ProgramaAcademicoDto> ProgramasAcademicos
    );

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
