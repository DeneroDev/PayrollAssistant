﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollAssistant
{
    class CurrentWorker:Worker
    {
        public CurrentWorker(int id, string name, DateTime date, Group group)
        {
            Id = id;
            Name = name;
            Date = date;
            CurrentGroup = group;
            Subbordinate = new List<Worker>();
            Idssubb = new List<string>();
        }

       // public float GetPayroll(DateTime PayrollDateStart, DateTime PayrollDateEnd) {
       //     return 0;
       // }

        protected override float Payroll(DateTime PayrollDateStart, DateTime PayrollDateEnd)
        {
            throw new NotImplementedException();
        }

        // protected override float Payroll(DateTime PayrollDateStart, DateTime PayrollDateEnd)
        // {
        //     switch (CurrentGroup) {
        //         case Group.Employee:
        //             return GetSalary(PayrollDateStart, PayrollDateEnd,
        //      AllConstate.EMPLOYEE_PRECENT_EXPIRIENCE,
        //      AllConstate.EMPLOYEE_MAX_SUMMARY_PRECENT_EXPIRIENCE,
        //      AllConstate.EMPLOYEE_RATEBASE);
        //         case Group.Manager:
        //             return GetSalary(PayrollDateStart, PayrollDateEnd,
        //      AllConstate.MANAGER_PRECENT_EXPIRIENCE,
        //      AllConstate.MANAGER_MAX_SUMMARY_PRECENT_EXPIRIENCE,
        //      AllConstate.MANAGER_RATEBASE);
        //         case Group.Salesman:
        //             return GetSalary(PayrollDateStart, PayrollDateEnd,
        //      AllConstate.SALESMAN_PRECENT_EXPIRIENCE,
        //      AllConstate.SALESMAN_MAX_SUMMARY_PRECENT_EXPIRIENCE,
        //      AllConstate.SALESMAN_RATEBASE);
        //         default:
        //             return GetSalary(PayrollDateStart, PayrollDateEnd,
        //      AllConstate.EMPLOYEE_PRECENT_EXPIRIENCE,
        //      AllConstate.EMPLOYEE_MAX_SUMMARY_PRECENT_EXPIRIENCE,
        //      AllConstate.EMPLOYEE_RATEBASE);
        //     }
        //   
        // }
        //
        // private float GetSalary(DateTime PayrollDateStart, DateTime PayrollDateEnd,
        //             float PRECENT_EXPIRIENCE,
        //             float MAX_SUMMARY_PRECENT_EXPIRIENCE,
        //             float RATEBASE)
        // {
        //     float salary;
        //     int experience;
        //     float percent;
        //
        //     experience = PayrollDateEnd.Year - Date.Year;
        //     percent = experience * PRECENT_EXPIRIENCE;
        //     if (percent > MAX_SUMMARY_PRECENT_EXPIRIENCE)
        //         percent = MAX_SUMMARY_PRECENT_EXPIRIENCE;
        //     salary = (RATEBASE * (CalculateSpendDay(PayrollDateStart, PayrollDateEnd))) + (RATEBASE * percent);
        //     if (salary < 0)
        //         return 0;
        //
        //     if (Subbordinate != null && CurrentGroup!=Group.Employee)
        //     {
        //         switch (CurrentGroup) {
        //             case Group.Manager:
        //                 salary += (GetCountEmployeeSubordinate() * AllConstate.EMPLOYEE_RATEBASE) * AllConstate.MANAGER_PRECENT_SUBORDINATES;
        //                 break;
        //             case Group.Salesman:
        //                 salary += (((GetCountEmployeeSubordinate() * AllConstate.EMPLOYEE_RATEBASE) * AllConstate.SALESMAN_PRECENT_SUBORDINATES)
        //                 + ((GetCountManagerSubordinate() * AllConstate.MANAGER_RATEBASE) * AllConstate.SALESMAN_PRECENT_SUBORDINATES));
        //                 break;
        //         }               
        //     }
        //     return salary;
        // }
    }
}
