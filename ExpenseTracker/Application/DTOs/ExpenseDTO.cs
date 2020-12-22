using System;

namespace Application.DTOs
{
    public class ExpenseDTO
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