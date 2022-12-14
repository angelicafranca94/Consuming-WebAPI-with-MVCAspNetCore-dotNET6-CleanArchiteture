using MasterChef.Application.Interfaces;
using MasterChef.Domain.Contracts;
using MasterChef.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MasterChef.Application.Service;

public class ReceitaService : IReceitaService
{
    private IReceitaReader _reader;
    private IMemoryCache _cache;
    private IReceitaRepository _receitaRepository;

    public ReceitaService(IMemoryCache cache, IReceitaReader reader, IReceitaRepository receitaRepository)
    {
        _reader = reader;
        _cache = cache;
        _receitaRepository = receitaRepository;
    }

    public List<Receita> Load(int totalDeNoticias, string categoria = "padrao")
    {
        var receitas = new List<Receita>();
        var key = $"noticias_{categoria}";

        if (!_cache.TryGetValue(key, out receitas))
        {
            receitas = _reader.Load();

            var cacheEntryOption = new MemoryCacheEntryOptions()
                //.SetSlidingExpiration()
                .SetAbsoluteExpiration(DateTime.Now.AddSeconds(60));

            _cache.Set(key, receitas, cacheEntryOption);
        }

        return receitas.Where(a => a.Imagem != "").ToList();
    }

    public async Task<List<Receita>> GetAllAsync()
    {
        return await _receitaRepository.GetAllAsync();
    }

    public async Task<Receita> GetByIdAsync(int id)
    {
        return await _receitaRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Receita receita)
    {
        if (!receita.Imagem.Contains("http"))
            receita.Imagem = null;

        await _receitaRepository.AddAsync(receita);
    }

    public async Task UpdateAsync(Receita receita)
    {
        if (!receita.Imagem.Contains("http"))
            receita.Imagem = null;

        await _receitaRepository.UpdateAsync(receita);
    }
    
    public async Task DeleteAsync(Receita receita)
    {
        await _receitaRepository.DeleteAsync(receita);
    }
}
