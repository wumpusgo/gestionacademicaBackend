using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gestionAcademica.Web.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class MateriaController : ControllerBase
{
    private readonly IMateriaService _service;

    public MateriaController(IMateriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MateriaDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MateriaDto>> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Materia>> Create(MateriaDto materiaDto)
    {
        var result = await _service.CreateAsync(materiaDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Update(MateriaDto materiaDto)
    {
        var result = await _service.UpdateAsync(materiaDto);
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
