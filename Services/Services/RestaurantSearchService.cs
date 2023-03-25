using MonkeyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YelpApiServer.Connection.Service;
using YelpApiServer.Core.Models;
using YelpApiServer.Services.IServices;

namespace YelpApiServer.Services.Services
{
    public class RestaurantSearchService : BaseRestService, IRestaurantSearchService
    {
        public RestaurantSearchService(IBarrel caheBarrel) : base(caheBarrel)
        {
            SetBaseURL(Constants.ApiServiceURL);
        }
        public async Task<RestaurantSearch> SearchRestaurants(string location, string term)
        {
            var resourceUri = $"businesses/search?location={WebUtility.UrlEncode(location)}&term={WebUtility.UrlEncode(term)}";

            AddHttpHeader("Authorization", "Bearer " + Constants.ApiKey);

            var result = await GetAsync<RestaurantSearch>(resourceUri, 5);

            return result;
        }
    }
}
