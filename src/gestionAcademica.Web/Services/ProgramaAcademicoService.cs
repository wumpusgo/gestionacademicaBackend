using AutoMapper;
using gestionAcademica.Core.Entities;
using gestionAcademica.Security.Data;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
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

    public async Task<IEnumerable<ProgramaAcademicoDto>> GetByEstudianteIdAsync(Guid estudianteId)
    {
        var entities = await _context
            .ProgramasAcademicos.Where(p => p.IdEstudiante == estudianteId)
            .ToListAsync();
        return _mapper.Map<IEnumerable<ProgramaAcademicoDto>>(entities);
    }

    public async Task<IEnumerable<ClaseDto>> GetClasesByEstudianteIdAsync(Guid estudianteId)
    {
        var entities = await _context
            .ProgramasAcademicos.Where(p => p.IdEstudiante == estudianteId)
            .ToListAsync();

        var clases = new List<Clase>();
        foreach (var entity in entities)
        {
            var clase = await _context.Clases.FindAsync(entity.IdClase);
            if (clase != null)
            {
                clases.Add(clase);
            }
        }

        return _mapper.Map<IEnumerable<ClaseDto>>(clases);
    }

    public async Task<IEnumerable<ClaseDto>> GetAvailableClasesByEstudianteIdAsync(
        Guid estudianteId
    )
    {
        var entities = await _context
            .ProgramasAcademicos.Where(p => p.IdEstudiante == estudianteId)
            .ToListAsync();

        var clases = await _context.Clases.ToListAsync();
        foreach (var entity in entities)
        {
            var c = await _context.Clases.FindAsync(entity.IdClase);
            if (c != null)
            {
                clases.Remove(c);
            }
        }

        return _mapper.Map<IEnumerable<ClaseDto>>(clases);
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

    public async Task<bool> CreateNewProgram(
        Guid idEstudiante,
        List<ProgramaAcademicoDto> programasAcademicos
    )
    {
        if (programasAcademicos == null || programasAcademicos.Count != 3)
        {
            return false;
        }

        var existingPrograms = _context
            .ProgramasAcademicos.Where(p => p.IdEstudiante == idEstudiante)
            .ToList();

        _context.ProgramasAcademicos.RemoveRange(existingPrograms);

        foreach (var dto in programasAcademicos)
        {
            var entity = _mapper.Map<ProgramaAcademico>(dto);
            entity.IdEstudiante = idEstudiante;
            _context.ProgramasAcademicos.Add(entity);
        }

        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }
}
