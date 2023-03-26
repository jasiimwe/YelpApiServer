using MonkeyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using YelpApiServer.Connection.Extensions;

namespace YelpApiServer.Connection.Service
{
    public class BaseRestService
    {


        private HttpClient _client;
        //private IBarrel _cacheBarrel;


        public BaseRestService()
        {
            //this._cacheBarrel = cacheBarrel;
        }

        protected void SetBaseURL(string apiBaseUrl)
        {
            _client = new()
            {
                BaseAddress = new Uri(apiBaseUrl)
            };

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        protected void AddHttpHeader(string key, string value) =>
            _client.DefaultRequestHeaders.Add(key, value);


        protected async Task<T> GetAsync<T>(string resource, int cacheDuration = 24)
        {
            //get JSON data from cache or web
            var json = await GetJsonAsync(resource, cacheDuration = 24);

            return JsonSerializer.Deserialize<T>(json);
        }


        private async Task<string> GetJsonAsync(string resource, int cacheDuration = 24)
        {

            var cleanCacheKey = resource.CleanCacheKey();
            string json = string.Empty;


            //check cache if enabled
            /*
            if (_cacheBarrel is not null)
            {
                //Get data from cache
                var cacheData = _cacheBarrel.Get<string>(cleanCacheKey);

                if (cacheDuration > 0 && cacheData is not null && !_cacheBarrel.IsExpired(cleanCacheKey))
                    return cacheData;

                //check connection to yelp server, if not on, return cache data



            }
            */

            //no cache, or not required and server is available

            //get response from uri
            var response = await _client.GetAsync(new Uri(_client.BaseAddress, resource));

            //check for valid response
            if (response.IsSuccessStatusCode)
            {
                //read response
                json = await response.Content.ReadAsStringAsync();
            };

            

            //Save to Cache if required
            /*
            if (cacheDuration > 0 && _cacheBarrel is not null)
            {
                try
                {
                    _cacheBarrel.Add(cleanCacheKey, json, TimeSpan.FromHours(cacheDuration));
                }
                catch
                { }
            }
            */
            return json;
        }
    


    }
}
