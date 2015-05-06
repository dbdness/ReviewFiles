using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using DanxPrototypeApp1.Model;

namespace DanxPrototypeApp1.Persistency
{
    class PersistencyService
    {
        private const string ServerUri = "http://localhost:3223";

        public static void GetData(ObservableCollection<Worker> collection)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/workers").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var dbData = response.Content.ReadAsAsync<IEnumerable<Worker>>().Result;
                        foreach (var d in dbData) collection.Add(d);
                    }
                }
                catch (HttpRequestException)
                {
                    var errorMsg = new MessageDialog("The data from the database could not be fetched. Try again.",
                        "Error");
                    errorMsg.ShowAsync();
                }
            }

        }

        public static void PutData(Worker worker)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PutAsJsonAsync("api/workers/" + worker.Worker_id, worker).Result;
                    
                }
                catch (HttpRequestException)
                {
                    
                }
            }
        }
    }
}
