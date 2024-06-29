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
using static MainProject.Search_complaints_PageADMIN_Matin.Search_complaints_AdminPageForm;

namespace MainProject.ReviewUnreviewedComplaints_Matin
{
    /// <summary>
    /// Interaction logic for ReviewUnreviewedComplaints_Page.xaml
    /// </summary>
    public partial class ReviewUnreviewedComplaints_Page : Window
    {
        public ReviewUnreviewedComplaints_Page()
        {
            InitializeComponent();
            this.DataContext = this;
            //For Now 
            List<complaints_User_FORNOW> demo = new List<complaints_User_FORNOW>
            {
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true),
                new complaints_User_FORNOW("Matin","HasanaaliBaki","UserName","THIS IS TITLE","ResName",true)

            };
            DataGridResault.ItemsSource = demo;

        }
    }
}
