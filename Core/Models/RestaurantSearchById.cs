using System;
using System.Text.Json.Serialization;

namespace YelpApiServer.Core.Models
{

    
    public class ItemCategory
    {
        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class Coordinates
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }

    public class Hour
    {
        [JsonPropertyName("open")]
        public List<Open> Open { get; set; }

        [JsonPropertyName("hours_type")]
        public string HoursType { get; set; }

        [JsonPropertyName("is_open_now")]
        public bool IsOpenNow { get; set; }
    }

    public class ItemLocation
    {
        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("address3")]
        public string Address3 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("display_address")]
        public List<string> DisplayAddress { get; set; }

        [JsonPropertyName("cross_streets")]
        public string CrossStreets { get; set; }
    }

    public class Open
    {
        [JsonPropertyName("is_overnight")]
        public bool IsOvernight { get; set; }

        [JsonPropertyName("start")]
        public string Start { get; set; }

        [JsonPropertyName("end")]
        public string End { get; set; }

        [JsonPropertyName("day")]
        public int Day { get; set; }
    }

    public class RestaurantSearchById
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("is_claimed")]
        public bool IsClaimed { get; set; }

        [JsonPropertyName("is_closed")]
        public bool IsClosed { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("display_phone")]
        public string DisplayPhone { get; set; }

        [JsonPropertyName("review_count")]
        public int ReviewCount { get; set; }

        [JsonPropertyName("categories")]
        public List<ItemCategory> Categories { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("photos")]
        public List<string> Photos { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("hours")]
        public List<Hour> Hours { get; set; }

        [JsonPropertyName("transactions")]
        public List<string> Transactions { get; set; }
    }



}

