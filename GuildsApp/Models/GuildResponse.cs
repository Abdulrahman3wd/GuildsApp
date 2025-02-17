using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GuildsApp.Models
{
    public class GuildResponse
    {
        [JsonPropertyName("yourGuild")]
        public List<Guild> YourGuild { get; set; }

        [JsonPropertyName("recommendedGuild")]
        public List<Guild> RecommendedGuild { get; set; }
    }

}
