using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Elaw.Webcrawler.Models;
using Elaw.Webcrawler.Helpers;
using System.Text.Json;

namespace Elaw.Webcrawler.Business;

public class ProxyServerBusiness
{
    public async Task<List<ProxyServer>> GetProxyServersElementsOnHtml(string paginaHtml, short page)
    {
        try
        {
            HtmlDocument documents = new HtmlDocument();
            documents.LoadHtml(paginaHtml);
            var arquivo = System.IO.File.WriteAllTextAsync("page" + page + ".html", paginaHtml);
            var ListProxy = new List<ProxyServer>();
            var table = documents.DocumentNode.Descendants("tr").Where(node => node.GetAttributeValue("valign", "").Equals("top")).ToList();
            foreach (var Itens in table)
            {
                ProxyServer proxy = new ProxyServer();
                proxy.IP = Itens.Descendants("a").FirstOrDefault().GetAttributeValue("title", "").ToString();
                proxy.Port = Itens.Descendants("span").FirstOrDefault().InnerText;
                proxy.Country = string.Join(" ", Regex.Split(Itens.Descendants("img").FirstOrDefault().ParentNode.InnerText.Trim(), @"(?:\r\n|\n|\r)"));
                proxy.Protocol = Itens.Descendants("td").Take(7).LastOrDefault().InnerText;
                proxy.Page = page;
                proxy.Date = DateTime.Now;

                ListProxy.Add(proxy);

            }
            if (ListProxy != null)
            {
                return ListProxy;
            }
            else
            {
                Console.WriteLine("Não foi possível localizar os elementos desejados na página");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro na execução do  método [GetElementsdHtmlTag] - (" + ex.Message + ")");
            return null;
        }

    }
    public async Task<bool> JsonSerializarListaDeProxy(List<ProxyServer> proxyServers, string path, Guid? guid, ServiceLayerHelper qhelper)
    {
        try
        {
            var Json = JsonConvert.SerializeObject(proxyServers, Formatting.Indented);
            return await SaveLista(Json, path, proxyServers.Count(), guid, qhelper);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro na execução do  método [JsonSerializarListaDeProxy] - (" + ex.Message + ")");
        }
        return false;
    }

    private async Task<bool> SaveLista(string strJson, string path, Int32 linesNumber, Guid? guid, ServiceLayerHelper qhelper)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(strJson);
            }

            var file = new Models.File();

            file.GuidExecution = (Guid)guid.Value;
            file.Name = path;
            file.Package = strJson;
            file.LinesNumber = (short?)linesNumber;
            file.Active = true;
            file.CreatedAt = DateTime.Now;

            BaseResponse response = System.Text.Json.JsonSerializer.Deserialize<BaseResponse>(await qhelper.Post("Execution/File", file), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Thread.Sleep(500);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro na execução do  método [SaveFile] - (" + ex.Message + ")");
            return false;
        }
    }

    public async Task<bool> SavePage(string strHtml, string path)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(strHtml);
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro na execução do  método [SaveFile] - (" + ex.Message + ")");
            return false;
        }
    }
}
