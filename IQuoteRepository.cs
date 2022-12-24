using QuoteComment.Models;

namespace QuoteComment
{
    public interface IQuoteRepository
    {
        public Quote quoteString();
        public void InsertQuote(Quote quoteToInsert);
        public IEnumerable<Quote> GetAllQuote();
        public void EditComment(Quote commentToInsert);


    }
}
