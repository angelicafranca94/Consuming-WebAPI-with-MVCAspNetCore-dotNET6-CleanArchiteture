using MasterChef.Domain.Models;

namespace MasterChef.Application.Interfaces;

public interface IReceitaReader
{
    public List<Receita> Load();
}
