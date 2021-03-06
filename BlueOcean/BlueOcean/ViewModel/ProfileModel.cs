﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using BlueOcean.Models;

namespace BlueOcean.ViewModel {
    public class ProfileModel : INotifyPropertyChanged {
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
                btnUpdateEnabled = ValidForm;
            }
        }

        private string _password;

        public string Password {
            get { return _password; }
            set { 
                _password = value; 
                OnPropertyChanged();
                btnUpdateEnabled = ValidForm;
            }
        }

        private bool _btnUpdateEnabled;

        public bool btnUpdateEnabled {
            get { return _btnUpdateEnabled; }
            set { _btnUpdateEnabled = value; OnPropertyChanged(); }
        }

        private bool ValidForm {
            get {
                return !String.IsNullOrWhiteSpace(Username) && !String.IsNullOrWhiteSpace(Password);
            }
        }

        public ProfileModel() {
            Username = App.CurrentUser.Username;
            Password = App.CurrentUser.Password;

            btnUpdateEnabled = true;
        }

        public async void UpdateProfile() {
            IsLoading = true;

            App.CurrentUser.Username = Username;
            App.CurrentUser.Password = Password;

            await App.client.GetTable<Users>().UpdateAsync(App.CurrentUser);

            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}