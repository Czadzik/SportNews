using SimpleGraphGenerator.ViewModels.Utils;
using SportNews.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportNews.ViewModels
{
    class DashboardViewModel : ViewModelBase
    {
        #region Constructor
        public DashboardViewModel()
        {
            Pages = new Dictionary<string, UserControl>
            {
                {"wszystkie", new CategoryView("wszystkie") },
                {"pilkaNozna", new CategoryView("pilkaNozna") },
                {"siatkowka", new CategoryView("siatkowka") },
                {"sportWalki", new CategoryView("sportWalki") },
                {"pilkaReczna", new CategoryView("pilkaReczna") },
                {"moto", new CategoryView("moto") },
                {"tenis", new CategoryView("tenis") },
                {"koszykowka", new CategoryView("koszykowka") },
            };
            WszystkieButtonClicked = new RelayCommand(WszystkieButtonClickedHandler);
            PilkaNoznaButtonClicked = new RelayCommand(PilkaNoznaButtonClickedHandler);
            SiatkowkaButtonClicked = new RelayCommand(SiatkowkaButtonClickedHandler);
            SportWalkiButtonClicked = new RelayCommand(SportWalkiButtonClickedHandler);
            PilkaRecznaButtonClicked = new RelayCommand(PilkaRecznaButtonClickedHandler);
            MotoButtonClicked = new RelayCommand(MotoButtonClickedHandler);
            TenisButtonClicked = new RelayCommand(TenisButtonClickedHandler);
            KoszykowkaButtonClicked = new RelayCommand(KoszykowkaButtonClickedHandler);

            Loaded = new RelayCommand(LoadedHandler);
        }
        #endregion

        #region Properties
        //Commands
        public RelayCommand WszystkieButtonClicked { get; private set; }
        public RelayCommand PilkaNoznaButtonClicked { get; private set; }
        public RelayCommand SiatkowkaButtonClicked { get; private set; }
        public RelayCommand SportWalkiButtonClicked { get; private set; }
        public RelayCommand PilkaRecznaButtonClicked { get; private set; }
        public RelayCommand MotoButtonClicked { get; private set; }
        public RelayCommand TenisButtonClicked { get; private set; }
        public RelayCommand KoszykowkaButtonClicked { get; private set; }

        public RelayCommand Loaded { get; private set; }

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
            CurrentPage = Pages["wszystkie"];
            
        }
        private void PilkaNoznaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["pilkaNozna"];
            
        }
        private void SiatkowkaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["siatkowka"];
            
        }
        private void SportWalkiButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["sportyWalki"];
            
        }
        private void PilkaRecznaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["pilkaReczna"];
            
        }
        private void MotoButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["moto"];
            
        }
        private void TenisButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["tenis"];
            
        }

        private void KoszykowkaButtonClickedHandler(object obj)
        {
            CurrentPage = Pages["koszykowka"];
            
        }

        private void LoadedHandler(object obj)
        {
            
        
        }


        #endregion
    }

}
