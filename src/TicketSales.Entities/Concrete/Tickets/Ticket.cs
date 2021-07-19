using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entities;
using TicketSales.Entities.Concrete.Companies;

namespace TicketSales.Entities.Concrete.Tickets
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company{ get; set; }
        public DateTime ShowDate { get; set; }        
        public DateTime SaleDate{ get; set; }
        public DateTime LastDate{ get; set; }
        public int SalesCount { get; set; }

    }
}
