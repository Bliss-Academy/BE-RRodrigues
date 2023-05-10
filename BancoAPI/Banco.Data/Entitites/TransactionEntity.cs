using System;

namespace Banco.Data.Entities
{
    public enum TrasactionType
    {
        Income=0,
        Expense=1
    }
    public class TransactionEntity
    {
        public int id {  get; set; }
        public string userId { get; set; }
        public TrasactionType type { get; set; }
        public decimal value { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string attachment { get; set; }

    }
}
