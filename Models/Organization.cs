using System.Text.Json.Serialization;

namespace WebAPIClient.Models
{
    public class Organization
    {
        [JsonPropertyName("company")]
        public string company { get; set; }
    }
}