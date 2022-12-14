using MasterChef.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterChef.Persistence.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {

    }


    public DbSet<Receita> Receitas{ get; set; }
    public DbSet<Categoria> Categorias{ get; set; }
}
