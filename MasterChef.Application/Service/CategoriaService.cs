using MasterChef.Application.Interfaces;
using MasterChef.Domain.Contracts;
using MasterChef.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MasterChef.Application.Service;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }
    public async Task<List<Categoria>> GetAllAsync()
    {
        return await _categoriaRepository.GetAllAsync();
    }
    public async Task<Categoria> GetByIdAsync(int id)
    {
        return await _categoriaRepository.GetByIdAsync(id);
    }
    public async Task<Categoria> GetRecipesByIdAsync(int id)
    {
        return await _categoriaRepository.GetRecipesByIdAsync(id);
    }
    public async Task AddAsync(Categoria categoria)
    {
        await _categoriaRepository.AddAsync(categoria);
    }
    public async Task UpdateAsync(Categoria categoria)
    {
        await _categoriaRepository.UpdateAsync(categoria);
    }
    public async Task DeleteAsync(Categoria categoria)
    {
        await _categoriaRepository.DeleteAsync(categoria);
    }
}
