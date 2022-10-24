using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elaw.Webcrawler.Helpers;

public class ServiceLayerHelper : IDisposable
{
    private System.Net.Http.HttpClient httpClient = null;
    private string ServiceLayerServer = string.Empty;
    private string ServiceLayerServerToken = string.Empty;
    private bool Connected = false;


    public ServiceLayerHelper(string url)
    {

        ServiceLayerServer = url;
        this.Login();

    }

    private async void Login()
    {
        
        System.Net.Http.HttpClientHandler handler = new System.Net.Http.HttpClientHandler();
        handler.UseCookies = false;

        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.ServerCertificateCustomValidationCallback =
            (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            };


        System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(handler);
        client.DefaultRequestHeaders.ExpectContinue = false;
        client.DefaultRequestHeaders.ConnectionClose = false;

        client = null;
        client = new System.Net.Http.HttpClient(handler);
        client.DefaultRequestHeaders.ExpectContinue = false;
        client.DefaultRequestHeaders.ConnectionClose = false;

        this.Connected = true;

        this.httpClient = client;

    }
    public async Task<dynamic> Post(string uri, object body)
    {
        try
        {
            string url = ServiceLayerServer + uri;

            System.Net.Http.StringContent content = new System.Net.Http.StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            System.Net.Http.HttpResponseMessage response = httpClient.PostAsync(url, content).Result;

            string responseBody = response.Content.ReadAsStringAsync().Result;

            response.EnsureSuccessStatusCode();
            return responseBody;
        }
        catch (Exception err)
        {
         
            return null;
        }


    }

    public async Task<dynamic> Put(string uri, object body)
    {
        try
        {
            string url = ServiceLayerServer + uri;

            System.Net.Http.StringContent content = new System.Net.Http.StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            System.Net.Http.HttpResponseMessage response = httpClient.PutAsync(url, content).Result;

            string responseBody = response.Content.ReadAsStringAsync().Result;

            response.EnsureSuccessStatusCode();
            return responseBody;
        }
        catch (Exception err)
        {
            return null;
        }


    }

    public void Dispose()
    {
        if (httpClient != null)
        {
            httpClient.Dispose();
            httpClient = null;
        }
    }

}