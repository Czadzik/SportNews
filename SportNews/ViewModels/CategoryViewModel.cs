using SimpleGraphGenerator.ViewModels.Utils;
using SportNews.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNews.ViewModels
{
    class CategoryViewModel : ViewModelBase
    {
        #region Constructor
        public CategoryViewModel(string categoryName)
        {
            CategoryName = categoryName;

            Loaded = new RelayCommand(LoadedHandler);
            ReadMoreButtonClicked = new RelayCommand(ReadMoreButtonClickedHandler);
        }
        #endregion

        #region Properties
        // Commands
        public RelayCommand Loaded { get; private set; }
        public RelayCommand ReadMoreButtonClicked { get; private set; }


        // Actual Properties     
        private ObservableCollection<NewsItem> _newsItems;
        public ObservableCollection<NewsItem> NewsItems
        {
            get => _newsItems;

            set
            {
                if (_newsItems == value) return;

                _newsItems = value;
                OnPropertyChanged();
            }
        }
        public string CategoryName { get; }
        #endregion

        #region Command Handlers
        private void LoadedHandler(object obj)
        {
            LoadNewsItems();
        }

        private void ReadMoreButtonClickedHandler(object paramsArray)
        {
            // Pobierz articleId, przekazane w bindingu w xaml
            var values = (object[])paramsArray;
            string articleId = (string)values[0];

            // Stworz nowe okno z artykułem
            var article = new Article(articleId);
        }

        #endregion

        #region Private Methods
        private void LoadNewsItems()
        {
            // TODO Wypelnij liste NewsItemow
            // w petli
            //NewsItems.Add(new NewsItem())

        }
        #endregion

    }

    /// <summary>
    /// Immutable
    /// </summary>
    class NewsItem 
    {
        public NewsItem(string title, string description, string articleId)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            ArticleId = articleId ?? throw new ArgumentNullException(nameof(articleId));
        }

        public string Title { get; }

        public string Description { get; }

        public string ArticleId { get; }
    }

}
