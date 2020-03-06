using SportNews.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportNews
{
    /// <summary>
    /// Logika interakcji dla klasy Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            DataContext = new DashboardViewModel();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonGoToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                //case 0:
                //    GridPrincipal.Children.Clear();
                //    GridPrincipal.Children.Add(new UserControl1());
                //    break;
                //case 1:
                //    GridPrincipal.Children.Clear();
                //    GridPrincipal.Children.Add(new UserControlInfo());
                //    break;
                //case 2:
                //    GridPrincipal.Children.Clear();
                //    GridPrincipal.Children.Add(new UserControlParzenieYerby());
                //    break;
                //case 3:
                //    GridPrincipal.Children.Clear();
                //    GridPrincipal.Children.Add(new UserControlNom());
                //    break;
                //case 4:
                //    GridPrincipal.Children.Clear();
                //    GridPrincipal.Children.Add(new UserControlSklep());
                //    break;


                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (-640 + (80 * index)), 0, 0);

        }

    }
}
