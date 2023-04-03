using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFitWpf.Models
{
    public class SeasonTicket
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TrainerId { get; set; }
        public int WorkingHours { get; set; }
        public int CountSeason { get; set; }
        public Employee Employee { get; set; } 
        public Trainer? Trainer { get; set; }
        public Amount? Amount { get; set; }

    }
}
