using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Shapes;

namespace alTSI
{
    public partial class MainWindow : Window
    {
        private decimal totalAmount = 0; // Сумма, введенная пользователем
        private decimal coffeePrice = 0; // Цена выбранного кофе
        private int sugarAmount = 2; // Начальное количество сахара (2 закрашенных)
        private const int maxSugar = 5; // Максимальное количество сахара

        public MainWindow()
        {
            InitializeComponent();
            UpdateSugarDisplay(); // Отображаем начальное количество сахара
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            if (sugarAmount < maxSugar)
            {
                sugarAmount++;
                UpdateSugarDisplay();
            }
            else
            {
                MessageBox.Show("Сахара максимальное количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            if (sugarAmount > 0)
            {
                sugarAmount--;
                UpdateSugarDisplay();
            }
            else
            {
                MessageBox.Show("Сахара минимальное количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateSugarDisplay()
        {
            for (int i = 0; i < 5; i++)
            {
                var rectangle = (Rectangle)SugarGrid.Children[i];
                rectangle.Fill = (i < sugarAmount) ? new SolidColorBrush(Color.FromRgb(40, 43, 41)) : new SolidColorBrush(Color.FromRgb(99, 102, 99));
            }
        }

        private void Button_Coffee30(object sender, RoutedEventArgs e)
        {
            coffeePrice = 30; // Установите цену для капучино
            WordPad.Text = $"Оплатить кофе?\n{coffeePrice}р"; // Переместим цену на новую строку
            WordPad.TextAlignment = TextAlignment.Center; // Установим выравнивание текста по центру
            ShowPaymentOptions();
        }

        private void Button_Coffee35(object sender, RoutedEventArgs e)
        {
            coffeePrice = 35; // Установите цену для капучино
            WordPad.Text = $"Оплатить кофе?\n{coffeePrice}р"; // Переместим цену на новую строку
            WordPad.TextAlignment = TextAlignment.Center; // Установим выравнивание текста по центру
            ShowPaymentOptions();
        }

        private void Button_Coffee45(object sender, RoutedEventArgs e)
        {
            coffeePrice = 45; // Установите цену для капучино
            WordPad.Text = $"Оплатить кофе?\n{coffeePrice}р"; // Переместим цену на новую строку
            WordPad.TextAlignment = TextAlignment.Center; // Установим выравнивание текста по центру
            ShowPaymentOptions();
        }

        private void Button_Coffee50(object sender, RoutedEventArgs e)
        {
            coffeePrice = 50; // Установите цену для капучино
            WordPad.Text = $"Оплатить кофе?\n{coffeePrice}р"; // Переместим цену на новую строку
            WordPad.TextAlignment = TextAlignment.Center; // Установим выравнивание текста по центру
            ShowPaymentOptions();
        }

        private void Button_Coffee55(object sender, RoutedEventArgs e)
        {
            coffeePrice = 55; // Установите цену для капучино
            WordPad.Text = $"Оплатить кофе?\n{coffeePrice}р"; // Переместим цену на новую строку
            WordPad.TextAlignment = TextAlignment.Center; // Установим выравнивание текста по центру
            ShowPaymentOptions();
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

        private void ShowPaymentOptions()
        {
            // Показываем окно для выбора способа оплаты (например, Wallet)
            Wallet walletWindow = new Wallet(coffeePrice);
            walletWindow.ShowDialog();
        }

        public async void ProcessPayment(bool isCardPayment, decimal change = 0)
        {
            if (isCardPayment)
            {
                WordPad.Text = "Подождите";
                CoffeeProgressBar.Visibility = Visibility.Visible;
                Cofe.Visibility = Visibility.Visible; // Делаем Cofe видимым
                await FillProgressBarAsync(10); // Задержка 10 секунд
                MessageBox.Show("Заберите ваш кофе");
            }
            else
            {
                WordPad.Text = "Подождите";
                CoffeeProgressBar.Visibility = Visibility.Visible;
                Cofe.Visibility = Visibility.Visible; // Делаем Cofe видимым
                await FillProgressBarAsync(5); // Задержка 5 секунд
                string message = change > 0 ? $"Забрать сдачу {change}р" : "Заберите ваш кофе";
                MessageBox.Show(message);
                MessageBox.Show("Заберите ваш кофе");
            }

            WordPad.Text = "Приятного аппетита!";
            await Task.Delay(10000); // Задержка 10 секунд
            WordPad.Text = "Выберите напиток";
            CoffeeProgressBar.Visibility = Visibility.Hidden;
            Cofe.Visibility = Visibility.Hidden; // Скрываем Cofe
        }

        private async Task FillProgressBarAsync(int seconds)
        {
            CoffeeProgressBar.Visibility = Visibility.Visible;
            Cofe.Visibility = Visibility.Visible; // Делаем Cofe видимым
            CoffeeProgressBar.Value = 0;

            for (int i = 0; i < seconds; i++)
            {
                await Task.Delay(1000); // Задержка 1 секунда
                CoffeeProgressBar.Value += (100.0 / seconds); // Увеличение значения на равные доли
            }

            CoffeeProgressBar.Visibility = Visibility.Hidden;
            Cofe.Visibility = Visibility.Hidden; // Скрываем Cofe
        }
    }
}
