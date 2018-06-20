using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TradeHelper.Services.Services.WebCore.Interfaces;

namespace TradeHelper.Services.Services.WebCore
{
    public class BaseHttpClient : IHttpClient
    {
        protected HttpClient HttpClient { get; }

        public BaseHttpClient()
        {
            HttpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(uri)
            };

            return await SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uri)
            };

            return await SendAsync(request);
        }

        public async Task<HttpResponseMessage> PostAsync(string uri, HttpContent content)
        {
            var request = new HttpRequestMessage
            {
                Content = content,
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri)
            };

            return await SendAsync(request);
        }

        public async Task<HttpResponseMessage> PutAsync(string uri, HttpContent content)
        {
            var request = new HttpRequestMessage
            {
                Content = content,
                Method = HttpMethod.Put,
                RequestUri = new Uri(uri)
            };

            return await SendAsync(request);
        }

        public void Configure(TimeSpan? timeout = null, Dictionary<string, string> defaultHeaders = null)
        {
            if (timeout != null)
            {
                HttpClient.Timeout = timeout.Value;
            }

            if (defaultHeaders != null)
            {
                HttpClient.DefaultRequestHeaders.Clear();
                foreach (KeyValuePair<string, string> header in defaultHeaders)
                {
                    HttpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        protected virtual async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            HttpResponseMessage responce = await HttpClient.SendAsync(request);
            return responce;
        }
    }
}