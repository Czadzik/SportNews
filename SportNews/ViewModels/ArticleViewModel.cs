using SimpleGraphGenerator.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            LoadTitleAndBody();
        }
        #endregion

        #region Private Methods
        private void LoadTitleAndBody()
        {
            // TODO
        }
        #endregion

    }
}
