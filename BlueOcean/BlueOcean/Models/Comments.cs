using System;

namespace BlueOcean.Models {
    public class Comments {
        public string id { get; set; }

        public DateTime publishdate { get; set; }

        public string body { get; set; }

        public string userid { get; set; }

        public string newsid { get; set; }
    }
}