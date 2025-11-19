using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.app.ViewModel
{
    public class SaleViewModel
    {
        public SaleViewModel()
        {
            SaleItens = new List<SaleItemViewModel>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public User Salesman { get; set; }
        public Customer Customer { get; set; }
        public List<SaleItemViewModel> SaleItens { get; set; }
    }

    public class SaleItemViewModel()
    {
        public int Id { get; set; }
        public decimal Quatity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }
    }
}
