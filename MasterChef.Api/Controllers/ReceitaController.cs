using MasterChef.Application.Interfaces;
using MasterChef.Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MasterChef.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("Default")]
public class ReceitaController : Controller
{
    private readonly IReceitaService _receitaService;
    public ReceitaController(IReceitaService receitaService)
    {
        _receitaService = receitaService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Receita>>> Get()
    {
        return await _receitaService.GetAllAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Receita>> Get(int id)
    {
        var receitas = await _receitaService.GetByIdAsync(id);

        if (receitas is null)
            return NotFound();

        return receitas;
    }


    [HttpPost]
    public async Task<ActionResult<Receita>> Post(Receita receita)
    {
        if (ModelState.IsValid)
        {
             await _receitaService.AddAsync(receita);

            return Created($"/api/receita/{receita.Id}", receita);

        }
        return BadRequest(ModelState);
    }

    [HttpPut]
    public async Task<ActionResult<Receita>> Put(Receita receita)
    {
        if (ModelState.IsValid)
        {
            await _receitaService.UpdateAsync(receita);
            return receita;
        }

        return BadRequest(ModelState);
    }


    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var receita = await _receitaService.GetByIdAsync(id);
        if (receita == null)
            return NotFound();

        await _receitaService.DeleteAsync(receita);

        return NoContent();

    }
}
