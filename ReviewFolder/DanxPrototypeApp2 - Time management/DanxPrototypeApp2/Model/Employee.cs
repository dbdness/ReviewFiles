using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanxPrototypeApp2.Model
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Last_login { get; set; }
        public DateTime Last_logout { get; set; }
        public TimeSpan Total_hours { get; set; }


        public override string ToString()
        {
            return String.Format("{0}h {1}m", Total_hours.Hours, Total_hours.Minutes);
        }
    }
}
