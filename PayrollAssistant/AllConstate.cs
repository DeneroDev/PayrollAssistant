using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollAssistant
{
    public static class AllConstate
    {
        public const float SALESMAN_RATEBASE = 30000f;
        public const float SALESMAN_PRECENT_EXPIRIENCE = 0.01f;
        public const float SALESMAN_MAX_SUMMARY_PRECENT_EXPIRIENCE = 0.35f;
        public const float SALESMAN_PRECENT_SUBORDINATES = 0.003f;

        public const float EMPLOYEE_RATEBASE = 10000f;
        public const float EMPLOYEE_PRECENT_EXPIRIENCE = 0.03f;
        public const float EMPLOYEE_MAX_SUMMARY_PRECENT_EXPIRIENCE = 0.3f;
       
        public const float MANAGER_RATEBASE = 20000f;
        public const float MANAGER_PRECENT_EXPIRIENCE = 0.05f;
        public const float MANAGER_MAX_SUMMARY_PRECENT_EXPIRIENCE = 0.4f;
        public const float MANAGER_PRECENT_SUBORDINATES = 0.005f;
    }
}
