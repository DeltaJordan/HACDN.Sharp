using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace HACDN.Objects
{
    public partial class SwitchbrewPage
    {
        [JsonProperty("parse")]
        public Parse Parse { get; set; }
    }

    public class Parse
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pageid")]
        public long Pageid { get; set; }

        [JsonProperty("revid")]
        public long Revid { get; set; }

        [JsonProperty("text")]
        public Text Text { get; set; }

        [JsonProperty("langlinks")]
        public object[] Langlinks { get; set; }

        [JsonProperty("categories")]
        public object[] Categories { get; set; }

        [JsonProperty("links")]
        public Link[] Links { get; set; }

        [JsonProperty("templates")]
        public object[] Templates { get; set; }

        [JsonProperty("images")]
        public object[] Images { get; set; }

        [JsonProperty("externallinks")]
        public object[] Externallinks { get; set; }

        [JsonProperty("sections")]
        public Section[] Sections { get; set; }

        [JsonProperty("parsewarnings")]
        public object[] Parsewarnings { get; set; }

        [JsonProperty("displaytitle")]
        public string Displaytitle { get; set; }

        [JsonProperty("iwlinks")]
        public object[] Iwlinks { get; set; }

        [JsonProperty("properties")]
        public object[] Properties { get; set; }
    }

    public class Link
    {
        [JsonProperty("ns")]
        public long Ns { get; set; }

        [JsonProperty("exists")]
        public string Exists { get; set; }

        [JsonProperty("*")]
        public string Empty { get; set; }
    }

    public class Section
    {
        [JsonProperty("toclevel")]
        public long Toclevel { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("fromtitle")]
        public string Fromtitle { get; set; }

        [JsonProperty("byteoffset")]
        public long Byteoffset { get; set; }

        [JsonProperty("anchor")]
        public string Anchor { get; set; }
    }

    public class Text
    {
        [JsonProperty("*")]
        public string Empty { get; set; }
    }

    public partial class SwitchbrewPage
    {
        public static SwitchbrewPage FromJson(string json) => JsonConvert.DeserializeObject<SwitchbrewPage>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SwitchbrewPage self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}