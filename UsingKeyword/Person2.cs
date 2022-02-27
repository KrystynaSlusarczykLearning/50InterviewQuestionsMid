using System.Text.Json.Serialization;

namespace DTOs
{
    internal class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set;  }
    }
}
