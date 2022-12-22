namespace QuoteComment.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string quote { get; set; }
        public string comment { get; set; } = null; 
    }
}
