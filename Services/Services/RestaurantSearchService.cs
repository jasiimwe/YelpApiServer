using Microsoft.Extensions.Logging;
using MonkeyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using YelpApiServer.Connection.Service;
using YelpApiServer.Core.Models;
using YelpApiServer.Services.IServices;

namespace YelpApiServer.Services.Services
{
    public class RestaurantSearchService : BaseRestService, IRestaurantSearchService
    {
        public RestaurantSearchService(ILogger<RestaurantSearchService> logger, HttpClient client) :base(logger, client)
        {
            
        }

        public async Task<ApiResponse<RestaurantSearchById>> SearchRestaurantByIdAsync(string Id)
        {
            //check param
            if (string.IsNullOrEmpty(Id))
                return new ApiResponse<RestaurantSearchById>("please enter Id");
            else
            {
                try
                {
                    var resourceUri = $"/businesses/{WebUtility.UrlEncode(Id)}";

                    var result = await GetAsync<RestaurantSearchById>(resourceUri, Constants.CacheDuration);

                    return new ApiResponse<RestaurantSearchById>(result, "");
                }catch(Exception ex)
                {
                    return new ApiResponse<RestaurantSearchById>("Resource unavailable, please check in later");
                }
            }
        }


        public async Task<ApiResponse<RestaurantSearch>> SearchRestaurantsAsync(string location, string term)
        {
            //check params
            if(string.IsNullOrEmpty(location) && string.IsNullOrEmpty(term))
                return new ApiResponse<RestaurantSearch>("please enter location and search term");

            else
            {
                try
                {
                    var resourceUri = $"/businesses/search?location={WebUtility.UrlEncode(location)}&term={WebUtility.UrlEncode(term)}";

                    var result = await GetAsync<RestaurantSearch>(resourceUri, Constants.CacheDuration);

                    return new ApiResponse<RestaurantSearch>(result,"");
                }catch(Exception ex)
                {
                    return new ApiResponse<RestaurantSearch>("Resource unavailable, please check in later");
                }
                
            }
            

            
        }
    }
}
