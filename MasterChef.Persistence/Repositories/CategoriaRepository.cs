using MasterChef.Domain.Contracts;
using MasterChef.Domain.Models;
using MasterChef.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MasterChef.Persistence.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private DataContext _dataContext;
    public CategoriaRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Categoria>> GetAllAsync()
    {
        return await _dataContext.Categorias.ToListAsync();
    }

    public async Task<Categoria> GetByIdAsync(int id)
    {
        return await _dataContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Categoria> GetRecipesByIdAsync(int id)
    {
        return await _dataContext.Categorias.Include(d => d.Receitas).FirstOrDefaultAsync(d => d.Id == id);
    }
}
