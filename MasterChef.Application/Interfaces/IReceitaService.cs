using MasterChef.Domain.Models;

namespace MasterChef.Application.Interfaces;

public interface IReceitaService
{
    List<Receita> Load(int totalDeReceitas, string categoria = "padrao");
    Task<List<Receita>> GetAllAsync();
    Task<Receita> GetByIdAsync(int id);
    Task AddAsync(Receita receita);
    Task UpdateAsync(Receita receita);
    Task DeleteAsync(Receita receita);
}
