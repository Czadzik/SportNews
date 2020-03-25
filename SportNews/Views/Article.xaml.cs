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

namespace SportNews.Views
{
    /// <summary>
    /// Interaction logic for Article.xaml
    /// </summary>
    public partial class Article : Window
    {
        public Article(string articleId)
        {
            InitializeComponent();
            DataContext = new ArticleViewModel(articleId);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void ButtonCloseArticle_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
    }
}
