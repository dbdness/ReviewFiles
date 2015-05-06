using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanxPrototypeApp1.Common;
using DanxPrototypeApp1.Model;
using DanxPrototypeApp1.Persistency;

namespace DanxPrototypeApp1.ViewModel
{
    class DbViewModel
    {
        public ObservableCollection<Worker> WorkersInDb { get; set; }
        public Worker SelectedWorker { get; set; }
        public int SelectedAge { get; set; }

        public string NewName { get; set; }
        public int NewAge { get; set; }
        public string NewAdress { get; set; }

        public RelayCommand ChangeDataCommand { get; set; }
        public List<int> AgeList { get; set; } 

        

        public DbViewModel()
        {
            WorkersInDb = new ObservableCollection<Worker>();

            PersistencyService.GetData(WorkersInDb);

            ChangeDataCommand = new RelayCommand(ChangeWorkerData);

            AgeList = Ages();

        }

        private List<int> Ages()
        {
            var ageList = new List<int>();
            for (int i = 0; i <= 80; i++) ageList.Add(i);
            return ageList;

        }

        private void ChangeWorkerData()
        {
            
            var workerEdited = new Worker();

            if (!String.IsNullOrWhiteSpace(NewName)) workerEdited.Worker_name = NewName;
            else workerEdited.Worker_name = SelectedWorker.Worker_name;
            if (SelectedAge != 0) workerEdited.Worker_age = NewAge;
            else workerEdited.Worker_age = SelectedWorker.Worker_age;
            workerEdited.Worker_id = SelectedWorker.Worker_id;
            if (!String.IsNullOrWhiteSpace(NewAdress)) workerEdited.Worker_adress = NewAdress;
            else workerEdited.Worker_adress = SelectedWorker.Worker_adress;
            PersistencyService.PutData(workerEdited);
            WorkersInDb.Clear();
            PersistencyService.GetData(WorkersInDb);
            NewName = null;
            NewAdress = null;
            NewAge = 0;
        }
    }
}
