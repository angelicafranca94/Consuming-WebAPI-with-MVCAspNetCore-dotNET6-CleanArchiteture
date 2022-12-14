using MasterChef.Domain.Models;

namespace MasterChef.Application.Interfaces;

public interface ICategoriaService
{
    
    Task<List<Categoria>> GetAllAsync();
    Task<Categoria> GetByIdAsync(int id);
    Task<Categoria> GetRecipesByIdAsync(int id);
}
