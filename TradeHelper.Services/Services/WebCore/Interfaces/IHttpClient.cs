using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TradeHelper.Services.Services.WebCore.Interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string uri);

        Task<HttpResponseMessage> PostAsync(string uri, HttpContent content);

        Task<HttpResponseMessage> PutAsync(string uri, HttpContent content);

        Task<HttpResponseMessage> DeleteAsync(string uri);

        void Configure(TimeSpan? timeout = null, Dictionary<string, string> defaultHeaders = null);
    }
}
