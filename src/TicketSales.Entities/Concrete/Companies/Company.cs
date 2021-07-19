using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Constants.Companies;
using TicketSales.Core.Entities;
using TicketSales.Entities.Concrete.Tickets;

namespace TicketSales.Entities.Concrete.Companies
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Sector { get; set; }
        public bool IsActive{ get; set; }       
        //public int Size { get; set; }
    }
}
