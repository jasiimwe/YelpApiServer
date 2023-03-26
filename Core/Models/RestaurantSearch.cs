using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YelpApiServer.Core.Models
{

    public class RestaurantSearch
    {
        [JsonPropertyName("businesses")]
        public List<Business> businesses { get; set; }
    }


    public class Business
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
        

        [JsonPropertyName("review_count")]
        public int ReviewCount { get; set; }

        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }
       

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }
    }

    public class Category
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    
    public class Location
    {
        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }

    }
    
}
