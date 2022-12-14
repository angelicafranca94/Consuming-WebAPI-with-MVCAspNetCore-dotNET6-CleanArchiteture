using MasterChef.Domain.Contracts;
using MasterChef.Domain.Models;
using MasterChef.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MasterChef.Persistence.Repositories;

public class ReceitaRepository : IReceitaRepository
{
    private DataContext _dataContext;
    public ReceitaRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Receita>> GetAllAsync()
    {
        return await _dataContext.Receitas.ToListAsync();
    }

    public async Task<Receita> GetByIdAsync(int id)
    {
        return await _dataContext.Receitas.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Receita receita)
    {
        await  _dataContext.Receitas.AddAsync(receita);

        await _dataContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Receita receita)
    {
         _dataContext.Receitas.Update(receita);

        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Receita receita)
    {
        _dataContext.Receitas.Remove(receita);

        await _dataContext.SaveChangesAsync();
    }
}
