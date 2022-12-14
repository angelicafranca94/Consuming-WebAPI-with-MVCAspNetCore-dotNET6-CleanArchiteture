using MasterChef.Domain.Models;

namespace MasterChef.Domain.Contracts;

public interface IReceitaRepository
{
    Task<List<Receita>> GetAllAsync();
    Task<Receita> GetByIdAsync(int id);

    Task AddAsync(Receita receita);

    Task UpdateAsync(Receita receita);
    Task DeleteAsync(Receita receita);
}
