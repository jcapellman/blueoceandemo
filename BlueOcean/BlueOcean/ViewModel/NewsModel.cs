using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using BlueOcean.Models;

namespace BlueOcean.ViewModel {
    public class NewsModel : INotifyPropertyChanged {
        private bool _isLoading;

        public bool IsLoading {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }

        private List<News> _news;

        public List<News> News {
            get { return _news; }

            set { 
                _news = value;
                OnPropertyChanged();
            }
        }

        public async void LoadData() {
            IsLoading = true;

            News = await App.client.GetTable<News>().OrderByDescending(a => a.PublishDate).ToListAsync();

            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}