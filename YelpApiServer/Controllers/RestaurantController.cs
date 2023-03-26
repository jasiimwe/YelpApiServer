using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using YelpApiServer.Services.IServices;

namespace YelpApiServer.Controllers
{
    public class RestaurantController : Controller
    {
        private const string restaurantListCacheKey = "allRestaurants";
        
        private readonly IRestaurantSearchService _searchService;
        public RestaurantController(IRestaurantSearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        [Route("api/restaurants")]
        public async Task<IActionResult> showRestaurants(string location, string term = "")
        {
            
            var result = await _searchService.SearchRestaurantsAsync(location,term);
            
             return Ok(result);
           
            
        }

        [HttpGet]
        [Route("api/restaurants/{id}")]
        public async Task<IActionResult> getRestaurantById(string id)
        {
            var result = await _searchService.SearchRestaurantByIdAsync(id);
            return Ok(result);
        }
    }
}
