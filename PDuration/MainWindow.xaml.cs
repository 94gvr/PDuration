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

namespace PDuration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("E:\\ПЛОХОЕ ХОББИ ДЛЯ ПЛОХИХ ЛЮДЕЙ\\PDuration\\Images\\YoutubeLogo.png",
                UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            Logo.Source = bitmap;
        }

        private void TextInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Duration.Text = Get.GetPlaylistDuration(TextInput.Text);
            }
        }
    }
}
