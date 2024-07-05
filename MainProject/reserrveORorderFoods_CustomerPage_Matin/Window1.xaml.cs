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

        public Window1(string path, bool haveImage)
        {
            InitializeComponent();
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
    }
}
