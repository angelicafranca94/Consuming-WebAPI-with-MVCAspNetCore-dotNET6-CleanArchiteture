namespace MasterChef.Domain.Models;

public class Receita
{
    public int Id { get; set; }
    public int CategoriaId { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Ingredientes { get; set; }
    public string ModoPreparo { get; set; }
    public string? Link { get; set; }
    public string? Imagem { get; set; }
    public string? Tags { get; set; }
}
