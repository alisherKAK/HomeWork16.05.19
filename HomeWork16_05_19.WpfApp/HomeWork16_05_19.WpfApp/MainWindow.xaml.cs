using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Newtonsoft.Json;
using HomeWork16_05_19.Models;

namespace HomeWork16_05_19.WpfApp
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

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cityNameTextBox.Text))
                {
                    MessageBox.Show("Введите город");
                    return;
                }

                string result;
                using (var client = new WebClient())
                {
                    result = client.DownloadString($"http://api.apixu.com/v1/forecast.json?key=59bacc56d0fc4e55bdb144248190605&q={cityNameTextBox.Text}&days=7");
                }

                var forecast = JsonConvert.DeserializeObject<CityDescription>(result).Forecast;
                var cards = cardsGrid.Children.OfType<Card>().ToList();

                for (int i = 0; i < cards.Count; i++)
                {
                    DateTime forecastDay = Convert.ToDateTime(forecast.Forecastday[i].Date);
                    var stackPanel = cards[i].Content as StackPanel;
                    var textBlocks = stackPanel.Children.OfType<TextBlock>().ToList();
                    var image = stackPanel.Children.OfType<Image>().SingleOrDefault();
                    image.Source = new ImageSourceConverter().ConvertFromString($"https:{forecast.Forecastday[i].Day.Condition.Icon}") as ImageSource;
                    textBlocks[Constants.TEMPERATURE_ELEMENT_INDEX].Text = $"Temperature(C): {forecast.Forecastday[i].Day.AvgtempC}";
                    textBlocks[Constants.HUMIDITY_ELEMENT_INDEX].Text = $"Humidity(%): {forecast.Forecastday[i].Day.Avghumidity}";
                    textBlocks[Constants.WIND_SPEED_ELEMENT_INDEX].Text = $"Wind Speed(m/s): {forecast.Forecastday[i].Day.AvgvisKm / 3.6}";
                    textBlocks[Constants.DATE_ELEMENT_INDEX].Text = $"Date: {forecast.Forecastday[i].Date}";
                    textBlocks[Constants.WEEK_DAY_ELEMENT_INDEX].Text = $"Week Day: {forecastDay.DayOfWeek}";
                    cards[i].Visibility = Visibility.Visible;
                }
            }
            catch(WebException)
            {
                MessageBox.Show("Нет такого города");
            }
        }

        private void CityNameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    if (string.IsNullOrEmpty(cityNameTextBox.Text))
                    {
                        MessageBox.Show("Введите город");
                        return;
                    }

                    string result;
                    using (var client = new WebClient())
                    {
                        result = client.DownloadString($"http://api.apixu.com/v1/forecast.json?key=59bacc56d0fc4e55bdb144248190605&q={cityNameTextBox.Text}&days=7");
                    }

                    var forecast = JsonConvert.DeserializeObject<CityDescription>(result).Forecast;
                    var cards = cardsGrid.Children.OfType<Card>().ToList();

                    for (int i = 0; i < cards.Count; i++)
                    {
                        DateTime forecastDay = Convert.ToDateTime(forecast.Forecastday[i].Date);
                        var stackPanel = cards[i].Content as StackPanel;
                        var textBlocks = stackPanel.Children.OfType<TextBlock>().ToList();
                        var image = stackPanel.Children.OfType<Image>().SingleOrDefault();
                        image.Source = new ImageSourceConverter().ConvertFromString($"https:{forecast.Forecastday[i].Day.Condition.Icon}") as ImageSource;
                        textBlocks[Constants.TEMPERATURE_ELEMENT_INDEX].Text = $"Temperature(C): {forecast.Forecastday[i].Day.AvgtempC}";
                        textBlocks[Constants.HUMIDITY_ELEMENT_INDEX].Text = $"Humidity(%): {forecast.Forecastday[i].Day.Avghumidity}";
                        textBlocks[Constants.WIND_SPEED_ELEMENT_INDEX].Text = $"Wind Speed(m/s): {forecast.Forecastday[i].Day.AvgvisKm / 3.6}";
                        textBlocks[Constants.DATE_ELEMENT_INDEX].Text = $"Date: {forecast.Forecastday[i].Date}";
                        textBlocks[Constants.WEEK_DAY_ELEMENT_INDEX].Text = $"Week Day: {forecastDay.DayOfWeek}";
                        cards[i].Visibility = Visibility.Visible;
                    }
                }
                catch (WebException)
                {
                    MessageBox.Show("Нет такого города");
                }
            }
        }
    }
}
