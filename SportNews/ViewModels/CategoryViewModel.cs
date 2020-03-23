using SimpleGraphGenerator.ViewModels.Utils;
using SportNews.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportNews.Models;

namespace SportNews.ViewModels
{
    //Numery kanałów 0:Piłka Nożna 1:Siatkówka 2:Sporty Walki 3:Piłka Ręczna 4:Moto 5:Tenis 6:Koszykówka
    class CategoryViewModel : ViewModelBase
    {
        MongoCRUD db = new MongoCRUD("SportService_Database");
        #region Constructor
        public CategoryViewModel(int channelNumber)
        {
            var AllChanels= db.LoadRecords<ChanelMongoDatabesPatern>("channels");
            CategoryName = AllChanels[channelNumber].title;

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
        private void LoadNewsItems(int channelNumber)
        {
          
            var AllChannels = db.LoadRecords<ChanelMongoDatabesPatern>("channels");
           
                for (int j = 0; j < 50; j++)
                {
                    NewsItems.Add(new NewsItem(AllChannels[channelNumber].item[j].title, AllChannels[channelNumber].item[j].description,j.ToString()));
                }



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
