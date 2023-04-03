using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFitWpf.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string NumberPhone { get; set; }

        public SeasonTicket? SeasonTicket { get; set; }
    }
}
