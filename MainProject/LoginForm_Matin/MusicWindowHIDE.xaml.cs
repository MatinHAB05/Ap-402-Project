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
using System.Windows.Shapes;

namespace MainProject.LoginForm_Matin
{
    /// <summary>
    /// Interaction logic for MusicWindowHIDE.xaml
    /// </summary>
    public partial class MusicWindowHIDE : Window
    {
        public MusicWindowHIDE(string path)
        {
            InitializeComponent();
            backgroundMusic.Source = new Uri(path ,UriKind.Relative);

            // Play the background music
            backgroundMusic.Play();
        }

        private void backgroundMusic_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Replay the background music when it ends
            backgroundMusic.Position = TimeSpan.Zero;
            backgroundMusic.Play();
            //MessageBox.Show("END");
        }
    }
}
