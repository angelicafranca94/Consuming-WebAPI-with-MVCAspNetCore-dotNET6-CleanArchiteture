using MasterChef.Domain.Models;

namespace MasterChef.Domain.Contracts;

public interface ICategoriaRepository
{
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria> GetByIdAsync(int id);
    Task<Categoria> GetRecipesByIdAsync(int id);
    Task AddAsync(Categoria categoria);
    Task UpdateAsync(Categoria categoria);
    Task DeleteAsync(Categoria receita);
}
