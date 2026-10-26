using AutoMapper;
using gestionAcademica.Core.Entities;
using gestionAcademica.Security.Data;
using gestionAcademica.Web.Interfaces;
using gestionAcademica.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionAcademica.Web.Services;

public class ClaseService : IClaseService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ClaseService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ClaseDto?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Clases.FindAsync(id);
        return _mapper.Map<ClaseDto>(entity);
    }

    public async Task<IEnumerable<ClaseDto>> GetAllAsync()
    {
        var entities = await _context.Clases.ToListAsync();
        return _mapper.Map<IEnumerable<ClaseDto>>(entities);
    }

    public async Task<Clase> CreateAsync(ClaseDto claseDto)
    {
        var entity = _mapper.Map<Clase>(claseDto);
        _context.Clases.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(ClaseDto claseDto)
    {
        var entity = _mapper.Map<Clase>(claseDto);
        var existing = await _context.Clases.FindAsync(entity.Id);

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
        var entity = await _context.Clases.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Clases.Remove(entity);
        var result = await _context.SaveChangesAsync() > 0;
        return result;
    }
}
