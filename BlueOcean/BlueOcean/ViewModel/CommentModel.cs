using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using BlueOcean.Models;

namespace BlueOcean.ViewModel {
    public class CommentModel: INotifyPropertyChanged {
        private bool _isLoading;

        public bool IsLoading {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(); }
        }

        private string _body;

        public string Body {
            get { return _body; }

            set {
                _body = value; 
                OnPropertyChanged();
                btnPostEnabled = ValidForm;
            }
        }

        private bool _btnPostEnabled;

        public bool btnPostEnabled {
            get { return _btnPostEnabled; }
            set { _btnPostEnabled = value; OnPropertyChanged(); }
        }

        public CommentModel() {
            btnPostEnabled = false;
        }

        private bool ValidForm {
            get {
                return !String.IsNullOrWhiteSpace(Body);
            }
        }

        private List<NewsComment> _comments;

        public List<NewsComment> Comments {
            get { return _comments; }
            set { _comments = value; OnPropertyChanged(); }
        } 

        public async void LoadComments() {
            IsLoading = true;

            var newsView = App.client.GetTable<NewsComment>();

            var tmpComments =
                await
                    newsView.ToListAsync();
            
            Comments = tmpComments.Where(a => a.id == App.SelectedNewsID).OrderByDescending(a => a.publishdate).ToList();

            IsLoading = false;
        }

       public async Task<bool> PostComment() {
           IsLoading = true;

            var commentTable = App.client.GetTable<Comments>();

            await commentTable
                .InsertAsync(new Comments {
                    body = Body,
                    publishdate = DateTime.Now,
                    userid = App.CurrentUser.id,
                    newsid = App.SelectedNewsID
                });

           var newsTable = App.client.GetTable<News>();

           var newsItems = await newsTable.Where(a => a.id == App.SelectedNewsID).ToListAsync();

           if (!newsItems.Any()) {
               return false;
           }

           var newsItem = newsItems.FirstOrDefault();

           if (newsItem == null) {
               return false;
           }
           
           newsItem.CommentCount++;

           await newsTable.UpdateAsync(newsItem);

           IsLoading = false;

           return true;
       }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}