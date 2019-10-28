using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.dbClass
{
    public partial class ConnectionString
    {
        [JsonProperty("server")]
        public string Server { get; set; }

        [JsonProperty("port ")]
        public long Port { get; set; }

        [JsonProperty("database")]
        public string Database { get; set; }

        [JsonProperty("username ")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("charset")]
        public string Charset { get; set; }
    }
}
