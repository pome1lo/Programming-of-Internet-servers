using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace lw1a.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSend(object sender, RoutedEventArgs e)
        {
            _ = SendPostRequest();
            MessageBox.Show("test");
        }

        private async Task SendPostRequest()
        {
            var xValue = XTextBox.Text;
            var yValue = YTextBox.Text;

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("X", xValue),
                    new KeyValuePair<string, string>("Y", yValue)
                });

                var response = await client.PostAsync("http://localhost:5121/PAA/SUM", content);

                if (response.IsSuccessStatusCode)
                {
                    ResultTextBox.Text = await response.Content.ReadAsStringAsync();
                }
            }
        }

    }
}
