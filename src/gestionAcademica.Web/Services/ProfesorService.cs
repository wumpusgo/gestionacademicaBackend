using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using gestionAcademica.Security.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Web.Services;

public class ProfesorService : IProfesorService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProfesorService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProfesorDto?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Profesores.FindAsync(id);
        return _mapper.Map<ProfesorDto>(entity);
    }

    public async Task<IEnumerable<ProfesorDto>> GetAllAsync()
    {
        var entities = await _context.Profesores.ToListAsync();
        return _mapper.Map<IEnumerable<ProfesorDto>>(entities);
    }

    public async Task<Profesor> CreateAsync(ProfesorDto profesorDto)
    {
        var entity = _mapper.Map<Profesor>(profesorDto);
        _context.Profesores.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(ProfesorDto profesorDto)
    {
        var entity = _mapper.Map<Profesor>(profesorDto);
        var existing = await _context.Profesores.FindAsync(entity.Id);
        
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
        var entity = await _context.Profesores.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Profesores.Remove(entity);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }
}
