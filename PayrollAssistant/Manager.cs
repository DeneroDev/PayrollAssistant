using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollAssistant
{
    class Manager : Worker
    {

        public Manager(int id, string name, DateTime date, Group group)
        {
            Id = id;
            Name = name;
            Date = date;
            CurrentGroup = group;
            Subbordinate = new List<Worker>();
            Idssubb = new List<string>();
        }





        protected override float Payroll(DateTime PayrollDateStart, DateTime PayrollDateEnd)
        {
            return GetSalary(PayrollDateStart, PayrollDateEnd,
              AllConstate.MANAGER_PRECENT_EXPIRIENCE,
              AllConstate.MANAGER_MAX_SUMMARY_PRECENT_EXPIRIENCE,
              AllConstate.MANAGER_RATEBASE);
        }


        private float GetSalary(DateTime PayrollDateStart, DateTime PayrollDateEnd,
                float PRECENT_EXPIRIENCE,
                float MAX_SUMMARY_PRECENT_EXPIRIENCE,
                float RATEBASE)
        {
            float salary;
            int experience;
            float percent;

            experience = PayrollDateEnd.Year - Date.Year;
            percent = experience * PRECENT_EXPIRIENCE;
            if (percent > MAX_SUMMARY_PRECENT_EXPIRIENCE)
                percent = MAX_SUMMARY_PRECENT_EXPIRIENCE;
            salary = (RATEBASE * (CalculateSpendDay(PayrollDateStart, PayrollDateEnd))) + (RATEBASE * percent);
            if (salary < 0)
                return 0;

            if (Subbordinate != null)
            {
                salary += (GetCountEmployeeSubordinate() * AllConstate.EMPLOYEE_RATEBASE) * AllConstate.MANAGER_PRECENT_SUBORDINATES;
            }
            return salary;
        }
    }
}
