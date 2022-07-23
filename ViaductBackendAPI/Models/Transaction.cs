namespace ViaductBackendAPI.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
}
