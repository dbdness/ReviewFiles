using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.PointOfService;
using DanxPrototypeApp2.Model;
using Microsoft.VisualBasic.CompilerServices;

namespace DanxPrototypeApp2.Persistency
{
    class PersistencyService
    {
        private const string ServerUri = "http://localhost:1932";

        public static void GetData(ObservableCollection<Employee> collection)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/employees").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var dbData = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                        foreach (var d in dbData) collection.Add(d);
                    }
                }
                catch (HttpRequestException)
                {
                    
                }
            }
        }

        public static void PutData(Employee employee)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PutAsJsonAsync("api/employees/" + employee.Id, employee).Result;
                }
                catch (HttpRequestException)
                {
                    
                }
            }
        }

        public static void PutDataForLoggedin(Employee employee)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PutAsJsonAsync("api/loggedInEmployees/" + employee.Id, employee).Result;
                }
                catch (HttpRequestException)
                {

                }
            } 
        }

        /// <summary>
        /// Get the list of logged in employees.
        /// </summary>
        /// <param name="collection"></param>
        public static void GetData(List<Employee> collection)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/loggedInEmployees").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var dbData = response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                        collection.AddRange(dbData);
                    }
                }
                catch (HttpRequestException)
                {
                    
                }
            }
        }

        /// <summary>
        /// Add an employee to the database for logged in employees.
        /// </summary>
        /// <param name="employee"></param>
        public static void PostData(Employee employee)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync("api/loggedInEmployees", employee).Result;
                }
                catch (HttpRequestException)
                {
                    
                }
            }
        }

        /// <summary>
        /// Remove logged in employee from database when he logs out. 
        /// </summary>
        /// <param name="employee"></param>
        public static void DeleteData(Employee employee)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.DeleteAsync("api/loggedInEmployees/" + employee.Id).Result;
                }
                catch (HttpRequestException)
                {
                    
                }
            }
        }
    }
}
