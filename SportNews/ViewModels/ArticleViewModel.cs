using SimpleGraphGenerator.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportNews.Models;

namespace SportNews.ViewModels
{
    class ArticleViewModel : ViewModelBase
    {
        #region Constructor
        public ArticleViewModel(string articleId)
        {
            Loaded = new RelayCommand(LoadedHandler);
            this.articleId = articleId;
        }
        #endregion

        #region Pirvate Fields
        private string articleId;
        #endregion

        #region Properties
        // Commands
        public RelayCommand Loaded { get; private set; }

        // Actual properties
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (_title == value) return;

                _title = value;
                OnPropertyChanged();
            }
        }
  
        private string _body;
        public string Body
        {
            get => _body;
            set
            {
                if (_body == value) return;

                _body = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command Handlers
        private void LoadedHandler(object obj)
        {
            LoadTitleAndBody(articleId);
        }
        #endregion

        #region Private Methods

        private void LoadTitleAndBody(string Articleid)
        { 
            MongoCRUD db = new MongoCRUD("SportService_Database");
            var AllChannels = db.LoadRecords<ChanelMongoDatabesPatern>("channels");
            //Body = AllChannels[0].item.Where(x => x.guid == Articleid).Select(s => s.link).ToString();
            //Title = AllChannels[0].item.Where(x => x.guid == Articleid).Select(s => s.title).ToString();

           // Body = AllChannels[0].item.Where(x => x.guid == Articleid).Select(s => s.link).ToString();

            var items = AllChannels[0].item.Where(x => x.guid == Articleid);
           
            foreach (var item in items)
            {
                Body = item.link;
                Title = item.title;
            }

            //Body = AllChannels.Select(x => x.item.First(y => y.guid == Articleid)).Select(s => s.link).ToString();
            // Title = AllChannels.Select(x => x.item.First(y => y.guid == Articleid)).Select(s => s.title).ToString();
        }

        #endregion

    }
}
