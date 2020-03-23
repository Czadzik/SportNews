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
    //Numery kanałów -1:Wszystkie 0:Piłka Nożna 1:Siatkówka 2:Sporty Walki 3:Piłka Ręczna 4:Moto 5:Tenis 6:Koszykówka
    class CategoryViewModel : ViewModelBase
    {
        #region Constructor
        public CategoryViewModel(int channelNumber)
        {
            db = new MongoCRUD("SportService_Database");
            ChannelNumber = channelNumber;
            ChannelName = SetChannelName(channelNumber);

            Loaded = new RelayCommand(LoadedHandler);
            NewsItems = new ObservableCollection<NewsItem>();    
        }
        #endregion

        #region Private Fields
        MongoCRUD db;
        #endregion

        #region Properties
        // Commands
        public RelayCommand Loaded { get; private set; }
        

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

        private string _channelName;
        public string ChannelName
        {
            get => _channelName;
            set
            {
                if (_channelName == value) return;
                _channelName = value;
                OnPropertyChanged();
            }
        }

        private int _channelNumber;
        public int ChannelNumber
        {
            get => _channelNumber;
            set
            {
                if (_channelNumber == value) return;
                _channelNumber = value;
                OnPropertyChanged();

            }
        }

        #endregion

        #region Command Handlers
        private void LoadedHandler(object obj)
        {
            LoadNewsItems();
        }
        #endregion

        #region Private Methods
        private void LoadNewsItems()
        {
            var allChannels = db.LoadRecords<ChanelMongoDatabesPatern>("channels");

            if (ChannelNumber == -1)
            {
                for (int j = 0; j < 10; j++)
                {
                    NewsItems.Add(new NewsItem(allChannels[0].item[j].title, allChannels[0].item[j].description, allChannels[0].item[j].guid));
                    NewsItems.Add(new NewsItem(allChannels[1].item[j].title, allChannels[1].item[j].description, allChannels[1].item[j].guid));
                    NewsItems.Add(new NewsItem(allChannels[2].item[j].title, allChannels[2].item[j].description, allChannels[2].item[j].guid));
                    NewsItems.Add(new NewsItem(allChannels[3].item[j].title, allChannels[3].item[j].description, allChannels[3].item[j].guid));
                    NewsItems.Add(new NewsItem(allChannels[4].item[j].title, allChannels[4].item[j].description, allChannels[4].item[j].guid));
                    NewsItems.Add(new NewsItem(allChannels[5].item[j].title, allChannels[5].item[j].description, allChannels[5].item[j].guid));
                    NewsItems.Add(new NewsItem(allChannels[6].item[j].title, allChannels[6].item[j].description, allChannels[6].item[j].guid));
                }
            }
            else
            {
                for (int j = 0; j < 50; j++)
                {
                    NewsItems.Add(new NewsItem(allChannels[ChannelNumber].item[j].title, allChannels[ChannelNumber].item[j].description, allChannels[ChannelNumber].item[j].guid));
                }
            }
        }

        private string SetChannelName(int id)
        {
            //Numery kanałów -1:Wszystkie 0:Piłka Nożna 1:Siatkówka 2:Sporty Walki 3:Piłka Ręczna 4:Moto 5:Tenis 6:Koszykówka
            switch (id)
            {
                case -1:
                    return "Wszystkie";
                    break;

                case 0:
                    return "Piłka Nożna";
                    break;

                case 1:
                    return "Siatkówka";
                    break;

                case 2:
                    return "Sporty Walki";
                    break;

                case 3:
                    return "Piłka Ręczna";
                    break;

                case 4:
                    return "Moto";
                    break;

                case 5:
                    return "Tenis";
                    break;

                case 6:
                    return "Koszykówka";
                    break;

                default:
                    return "Wszystkie";
                    break;

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

            ReadMoreButtonClicked = new RelayCommand(ReadMoreButtonClickedHandler);
        }

        public string Title { get; }

        public string Description { get; }

        public string ArticleId { get; }

        public RelayCommand ReadMoreButtonClicked { get; private set; }

        private void ReadMoreButtonClickedHandler(object param)
        {
            var article = new Article(ArticleId);
            article.Show();
        }
    }

}
