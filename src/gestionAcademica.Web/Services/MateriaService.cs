using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using gestionAcademica.Security.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Web.Services;

public class MateriaService : IMateriaService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MateriaService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MateriaDto?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Materias.FindAsync(id);
        return _mapper.Map<MateriaDto>(entity);
    }

    public async Task<IEnumerable<MateriaDto>> GetAllAsync()
    {
        var entities = await _context.Materias.ToListAsync();
        return _mapper.Map<IEnumerable<MateriaDto>>(entities);
    }

    public async Task<Materia> CreateAsync(MateriaDto materiaDto)
    {
        var entity = _mapper.Map<Materia>(materiaDto);
        _context.Materias.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(MateriaDto materiaDto)
    {
        var entity = _mapper.Map<Materia>(materiaDto);
        var existing = await _context.Materias.FindAsync(entity.Id);
        
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
        var entity = await _context.Materias.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Materias.Remove(entity);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }
}
