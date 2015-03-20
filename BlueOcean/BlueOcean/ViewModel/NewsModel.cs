using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlueOcean.ViewModel {
    public class NewsModel : INotifyPropertyChanged {
        private List<NewsResponseItem> _news;

        public List<NewsResponseItem> News {
            get { return _news; }

            set { 
                _news = value;
                OnPropertyChanged();
            }
        }

        public void LoadData() {
            var news = new List<NewsResponseItem>();

            news.Add(new NewsResponseItem { Header = "Blue Ocean...Coming to a School Near You", PostDate = new DateTime(2014, 12, 7).ToShortDateString(), Content = "It was a busy Saturday at the Maryland Blue Ocean Competition, stuffing mailings for 127 schools across the state.  See your principal, business teacher, or tech teacher this week for more information, or register now at BlueOceanComp.org!  A big thank you to Manzano Akhtar, Pranav Ganapathy, and the Benavides family for their help!" });

            news.Add(new NewsResponseItem { Header = "Registration Now Open", PostDate = new DateTime(2014, 11, 16).ToShortDateString(), Content = "Registration for the Blue Ocean Competition is now open! Sign up with up to 2 of your friends to present your original business idea, receive feedback from seasoned entrepreneurs, network, and compete for nearly $2000 in cash prizes!  Registration is limited to the first 100 teams, so register today! Check us out on: Youtube: Facebook: https://www.facebook.com/mdblueoceancomp Twitter: MDBlueOcean" });

            News = news;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}