using Newtonsoft.Json;

namespace LimehouseStudios.JsonPlaceholder.Api.Responses
{
    internal class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catchphrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public string BusinessSector { get; set; }
    }
}
