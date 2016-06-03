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
    /// Interaction logic for textEdit.xaml
    /// </summary>
    public partial class textEdit : UserControl
    {
        public textEdit()
        {
            InitializeComponent();
               
        }


        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }

            set
            {
                SetValue(CaptionProperty, value);                
            }
        }

        public static DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(textEdit), null);


        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);                
            }

            set
            {
                SetValue(TextProperty, value);                
            }
        }

        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(textEdit), null);
    }
}
