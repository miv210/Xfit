using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace XFitWpf.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Lessons { get; set; }
        public float AmountForOneLesson { get; set; }
        public List<Trainer> Trainers { get; set; } = new();
        public Amount Amount { get; set; }
    }
}
