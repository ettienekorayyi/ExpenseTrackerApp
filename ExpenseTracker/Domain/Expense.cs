using System;

namespace Domain
{
   public class Expense
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Shop { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
    }



}