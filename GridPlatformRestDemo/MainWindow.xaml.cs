using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace GridPlatformRestDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UrlTextBox.Text = "https://portal.grid-manager.com/api/v3/datasequences/";
        }

        private async void Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"token {TokenTextBox.Text}");
                    ResponseTextBox.Text = await client.GetStringAsync(UrlTextBox.Text);
                }
            }
            catch (Exception exception)
            {
                ResponseTextBox.Text = exception.ToString();
            }
        }
    }
}