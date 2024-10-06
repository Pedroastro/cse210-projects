using System.Text.Json.Serialization;

public class Field
{
    [JsonPropertyName("field")]
    public List<object> field { get; set; }
}