// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

public class RootObject
{
    [JsonProperty("id")]
    public Guid id { get; set; }
    [JsonProperty("child_node_ids")]
    public Guid[] child_node_ids { get; set; }  
    
    
}