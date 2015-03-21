using System;

namespace BlueOcean.Models {
    public class News {
        public string id { get; set; }

        public DateTime PublishDate { get; set; }

        public int CommentCount { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}