using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFitWpf.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int SectionId { get; set; }

        public Section? Section { get; set; }
        public SeasonTicket? Season { get; set; }
    }
}
