using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollAssistant
{
    abstract class Worker
    {
        
     
       
        private int id;
        private string name;
        private DateTime date;
        public enum Group { Employee, Manager, Salesman }
        private Group currentGroup = Group.Employee;
        private List<string> idssubb;
        private string idchief;
        private List<Worker> subbordinate;
        private Worker chief;

        public List<string> Idssubb { get => idssubb; set => idssubb = value; }
        public string Idchief { get => idchief; set => idchief = value; }

    

        abstract protected float Payroll(DateTime PayrollDateStart, DateTime PayrollDateEnd);


        public string GetName() {
            return name;
        }
        protected void SetName(string name)
        {
            this.name = name;
        }



        public DateTime GetDate()
        {
            return date;
        }
        protected void SetDate(DateTime date)
        {
            this.date = date;
        }


        public Group GetCurrentGroup()
        {
            return currentGroup;
        }
        protected void SetCurrentGroup(Group group)
        {
            currentGroup = group;
        }

        protected float CalculateSpendDay(DateTime PayrollDateStart, DateTime PayrollDateEnd)
        {
            float result = ((PayrollDateEnd.DayOfYear - PayrollDateStart.DayOfYear) / 21f);
            if ((PayrollDateEnd.DayOfYear - PayrollDateStart.DayOfYear) < 0 && PayrollDateEnd.Year != PayrollDateStart.Year)
            {
                int currentDo = 365 - PayrollDateStart.DayOfYear;
                currentDo += PayrollDateEnd.DayOfYear;
                result = currentDo / 21f;
            }
            //   Console.WriteLine(result);
            if (result > 0)
                return result;
            else
            {
                return -1;
            }

        }

        public Worker GetChief()
        {
            return chief;
        }

        public void SetChief(Worker chief)
        {
            this.chief = chief;
            chief.AddSub(this);
        }


        public List<Worker> GetSubbordinate()
        {
            return subbordinate;
        }

        protected void InitIdsSubList() {
            idssubb = new List<string>();
        }

        protected void AddSubordinate(Worker sub)
        {
            Console.WriteLine(sub.GetName() + "СЛУГА");
            subbordinate.Add(sub);
        }

      

        public void UpdateChief(Worker chief)
        {
            SetChief(chief);
        }
        public void AddSub(Worker sub)
        {
            if (Group.Employee != GetCurrentGroup())
                AddSubordinate(sub);
        }

      


       

        public int GetID() {
            return id;
        }

        protected void SetID(int id) {
            this.id = id;
        }


        public int GetCountAllSubordinate()
        {
            return subbordinate.Count();
        }
        public int GetCountEmployeeSubordinate()
        {
            int count = 0;
            for (int i = 0; i < subbordinate.Count(); i++)
            {
                if (subbordinate[i].GetCurrentGroup() == Group.Employee)
                    count++;
            }
            return count;
        }

        protected void SetSubordinate()
        {
            subbordinate = new List<Worker>();
        }

        public int GetCountManagerSubordinate()
        {
            int count = 0;
            for (int i = 0; i < subbordinate.Count(); i++)
            {
                if (subbordinate[i].GetCurrentGroup() == Group.Manager)
                    count++;
            }
            return count;
        }

      
    }
}
