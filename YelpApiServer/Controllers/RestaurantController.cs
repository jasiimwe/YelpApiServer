using Microsoft.AspNetCore.Mvc;
using YelpApiServer.Services.IServices;

namespace YelpApiServer.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantSearchService _searchService;
        public RestaurantController(IRestaurantSearchService searchService)
        {
            this._searchService = searchService;
        }

        [HttpGet]
        [Route("api/restaurants")]
        public async Task<IActionResult> showRestaurants(string location, string term = "")
        {
            await _searchService.SearchRestaurants(location,term);
            return Ok();
        }
    }
}
