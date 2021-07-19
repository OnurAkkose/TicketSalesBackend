using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Entities;

namespace TicketSales.Entities.Dtos
{
    public class CompanyDto: IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Sector { get; set; }
        public bool IsActive { get; set; }
        //public int Size { get; set; }
    }
}
