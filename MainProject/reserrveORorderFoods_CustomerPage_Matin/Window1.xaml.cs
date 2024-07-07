using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace MainProject.reserrveORorderFoods_CustomerPage_Matin
{
    public partial class Window1 : Window, INotifyPropertyChanged
    {
        private string _pppp;
        public string pppp
        {
            get { return _pppp; }
            set
            {
                _pppp = value;
                OnPropertyChanged(nameof(pppp));
            }
        }
        public reserrveORorderFoods_CustomerPage Preee {  get; set; }
        public Window1(string path, bool haveImage,reserrveORorderFoods_CustomerPage Pre)
        {
            InitializeComponent();
            Preee= Pre;
            if (haveImage)
            {
                pppp = path;

            }
            else
            {
                pppp = @"\reserrveORorderFoods_CustomerPage_Matin\Images\NoIMG.png";
            }
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            this.Preee.Show();
        }
    }
}
