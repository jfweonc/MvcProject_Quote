using Newtonsoft.Json.Linq;
using QuoteComment.Models;
using System.Data;
using Dapper; 

namespace QuoteComment
{
    public class QuoteRepository: IQuoteRepository
    {
        private readonly IDbConnection _conn;
        public QuoteRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public Quote quoteString()
        {
            var kanyeURL = "https://api.kanye.rest";
            var client = new HttpClient();
            String kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Quote myQuote = new Quote();
            myQuote.quote = kanyeQuote;
            return myQuote;
        }
        public void InsertQuote(Quote quoteToInsert)
        {
            _conn.Execute("INSERT INTO quotes_table (quote,comment) VALUES (@quote,@comment);",
                new { quote = quoteToInsert.quote, comment = quoteToInsert.comment });
        }
        public IEnumerable<Quote> GetAllQuote()
        {
            return _conn.Query<Quote>("Select * From quotes_table");
        }
        public void EditComment(Quote commentToEdit)
        {
            _conn.Execute("INSERT INTO products (comment) VALUES (@comment) WHERE id=@id;",
                new { comment = commentToEdit.comment, id = commentToEdit.id });
        }
    }
}
