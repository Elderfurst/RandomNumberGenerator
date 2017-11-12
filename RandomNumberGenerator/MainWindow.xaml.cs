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

namespace RandomNumberGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<int> GeneratedNumbers = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateRandomNumber(object sender, RoutedEventArgs e)
        {
            ErrorLabel.Content = "";
            if(int.TryParse(this.StartingValue.Text, out int startingValue) && int.TryParse(this.EndingValue.Text, out int endingValue))
            {
                var temp = Enumerable.Range(startingValue, endingValue - startingValue).ToList<int>();
                if (!Enumerable.Range(startingValue, endingValue + 1 - startingValue).ToList<int>().Except(GeneratedNumbers).Any())
                {
                    ErrorLabel.Content = "All possible values have been used";
                    return;
                }
                var random = new Random();
                var possibleValue = random.Next(startingValue, endingValue);
                while(GeneratedNumbers.Contains(possibleValue))
                {
                    possibleValue = random.Next(startingValue, endingValue + 1);
                }
                GeneratedNumbers.Add(possibleValue);
                OutputLabel.Content = possibleValue;
                ShowGeneratedNumbersList.Text += ShowGeneratedNumbersList.Text.ToString() == "" ? possibleValue.ToString() : ", " + possibleValue;
            }
            else
            {
                ErrorLabel.Content = "Starting and ending values must be numbers";
                return;
            }
        }

        private void EmptyNumberList(object sender, RoutedEventArgs e)
        {
            GeneratedNumbers.Clear();
            ShowGeneratedNumbersList.Text = "";
            ErrorLabel.Content = "";
        }
    }
}
