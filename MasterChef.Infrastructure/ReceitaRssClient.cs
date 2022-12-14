
using CodeHollow.FeedReader;
using MasterChef.Application.Interfaces;
using MasterChef.Domain.Models;

namespace MasterChef.Infrastructure;

public class ReceitaRssClient : IReceitaReader
{
    public List<Receita> Load()
    {
        var receitas = new List<Receita>();
        var feed = FeedReader.ReadAsync("https://g1.globo.com/rss/g1/sp/campinas-regiao/receitas/").Result;


        foreach (var item in feed.Items)
        {
            var feedItem = item.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;
            var media = feedItem.Media;
            var url = "";
            if (media.Any())
                url = media.FirstOrDefault().Url;
            receitas.Add(new Receita() { Id = 1, Titulo = item.Title, Link = item.Link, Imagem = url });
        }

        return receitas;
    }
}
