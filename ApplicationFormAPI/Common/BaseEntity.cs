using System.Text.Json.Serialization;

namespace ApplicationFormAPI.Common
{
    public abstract class BaseEntity<T> 
    {
        [JsonPropertyName("id")]
        public T Id { get; set; }

        [JsonPropertyName("partitionKey")]
        public string PartitionKey { get; set; }
        public DateTime? LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
