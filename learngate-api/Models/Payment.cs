namespace learngate_api.Models
{
    public class Payment
    {
        public int Id { get; set; } 
        public string PaymentName { get; set; } = string.Empty;
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int Amount { get; set; }
        public bool Payed { get; set; }

    }
}
