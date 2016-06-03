using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCompany.Data
{
    /*
     * Here we simulate a Data access layer that we would typically find at
     * the application server tier ( e.g Ado.Net + Entity framework)
    */
    public static class DataAcessLayer
    {        
        static List<Employee> __data;
        public static List<Employee> Data
        {
            get
            {
                if(__data == null)
                {
                    __data = new List<Employee>();
                    initial_fill_data();
                }
                return __data;
            }
        }

        // populate our list with some hardcoded data ( fakes a fetch call to server)
        private static void initial_fill_data()
        {
            Data.Add(new Employee() { Name = "John", SurName = "Doe", JobTitle = "Chief Executive Office", HireDate = Convert.ToDateTime("11/08/2008"), Mail = "jd@testcompany.com" });
            Data.Add(new Employee() { Name = "Jane", SurName = "Sullivan", JobTitle = "Account General Manager", HireDate = Convert.ToDateTime("26/01/2005"), Mail = "js@testcompany.com" });
            Data.Add(new Employee() { Name = "Dave", SurName = "James", JobTitle = "Chief Resources Officer", HireDate = Convert.ToDateTime("16/09/2011"), Mail = "js@testcompany.com" });
            Data.Add(new Employee() { Name = "Robert", SurName = "Zare", JobTitle = "Sales Manager", HireDate = Convert.ToDateTime("24/07/2010"), Mail = "js@testcompany.com" });

        }        
    }
    
}


public class Employee
{
    public Employee()
    {
        EmpID = Guid.NewGuid().ToString();
    }

    public string EmpID { get; set; }

    public string Name { get; set; }

    public string SurName { get; set; }

    public string JobTitle { get; set; }

    public DateTime HireDate { get; set; }
    
    public string Mail { get; set; }


    public Employee CopySelf()
    {
        return (Employee)this.MemberwiseClone();
    }


    public void UpdateValuesFrom(Employee sourceObject)
    {
        this.GetType().GetProperties().ToList().ForEach(targetProperty =>
       {
           if(targetProperty.Name != "EmpID")
           {
               var sourceValue = sourceObject.GetType().GetProperty(targetProperty.Name).GetValue(sourceObject);

               targetProperty.SetValue(this, sourceValue);
           }


       });
    }
}
