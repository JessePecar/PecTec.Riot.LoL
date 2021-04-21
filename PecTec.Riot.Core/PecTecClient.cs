using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PecTec.Riot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PecTec.Riot.Core
{
    public class PecTecClient : IPecTecClient
    {
        private readonly IServiceScopeFactory _factory;
        private readonly IHttpClientFactory _clientFactory;
        public PecTecClient(IHttpClientFactory clientFactory, IServiceScopeFactory factory) 
        {
            _factory = factory;
            _clientFactory = clientFactory;
        }

        private HttpResponseMessage SendRequestForResponse(HttpRequestMessage request)
        {
            // Setup the default client options here
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = client.SendAsync(request).Result;
            return response;
        }

        private HttpRequestMessage CreateRequestMessage(HttpMethod method, string requestUrl, object postContent = null)
        {
            HttpRequestMessage message = new HttpRequestMessage()
            {
                RequestUri = new Uri(requestUrl),
                Method = method
            };

            if (method != HttpMethod.Get && postContent != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(postContent));
            }

            using (IServiceScope scope = _factory.CreateScope())
            {
                PecTecClientOptions options = scope.ServiceProvider.GetRequiredService<PecTecClientOptions>();
                message.Headers.Add(options.RiotTokenStringHeader, options.RiotTokenString);
            }

            return message;
        }

        private T GetItemFromResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string resultContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(resultContent);
            }
            return default;
        }

        private List<T> GetListFromResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string resultContent = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(resultContent);
            }
            return default;
        }

        public T PostRequestForItem<T>(string requestUrl, T postObject)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Post, requestUrl, postObject);
            HttpResponseMessage response = SendRequestForResponse(request);

            return GetItemFromResponse<T>(response);
        }

        public List<T> PostRequestForList<T>(string requestUrl, T postObject)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Post, requestUrl, postObject);
            HttpResponseMessage response = SendRequestForResponse(request);

            return GetListFromResponse<T>(response);
        }

        public T GetRequestForItem<T>(string requestUrl)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Get, requestUrl);
            HttpResponseMessage response = SendRequestForResponse(request);

            return GetItemFromResponse<T>(response);
        }

        public List<T> GetRequestForList<T>(string requestUrl)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Get, requestUrl);
            HttpResponseMessage response = SendRequestForResponse(request);

            return GetListFromResponse<T>(response);
        }
    }
}
