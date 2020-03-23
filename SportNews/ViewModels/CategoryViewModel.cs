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
            //db = new MongoCRUD("SportService_Database"); TODO wlaczyc
            ChannelNumber = channelNumber;


            //var AllChanels= db.LoadRecords<ChanelMongoDatabesPatern>("channels"); TODO wlaczyc

            ChannelName = "Nazwa kategorii";
            //ChannelName = AllChanels[channelNumber].title; TODO wlaczyc

            Loaded = new RelayCommand(LoadedHandler);
            

            //TEMPORARY
            NewsItems = new ObservableCollection<NewsItem>();
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            NewsItems.Add(new NewsItem("Przykładowy Tytuł", "Opis opis opis opis opis opis opis opis opis opis", "1"));
            

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
            //LoadNewsItems(); TODO start this

        }
        #endregion

        #region Private Methods
        private void LoadNewsItems()
        {
            var AllChannels = db.LoadRecords<ChanelMongoDatabesPatern>("channels");

            // TODO jesli channelNumber == -1
            // pobierz wszystkie artykuly z wszystkich kategorii
           
                for (int j = 0; j < 50; j++)
                {
                    NewsItems.Add(new NewsItem(AllChannels[ChannelNumber].item[j].title, AllChannels[ChannelNumber].item[j].description,j.ToString()));
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
