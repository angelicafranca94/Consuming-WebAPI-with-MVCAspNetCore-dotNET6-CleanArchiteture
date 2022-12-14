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

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Categoria>> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);

        if (categoria is null)
            return NotFound();

        return categoria;
    }

    [HttpPost]
    public async Task<ActionResult<Receita>> Post(Categoria categoria)
    {
        if (ModelState.IsValid)
        {
            await _categoriaService.AddAsync(categoria);

            return Created($"/api/categoria/{categoria.Id}", categoria);

        }
        return BadRequest(ModelState);
    }

    [HttpPut]
    public async Task<ActionResult<Categoria>> Put(Categoria categoria)
    {
        if (ModelState.IsValid)
        {
            await _categoriaService.UpdateAsync(categoria);
            return categoria;
        }

        return BadRequest(ModelState);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var receita = await _categoriaService.GetByIdAsync(id);
        if (receita == null)
            return NotFound();

        await _categoriaService.DeleteAsync(receita);

        return NoContent();

    }
}
