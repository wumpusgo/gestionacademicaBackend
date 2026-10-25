using gestionAcademica.Core.Entities;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using gestionAcademica.Security.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Web.Services;

public class ProgramaAcademicoService : IProgramaAcademicoService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProgramaAcademicoService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProgramaAcademicoDto?> GetByIdAsync(Guid id)
    {
        var entity = await _context.ProgramasAcademicos.FindAsync(id);
        return _mapper.Map<ProgramaAcademicoDto>(entity);
    }

    public async Task<IEnumerable<ProgramaAcademicoDto>> GetAllAsync()
    {
        var entities = await _context.ProgramasAcademicos.ToListAsync();
        return _mapper.Map<IEnumerable<ProgramaAcademicoDto>>(entities);
    }

    public async Task<ProgramaAcademico> CreateAsync(ProgramaAcademicoDto programaAcademico)
    {
        var entity = _mapper.Map<ProgramaAcademico>(programaAcademico);
        _context.ProgramasAcademicos.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(ProgramaAcademicoDto programaAcademico)
    {
        var entity = _mapper.Map<ProgramaAcademico>(programaAcademico);
        var existing = await _context.ProgramasAcademicos.FindAsync(entity.Id);
        
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
        var entity = await _context.ProgramasAcademicos.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.ProgramasAcademicos.Remove(entity);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }
}
