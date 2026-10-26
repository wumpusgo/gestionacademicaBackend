using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using gestionAcademica.Security.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Web.Services;

public class EstudianteService : IEstudianteService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EstudianteService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EstudianteDto?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Estudiiantes.FindAsync(id);
        return _mapper.Map<EstudianteDto>(entity);
    }

    public async Task<IEnumerable<EstudianteDto>> GetAllAsync()
    {
        var entities = await _context.Estudiiantes.ToListAsync();
        return _mapper.Map<IEnumerable<EstudianteDto>>(entities);
    }

    public async Task<Estudiante> CreateAsync(EstudianteDto estudianteDto)
    {
        var entity = _mapper.Map<Estudiante>(estudianteDto);
        _context.Estudiiantes.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(EstudianteDto estudianteDto)
    {
        var entity = _mapper.Map<Estudiante>(estudianteDto);
        var existing = await _context.Estudiiantes.FindAsync(entity.Id);
        
        if (existing == null)
        {
            return false;
        }

        _context.Entry(existing).CurrentValues.SetValues(entity);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Estudiiantes.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Estudiiantes.Remove(entity);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }
}
