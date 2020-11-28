using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GifsXamarin.Models
{
    public partial class Movies
    {
        [JsonProperty("No")]
        public string No { get; set; }
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Link")]
        public string Link { get; set; }
        [JsonProperty("Episode")]
        public string Episode { get; set; }
    }

    public static class Serialize 
    {
        public static string TJson(this Movies[] selft) => JsonConvert.SerializeObject(selft, Converter.Settings);
    }

    public partial class Movies 
    {
        public static Movies[] FromJson(string json) => JsonConvert.DeserializeObject<Movies[]>(json, Converter.Settings);
    }

    internal static class Converter 
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal } },
        };
    }
 
}
