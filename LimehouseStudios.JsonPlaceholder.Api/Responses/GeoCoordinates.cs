using Newtonsoft.Json;

namespace LimehouseStudios.JsonPlaceholder.Api.Responses
{
    internal class GeoCoordinates
    {
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        [JsonProperty("lng")]
        public decimal Longitude { get; set; }
    }
}
