using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlueOcean.ViewModel {
    public class ProfileModel : INotifyPropertyChanged {
        private string _username;

        public string Username {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;

        public string Password {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ProfileModel() {
            Username = "jcapellman";
            Password = "test";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
