using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using BlueOcean.Models;

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

        public async Task<bool> AttemptLogin() {
            var result = await App.client.GetTable<Users>()
                    .Where(a => a.Username == Username && a.Password == Password).ToListAsync();

            App.CurrentUser = result.FirstOrDefault();

            return result.Any();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}