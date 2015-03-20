using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlueOcean.ViewModel {
    public class LoginModel : INotifyPropertyChanged {
        private string _username;

        public string Username {
            get { return _username; }

            set {
                _username = value; 
                OnPropertyChanged(); 
                btnLoginEnabled = ValidForm;
            }
        }

        private string _password;

        public string Password {
            get { return _password; }

            set { 
                _password = value; 
                OnPropertyChanged();
                btnLoginEnabled = ValidForm;
            }
        }

        private bool _btnLoginEnabled;

        public bool btnLoginEnabled {
            get { return _btnLoginEnabled; }
            set { _btnLoginEnabled = value; OnPropertyChanged(); }
        }

        public LoginModel() {
            btnLoginEnabled = false;
        }

        private bool ValidForm {
            get { return !String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password); }
        }

        public void AttemptLogin() {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}