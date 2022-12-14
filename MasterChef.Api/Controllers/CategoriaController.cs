using MasterChef.Application.Interfaces;
using MasterChef.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MasterChef.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("Default")]
public class CategoriaController : Controller
{
    private readonly ICategoriaService _categoriaService;
    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> Get()
    {
        return await _categoriaService.GetAllAsync();
    }


    [HttpGet]
    [Route("listrecipes/{id}")]
    public async Task<ActionResult<Categoria>> Get(int id)
    {
        var categoria = await _categoriaService.GetRecipesByIdAsync(id);

        if (categoria is null)
            return NotFound();

        return categoria;
    }
}
