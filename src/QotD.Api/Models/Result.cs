using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QotD.Api.Models
{
    public class Result
    {
        [JsonPropertyName("quote")]
        public string Quote { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
    }
}
