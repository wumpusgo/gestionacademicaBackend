using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gestionAcademica.Web.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClaseController : ControllerBase
{
    private readonly IClaseService _service;

    public ClaseController(IClaseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClaseDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClaseDto>> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Clase>> Create(ClaseDto claseDto)
    {
        var result = await _service.CreateAsync(claseDto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Update(ClaseDto claseDto)
    {
        var result = await _service.UpdateAsync(claseDto);
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
