using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollAssistant
{
    class CasheAllWorkerHelper
    {
        CasheAllWorkerHelper() {
            workers = new List<Worker>();
        }
        public static CasheAllWorkerHelper instance;
        public static CasheAllWorkerHelper GetInstance() {
            if (instance == null)
                instance = new CasheAllWorkerHelper();
            return instance;
        }


        private List<Worker> workers;


        public List<Worker> GetAllWorker() {
            return workers;
        }

        public void ClearAllWorker() {
            workers.Clear();
        }

        public Worker GetWorkerByID(int id) {
            for (int i = 0; i < workers.Count; i++) {
                if (workers[i].Id == id) {
                    return workers[i];
                }
            }
            return null;
        }

        public Worker GetWorkerByName(string name)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].Name == name)
                {
                    return workers[i];
                }
            }
            return null;
        }

        public void AddWorker(Worker worker) {
            workers.Add(worker);
        }




        public void CalculateChiefAndSub()
        {
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].Idchief != null && workers[i].Idchief != "-")
                {
                    for (int j = 0; j < workers[i].Idchief.Length; j++) {
                        workers[i].SetChief(GetWorkerByID(int.Parse(workers[i].Idchief)));
                    }
                }
            }
        }

       

    }
}
