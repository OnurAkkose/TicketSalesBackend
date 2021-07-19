using System;
using System.Linq;
using TicketSales.Core.Entities;
using TicketSales.Entities.Concrete.Companies;

namespace TicketSales.Entities.Concrete.Tickets
{
    public class SaveOrUpdateTicket : IEntity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompanyId{ get; set; }
        public DateTime ShowDate { get; set; }
        public int Level { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime LastDate { get; set; }
    }
}
