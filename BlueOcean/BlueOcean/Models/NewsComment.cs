using System;

namespace BlueOcean.Models {
    public class NewsComment {
        public string id { get; set; }

        public DateTime publishdate { get; set; }

        public string body { get; set; }

        public string username { get; set; }
    }
}