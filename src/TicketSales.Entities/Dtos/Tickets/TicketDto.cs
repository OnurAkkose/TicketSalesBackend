using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entities;
using TicketSales.Entities.Concrete.Companies;

namespace TicketSales.Entities.Dtos
{
    public class TicketDto: IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public DateTime ShowDate { get; set; }
        public int Level { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime LastDate { get; set; }
        public int SalesCount { get; set; }
    }
}
