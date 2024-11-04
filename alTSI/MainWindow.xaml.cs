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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace alTSI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Espresso(object sender, RoutedEventArgs e)
        {
            var w = new Wallet();
            w.Show();
        }
        private void Button_Plus(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Minus(object sender, RoutedEventArgs e)
        {

        }

        private void OnImageClick(object sender, RoutedEventArgs e)
        {
            // Создаем новое окно для показа увеличенного изображения
            Window imageWindow = new Window
            {
                Title = "Правила пользования",
                Width = 400,
                Height = 600,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#453f36")),
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = new Image
                {
                    Source = new BitmapImage(new Uri("D:/4 курс/ТСИ/img/Instr.png")),
                    Stretch = Stretch.Uniform
                }
            };

            imageWindow.ShowDialog(); // Открываем окно
        }


    }
}
