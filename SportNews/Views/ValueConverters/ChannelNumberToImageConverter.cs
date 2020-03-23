using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SportNews.Views.ValueConverters
{
    class ChannelNumberToImageConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (targetType != typeof(ImageSource))
                    throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource.");

            string filePath = "pack://application:,,,/Resources/Images/all.jpg";

                switch(value)
                {
                case -1: // Wszystkie sporty
                    filePath = "pack://application:,,,/Resources/Images/all.jpg";
                    break;

                case 0: // Piłka nożna
                    filePath = "pack://application:,,,/Resources/Images/background_soccer.jpg";
                    break;

                case 1: // Siatkówka
                    filePath = "pack://application:,,,/Resources/Images/volleyball.jpg";
                    break;

                case 2: // Sporty Walki
                    filePath = "pack://application:,,,/Resources/Images/mma.jpg";
                    break;

                case 3: // Piłka reczna
                    filePath = "pack://application:,,,/Resources/Images/handball.jpg";
                    break;

                case 4: // Moto
                    filePath = "pack://application:,,,/Resources/Images/moto.jpg";
                    break;

                case 5: // Tenis
                    filePath = "pack://application:,,,/Resources/Images/tennis.jpg";
                    break;

                case 6: // Koszykowka
                    filePath = "pack://application:,,,/Resources/Images/basketball.jpg";
                    break;

                default: //wszystkie
                    filePath = "pack://application:,,,/Resources/Images/all.jpg";
                    break;
            }

                try
                {
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(filePath);
                    img.EndInit();
                    return img;
                }
                catch (Exception ex)
                {
                    return DependencyProperty.UnsetValue;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        

    }
}
