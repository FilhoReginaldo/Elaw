using Elaw.Webcrawler.Business;
using Elaw.Webcrawler.Helpers;
using Elaw.Webcrawler.Models;
using System.Net;
using System.Text.Json;

class Program
{
    public static ProxyServerBusiness proxy = new ProxyServerBusiness();
    public static List<ProxyServer> listserver = new List<ProxyServer>();
    static void Main(string[] args)
    {
        string urlbase = ConfigHelper.getConfigValue("ElawConfig:URL");
        WebCrawlerRun(urlbase, 17);
    }
    public static async Task<bool> WebCrawlerRun(string url, int pageslength)
    {
        using (ServiceLayerHelper qhelper = new ServiceLayerHelper(ConfigHelper.getConfigValue("ElawConfig:URLWebApi")))
        {
            var execution = new Execution();

            execution.GuidSystem = Guid.Parse(ConfigHelper.getConfigValue("ElawConfig:GuidSystem"));
            execution.StartDate = DateTime.Now;
            execution.PagesNumber = Convert.ToInt16(pageslength);
            execution.Active = true;
            execution.CreatedAt = DateTime.Now;

            BaseResponse response = JsonSerializer.Deserialize<BaseResponse>(await qhelper.Post("Execution", execution), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            try
            {
                
                for (Int16 iterador = 1; iterador <= pageslength; iterador++)
                {
                    string urlfinal = url + iterador;
                    var html = DownloadPage(urlfinal).ToString();

                    listserver = await proxy.GetProxyServersElementsOnHtml(html, iterador);
                    string path = ConfigHelper.getConfigValue("Path:FilePath").Replace("X", iterador.ToString());
                    proxy.JsonSerializarListaDeProxy(listserver, path, response.Guid, qhelper);

                    string pathHTML = ConfigHelper.getConfigValue("Path:PagePath").Replace("X", iterador.ToString());
                    proxy.SavePage(html, pathHTML);
                }
                if (listserver.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro na execução do  método [WebCrawlerRun] - (" + ex.Message + ")");
            }
            finally
            {
                execution.Guid = (Guid)response.Guid;
                execution.EndDate = DateTime.Now;
                execution.UpdatedAt = DateTime.Now;
                await qhelper.Put("Execution", execution);
            }
        }
        return false;

    }
    public static string DownloadPage(string Url)
    {
        try
        {
            WebClient cliente = new WebClient();
            var html = cliente.DownloadString(Url);
            if (html != String.Empty)
            {
                return html;
            }
            else
            {
                Console.WriteLine("Não foi possível encontrar informações na página html" + html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro no download da URL solicitada - (" + ex.Message + ")");

        }
        return null;
    }
}
