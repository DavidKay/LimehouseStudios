using Newtonsoft.Json;

namespace LimehouseStudios.JsonPlaceholder.Api.Responses
{
    internal class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }
}
