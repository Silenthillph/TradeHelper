using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TradeHelper.Services.Helpers;
using TradeHelper.Services.Services.WebCore.Interfaces;

namespace TradeHelper.Services.Extensions
{
    public static class HttpClientExtensions
    {
        #region Actions
        public static async Task<T> DeleteAsJsonAsync<T>(this IHttpClient httpClient, string uri)
        {
            T result;
            using (HttpResponseMessage responce = await httpClient.DeleteAsync(uri))
            {
                using (HttpContent content = responce.Content)
                {
                    result = await ReadAsJsonAsync<T>(responce.Content);
                }
            }
            return result;
        }

        public static async Task<T> GetAsJsonAsync<T>(this IHttpClient httpClient, string uri)
        {
            T result;
            using (HttpResponseMessage responce = await httpClient.GetAsync(uri))
            {
                using (HttpContent content = responce.Content)
                {
                    result = await ReadAsJsonAsync<T>(responce.Content);
                }
            }
            return result;
        }

        public static async Task<TResult> PostAsJsonAsync<TResult>(this IHttpClient httpClient, string uri, object value)
        {
            TResult result;
            using (HttpContent content = CreateJsonContent(value))
            {
                using (HttpResponseMessage response = await httpClient.PostAsync(uri, content))
                {
                    result = await ReadAsJsonAsync<TResult>(response.Content);
                }
            }
            return result;
        }

        public static Task PostAsJsonAsync(this IHttpClient httpClient, string uri, object value)
        {
            return httpClient.PostAsJsonAsync<object>(uri, value);
        }

        public static async Task<TResult> PutAsJsonAsync<TResult>(this IHttpClient httpClient, string uri, object value)
        {
            TResult result;
            using (HttpContent content = CreateJsonContent(value))
            {
                using (HttpResponseMessage response = await httpClient.PutAsync(uri, content))
                {
                    result = await ReadAsJsonAsync<TResult>(response.Content);
                }
            }
            return result;
        }

        public static Task PutAsJsonAsync(this IHttpClient httpClient, string uri, object value)
        {
            return httpClient.PutAsJsonAsync<object>(uri, value);
        }

        public static async Task<T> GetContentAs<T>(this HttpResponseMessage responseMessage)
        {
            return await ReadAsJsonAsync<T>(responseMessage.Content);
        }

        #endregion

        #region Utilities
        private static async Task<T> ReadAsJsonAsync<T>(HttpContent content)
        {
            string dataAsString = await content.ReadAsStringAsync();
            return JsonHelper.DeserializeObject<T>(dataAsString);
        }

        private static HttpContent CreateJsonContent(object value)
        {
            string dataAsString = JsonHelper.SerializeObject(value);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
        #endregion
    }
}