using System;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using YelpApiServer.Connection.Extensions;
using YelpApiServer.Core.Models;
using YelpApiServer.Services.IServices;

namespace YelpApiServer.Services.Services
{
	public class BaseRestService : IBaseRestService
	{
        private readonly ILogger<BaseRestService> _logger;
        
        private readonly HttpClient _client;
        private IMemoryCache _cache;

        public BaseRestService(ILogger<BaseRestService> logger, HttpClient client)
		{
            _logger = logger;
            _client = client;
            APIHeaders();
            _client.BaseAddress = new Uri(Constants.ApiServiceURL);
		}

        private void APIHeaders()
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Constants.ApiKey);
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json; charset=utf-8");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

        }

        public async Task<T> GetAsync<T>(string resource, int cacheDuration)
        {
            //get JSON data from cache or web
            var json = await GetJsonAsync(resource, cacheDuration);

            return JsonSerializer.Deserialize<T>(json);
        }


        private async Task<string> GetJsonAsync(string resource, int cacheDuration)
        {

            var cleanCacheKey = resource.CleanCacheKey();
            string json = string.Empty;

            //check if cache is enabled
            if(_cache is not null)
            {
                var cachedData = _cache.TryGetValue<string>(cleanCacheKey, out json);

                if (cacheDuration > 0 && !cachedData)
                    return json;
            }



            //get response from uri
            var url = _client.BaseAddress + resource;
            var response = await _client.GetAsync(url);

            //check for valid response
            if (response.IsSuccessStatusCode)
            {
                //read response
                json = await response.Content.ReadAsStringAsync();

                //save to cache
                if(cacheDuration > 0 && _cache is not null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                    
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheDuration))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);
                    _cache.Set(cleanCacheKey, json, cacheEntryOptions);
                }
            }
            else
            {
                json = string.Empty;   
            }

            //Save to Cache if required
            
            return json;
        }
    }
}

