
namespace MasterChef.Domain.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public List<Receita>? Receitas { get; set; }
}
