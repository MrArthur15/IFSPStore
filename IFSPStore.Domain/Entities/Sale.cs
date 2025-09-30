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
        public Sale(int id, DateTime date, float totalAmount) : base(id)
        {
            Date = date;
            TotalAmount = totalAmount;
        }

        public DateTime Date { get; set; }
        public float TotalAmount { get; set; }
    }
     public class ItemSale : BaseEntity<int>
    { 
        public ItemSale(int id, int quantity, float unitPrice, float totalAmount) : base(id)
        {
            Quatity = quantity;
            UnitPrice = unitPrice;
            TotalAmount = totalAmount;

        }
        public int Quatity { get; set; }
        public float UnitPrice { get; set; }
        public float TotalAmount { get; set; }


    }
