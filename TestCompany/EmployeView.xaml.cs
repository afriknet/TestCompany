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

namespace TestCompany
{
    /// <summary>
    /// Interaction logic for EmployeView.xaml
    /// </summary>

    
    public partial class EmployeView : Window
    {
        #region internal properties

        /* _Emp is the data object passed from the listview in Main.Xaml for editing */
        private Employee _Emp;
        bool EmpIsNew
        {
            get
            {
                return _Emp == null;
            }
        }

        #endregion


        #region constructor
        public EmployeView(Employee emp)
        {
            InitializeComponent();

            _Emp = emp;

            init_data();

            init_actions();
        }

        #endregion


        #region data methods
        void init_data()
        {       
            // This measn user has clicked the 'Add' button and wants to add a new Employee
            if (EmpIsNew)
            {
                txtOpenStatus.Text = "New Employee";

                DataContext = new Employee();
            }
            else
            {
                txtOpenStatus.Text = "Edit Employee details";

                // We do a copy of the original employee. This will allow us to reload
                // original data in case user clicks cancel (see Main.cs, refresh_datasource )

                // In a real life scenario our DTO would implement some sort of change tracking mechanism
                // with perhaps a 'CancelChanges' method.

                DataContext = _Emp.CopySelf();        
            }            
        }


        void apply_changes()
        {
            // Copy changes back to the original object
            // In real life scemarion this would typically be a SQL Update statement
            // sent to data backend
            Employee modified_emp = this.DataContext as Employee;
            Employee original_emp = TestCompany.Data.DataAcessLayer.Data.Find(em => em.EmpID == (this.DataContext as Employee).EmpID);

            original_emp.Name = modified_emp.Name;
            original_emp.SurName = modified_emp.SurName;
            original_emp.JobTitle = modified_emp.JobTitle;
            original_emp.Mail = modified_emp.Mail;
        }

        #endregion



        #region user actions
        void init_actions()
        {
            this.btnSave.btn.Click += BtnSave_Click;
            this.btnCancel.btn.Click += BtnCancel_Click;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // In a real world application, we would first properly validate the data before
            // any save to the backend
            if (EmpIsNew)
            {
                (this.DataContext as Employee).HireDate = DateTime.Now;
                TestCompany.Data.DataAcessLayer.Data.Add(this.DataContext as Employee);
            }
            else
            {
                apply_changes();
            }

            this.DialogResult = true;

            this.Close();
        }

        #endregion


        
        
    }
}
