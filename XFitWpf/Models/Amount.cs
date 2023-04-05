using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFitWpf.Models
{
    public class Amount
    {
        public int Id { get; set; }
        public int SeasonTicketId { get; set; }
        public int SectionId { get; set; }      
        public float Total { get; set; }

        public SeasonTicket SeasonTicket { get; set; }
        public Section? Section { get; set; }
    }
}
