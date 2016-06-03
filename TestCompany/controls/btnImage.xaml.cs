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

namespace TestCompany.controls
{
    /// <summary>
    /// Interaction logic for BtnImage.xaml
    /// </summary>
    public partial class btnImage : UserControl
    {
        public btnImage()
        {
            InitializeComponent();
        }
        
        string img_url = null;
        public string Img
        {
            get
            {                
                return img_url;
            }

            set
            {
                
                img_url = value;
                
                this.img.Source = new BitmapImage(new Uri( string.Format(@"/TestCompany;component/{0}", value), UriKind.Relative));
                
            }
        }


        public string Caption
        {
            get
            {
                return this.caption.Text;
            }

            set
            {
                this.caption.Text = value;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
        }        
    }
}
