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
        public string Name { get => name; set => name = value; }
        internal Group CurrentGroup { get => currentGroup; set => currentGroup = value; }
        internal List<Worker> Subbordinate { get => subbordinate; set => subbordinate = value; }
        public int Id { get => id; set => id = value; }
        internal Worker Chief { get => chief; set => chief = value; }
        public DateTime Date { get => date; set => date = value; }

        protected virtual float Payroll(DateTime PayrollDateStart, DateTime PayrollDateEnd) {
            return 0;
        }

        public virtual float GetPayroll(DateTime PayrollDateStart, DateTime PayrollDateEnd) {
            return Payroll(PayrollDateStart, PayrollDateEnd);
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

    
        public void SetChief(Worker chief)
        {
            if (chief != null) {
                Chief = chief;
                chief.AddSub(this);
            }
        }




     

        protected void AddSubordinate(Worker sub)
        {
            Subbordinate.Add(sub);
        }

      

        public void UpdateChief(Worker chief)
        {
            SetChief(chief);
        }
        public void AddSub(Worker sub)
        {
            if (Group.Employee != CurrentGroup)
                AddSubordinate(sub);
        }

        public int GetCountAllSubordinate()
        {
            return Subbordinate.Count();
        }
        public int GetCountEmployeeSubordinate()
        {
            int count = 0;
            for (int i = 0; i < Subbordinate.Count(); i++)
            {
                if (Subbordinate[i].CurrentGroup == Group.Employee)
                    count++;
            }
            return count;
        }

      

        public int GetCountManagerSubordinate()
        {
            int count = 0;
            for (int i = 0; i < Subbordinate.Count(); i++)
            {
                if (Subbordinate[i].CurrentGroup == Group.Manager)
                    count++;
            }
            return count;
        }

      
    }
}
