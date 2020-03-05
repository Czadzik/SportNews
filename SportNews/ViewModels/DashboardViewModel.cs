using SimpleGraphGenerator.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNews.ViewModels
{
    class DashboardViewModel : ViewModelBase
    {
        #region Constructor
        public DashboardViewModel()
        {
            Pages = new Dictionary<string, UserControl>
            {
                {"Wszystkie", new HomeStep1(this) },
                {"PilkaNozna", new HomeStep1(this) },
                {"Siatkowka", new HomeStep1(this) },
                {"SportWalki", new HomeStep1(this) },
                {"PilkaReczna", new HomeStep1(this) },
                {"Moto", new HomeStep1(this) },
                {"Tenis", new HomeStep1(this) },
                {"Koszykowka", new HomeStep2(this) },
            };
            WszystkieButtonClicked = new RelayCommand<object>(WszystkieButtonClickedHandler);
            PilkaNoznaButtonClicked = new RelayCommand<object>(PilkaNoznaButtonClickedHandler);
            SiatkowkaButtonClicked = new RelayCommand<object>(SiatkowkaButtonClickedHandler);
            SportWalkiButtonClicked = new RelayCommand<object>(SportWalkiButtonClickedHandler);
            PilkaRecznaButtonClicked = new RelayCommand<object>(PilkaRecznaButtonClickedHandler);
            MotoButtonClicked = new RelayCommand<object>(MotoButtonClickedHandler);
            TenisButtonClicked = new RelayCommand<object>(TenisButtonClickedHandler);
            KoszykowkaButtonClicked = new RelayCommand<object>(KoszykowkaButtonClickedHandler);

            Loaded = new RelayCommand<object>(LoadedHandler);
        }
        #endregion

        #region Properties
        //Commands
        public RelayCommand<object> WszystkieButtonClicked { get; set; }
        public RelayCommand<object> PilkaNoznaButtonClicked { get; set; }
        public RelayCommand<object> SiatkowkaButtonClicked { get; set; }
        public RelayCommand<object> SportWalkiButtonClicked { get; set; }
        public RelayCommand<object> PilkaRecznaButtonClicked { get; set; }
        public RelayCommand<object> MotoButtonClicked { get; set; }
        public RelayCommand<object> TenisButtonClicked { get; set; }
        public RelayCommand<object> KoszykowkaButtonClicked { get; set; }
        
        public RelayCommand<object> Loaded { get; set; }

        //Actual properties
        public Dictionary<string, UserControl> Pages { get; }

        private UserControl _currentPage;
        public UserControl CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage == value)
                    return;

                _currentPage = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command Handlers
        private void WszystkieButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }
        private void PilkaNoznaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }
        private void SiatkowkaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }
        private void SportWalkiButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }
        private void PilkaRecznaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }
        private void MotoButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }
        private void TenisButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }

        private void KoszykowkaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }

        private void LoadedHandler(object obj)
        {
            CurrentPage = Pages["HomeStep1"];
            IsHomeButtonActive = true;
        }


        #endregion
    }

}
