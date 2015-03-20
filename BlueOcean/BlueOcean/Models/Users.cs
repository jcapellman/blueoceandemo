using System;

namespace BlueOcean.Models {
    public class Users {
        public string id { get; set; }

        public DateTime Created { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime Modified { get; set; }
    }
}