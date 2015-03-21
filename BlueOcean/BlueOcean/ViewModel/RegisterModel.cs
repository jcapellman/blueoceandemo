using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using BlueOcean.Models;

namespace BlueOcean.ViewModel {
   public class RegisterModel : INotifyPropertyChanged {
        private bool _isLoading;

        public bool IsLoading {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }

        private string _username;

        public string Username {
            get { return _username; }

            set {
                _username = value; 
                OnPropertyChanged();
                btnRegisterEnabled = ValidForm;
            }
        }

        private string _password;

        public string Password {
            get { return _password; }

            set { 
                _password = value; 
                OnPropertyChanged();
                btnRegisterEnabled = ValidForm;
            }
        }

        private string _confirmPassword;

        public string ConfirmPassword {
            get { return _confirmPassword; }

            set {
                _confirmPassword = value;
                OnPropertyChanged();
                btnRegisterEnabled = ValidForm;
            }
        }

        private bool _btnRegisterEnabled;

        public bool btnRegisterEnabled {
            get { return _btnRegisterEnabled; }
            set { _btnRegisterEnabled = value; OnPropertyChanged(); }
        }

        public RegisterModel() {
            btnRegisterEnabled = false;
        }

        private bool ValidForm {
            get {
                return !String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password) &&
                       !String.IsNullOrWhiteSpace(ConfirmPassword) && (ConfirmPassword == Password);
            }
        }

        public async void AttemptRegister() {
            IsLoading = true;

            var userTable = App.client.GetTable<Users>();

            await userTable
                .InsertAsync(new Users {
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Username = Username,
                    Password = Password
                });

            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}