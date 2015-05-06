using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using DanxPrototypeApp2.Common;
using DanxPrototypeApp2.Model;
using DanxPrototypeApp2.Persistency;

namespace DanxPrototypeApp2.ViewModel
{
    class DbViewModel
    {
        public ObservableCollection<Employee> EmployeesInDb { get; set; }

        public static bool IsLoggedIn { get; set; }
        public static Employee EmployeeToLogOut;
        private List<Employee> _loggedInEmployees;

        public string LoginBox { get; set; }

        public string LogoutBox { get; set; }

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }
        
        public DbViewModel()
        {


            EmployeesInDb = new ObservableCollection<Employee>();
            _loggedInEmployees = new List<Employee>();
                
            PersistencyService.GetData(EmployeesInDb);
            PersistencyService.GetData(_loggedInEmployees);

            LoginCommand = new RelayCommand(Login);
            LogoutCommand = new RelayCommand(Logout);



        }

        private void Login()
        {
            var employeess = EmployeesInDb.ToList();
            var matcingEmloyee = employeess.Find(e => e.Id.ToString() == LoginBox);
            if (matcingEmloyee != null)
            {
                PersistencyService.PostData(matcingEmloyee); //Posted to logged in employees database.
                UpdateLoginTime();
                IsLoggedIn = true;
                
            }
            else IsLoggedIn = false;
            
        }

        private void Logout()
        {
            PersistencyService.GetData(_loggedInEmployees);
           var matchingEmployee = _loggedInEmployees.Find(e => e.Id.ToString() == LogoutBox);
            if (matchingEmployee != null)
            {
                EmployeeToLogOut = matchingEmployee;
                UpdateLogoutTime();
                UpdateTotalHours();
                EmployeeToLogOut = null;
                PersistencyService.DeleteData(matchingEmployee); //Removing logged out employee from logged in table. 
                PersistencyService.GetData(_loggedInEmployees);
                if(_loggedInEmployees.Count == 0) IsLoggedIn = false;  
            }
            else IsLoggedIn = true;
        }

        private void UpdateLoginTime()
        {
            PersistencyService.GetData(_loggedInEmployees);
            
            var recentEmployee = _loggedInEmployees.Last();
            var updatedEmployee = new Employee
            {
                Id = recentEmployee.Id,
                Name = recentEmployee.Name,
                Total_hours = recentEmployee.Total_hours,
                Last_login = DateTime.Now,
                Last_logout = recentEmployee.Last_logout

            };

            PersistencyService.PutData(updatedEmployee); //Updated login time for shown employee list
            PersistencyService.PutDataForLoggedin(updatedEmployee); //Updated login time for logged in employee

            
        }

        private void UpdateLogoutTime()
        {
            var updatedEmployee = new Employee
            {
                Id = EmployeeToLogOut.Id, 
                Name = EmployeeToLogOut.Name,
                Last_logout = DateTime.Now,
                Last_login = EmployeeToLogOut.Last_login, 
                Total_hours = EmployeeToLogOut.Total_hours
                
            };
            EmployeeToLogOut = updatedEmployee;
            PersistencyService.PutData(updatedEmployee);
            //PersistencyService.PutDataForLoggedin(updatedEmployee);

        }

        private TimeSpan CalculateTimeWorked()
        {
           
            var hoursWorked = EmployeeToLogOut.Last_logout.Subtract(EmployeeToLogOut.Last_login);

             return EmployeeToLogOut.Total_hours += hoursWorked;
            
           
        }

        private void UpdateTotalHours() 
        {
            var updatedEmployee = new Employee
            {
                Id = EmployeeToLogOut.Id,
                Name = EmployeeToLogOut.Name,
                Last_login = EmployeeToLogOut.Last_login,
                Last_logout = EmployeeToLogOut.Last_logout,
                Total_hours = CalculateTimeWorked()
            };
            PersistencyService.PutData(updatedEmployee);
            //PersistencyService.PutDataForLoggedin(updatedEmployee);
        }

    }
}
