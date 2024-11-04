using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace alTSI
{
    public partial class Wallet : Window
    {
        private decimal totalAmount = 0; // Сумма, введенная пользователем
        private decimal coffeePrice; // Цена выбранного кофе

        public Wallet(decimal price)
        {
            InitializeComponent();
            coffeePrice = price; // Получаем цену кофе при инициализации
            TotalAmountText.Text = $"Итого: {totalAmount}р"; // Инициализируем текст с итоговой суммой
        }

        // Обработчик для клика по картам
        private void Card_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ProcessPayment(true); // Оплата картой
            this.Close();
        }

        // Обработчик для клика по монетам и купюрам
        private void Coin_Click(object sender, MouseButtonEventArgs e)
        {
            string imageSource = ((Image)sender).Source.ToString();

            // Добавляем стоимость в зависимости от монеты
            if (imageSource.Contains("M1.png")) totalAmount += 1;
            else if (imageSource.Contains("M2.png")) totalAmount += 2;
            else if (imageSource.Contains("M5.png")) totalAmount += 5;
            else if (imageSource.Contains("M10.png")) totalAmount += 10;
            else if (imageSource.Contains("B10.png")) totalAmount += 10;
            else if (imageSource.Contains("B50.png")) totalAmount += 50;
            else if (imageSource.Contains("B100.png")) totalAmount += 100;

            // Обновляем текст с итоговой суммой
            TotalAmountText.Text = $"Итого: {totalAmount}р";
            ((Image)sender).Visibility = Visibility.Hidden; // Скрываем использованную монету/купюру
            PayButton.IsEnabled = true; // Активируем кнопку "Заплатить"
        }

        // Обработчик для нажатия кнопки "Заплатить"
        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

            if (totalAmount < coffeePrice)
            {
                MessageBox.Show("Денег не хватает. Добавьте еще или оплатите картой");
            }
            else
            {
                mainWindow.ProcessPayment(false, totalAmount - coffeePrice); // Оплата наличными
                this.Close();
            }
        }
    }
}
