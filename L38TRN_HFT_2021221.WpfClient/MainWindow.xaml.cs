using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace L38TRN_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void ArtistsButton_Click(object sender, RoutedEventArgs e)
        {
            new ArtistWindow().Show();
        }

        private void AlbumsButton_Click(object sender, RoutedEventArgs e)
        {
            new AlbumWindow().Show();
        }

        private void SongsButton_Click(object sender, RoutedEventArgs e)
        {
            new SongWindow().Show();
        }
    }
}
