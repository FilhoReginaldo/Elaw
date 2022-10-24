using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Elaw.Webcrawler.Models;

public class ProxyServer
{
    public string IP { get; set; }
    public string Port { get; set; }
    public string Country { get; set; }
    public string Protocol { get; set; }
    public short Page { get; set; }
    public DateTime Date { get; set; }
}



