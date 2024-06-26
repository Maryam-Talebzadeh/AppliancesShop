using Newtonsoft.Json;

namespace SiteQuery_EfCore.Models
{
   public class ChartQueryModel
    {
        [JsonProperty(PropertyName = "label")] public string Label { get; set; }

        [JsonProperty(PropertyName = "data")] public List<int> Data { get; set; }

        [JsonProperty(PropertyName = "backgroundColor")]
        public string[] BackgroundColor { get; set; }

        [JsonProperty(PropertyName = "borderColor")]
        public string BorderColor { get; set; }
    }
}
