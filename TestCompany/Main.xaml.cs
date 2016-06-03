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
using TestCompany.Data;

namespace TestCompany
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        #region constructor
        public Main()
        {
            InitializeComponent();


            // 1. init data to display in listview
            init_DataAccessLayer();


            // 2. setup event handler to allow user to interact with app
            init_EventHandlers();
        }

        #endregion



        #region Data Access Layer
        /*
            See DataAccessLayer class
        */
        void init_DataAccessLayer()
        {
            // bind listview to data source
            listview.ItemsSource = DataAcessLayer.Data;
        }
        #endregion



        #region user actions events handlers
        void init_EventHandlers()
        {
            btnAdd.btn.Click += BtnAdd_Click;
            btnEdit.btn.Click += BtnEdit_Click;
            btnDelete.btn.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var emp = listview.SelectedItem;

            // First check that there is a valid employee selected
            if (emp == null)
            {
                MessageBox.Show("Select first an employee by clicking on a row", "Information", MessageBoxButton.OK);
            }
            else
            {
                delete_employee(emp as Employee);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var emp = listview.SelectedItem;

            // First check that there is a valid employee selected
            if (emp == null)
            {
                MessageBox.Show("Select first an employee by clicking on a row", "Information", MessageBoxButton.OK);
            }
            else
            {
                display_employee(emp as Employee);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            display_employee(null);
        }

        #endregion



        #region general UI methods

        // this routine displays either the selected employee or 
        // allows user to add a new employee
        void display_employee(Employee emp)
        {
            EmployeView emp_view = new EmployeView(emp);

            bool? closed = emp_view.ShowDialog();

            if ( closed == true)
            {
                refresh_datasource();
            }
        }



        void delete_employee(Employee emp)
        {
            DataAcessLayer.Data.Remove(emp);

            refresh_datasource();
        }


        void refresh_datasource()
        {
            // In a real life scenarion we would use an observable collection which
            // would be aware of the changes occuring in its underlying list
            // for now we 'fake' a refresh

            listview.ItemsSource = null;
            listview.ItemsSource = DataAcessLayer.Data;
        }


        #endregion
    }




}
