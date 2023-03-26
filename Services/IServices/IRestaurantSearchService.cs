using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YelpApiServer.Core.Models;

namespace YelpApiServer.Services.IServices
{
    public interface IRestaurantSearchService
    {
        Task<ApiResponse<RestaurantSearch>> SearchRestaurantsAsync(string location, string term);

        Task<ApiResponse<RestaurantSearchById>> SearchRestaurantByIdAsync(string Id);
    }
}
