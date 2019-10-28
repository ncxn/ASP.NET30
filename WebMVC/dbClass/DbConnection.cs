using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.dbClass
{
    public partial class DbConnection
    {
        [JsonProperty("ConnectionString")]
        public ConnectionString ConnectionString { get; set; }

        [JsonProperty("ProviderName")]
        public string ProviderName { get; set; }
    }
}
