using IFSPStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{
    public class Sale : BaseEntity<int>
    {
        public Sale(int id, DateTime date, float totalAmount, User user, Customer custumer) : base(id)
        {
            Date = date;
            TotalAmount = totalAmount;
            User = user;
            Customer = custumer;
        }

        public DateTime Date { get; set; }
        public float TotalAmount { get; set; }
        public User User { get; set; }
        public Customer Customer { get; set; }

    }
     public class ItemSale : BaseEntity<int>
    { 
        public ItemSale(int id, int quantity, float unitPrice, float totalAmount, Sale sale, Product product) : base(id)
        {
            Quatity = quantity;
            UnitPrice = unitPrice;
            TotalAmount = totalAmount;
            Sale = sale;
            Product = product;

        }
        public int Quatity { get; set; }
        public float UnitPrice { get; set; }
        public float TotalAmount { get; set; }
        public Sale Sale { get; set; }
        public Product Product { get; set; }



     }
}
