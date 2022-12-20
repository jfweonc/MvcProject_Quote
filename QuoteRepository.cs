using Newtonsoft.Json.Linq;

namespace QuoteComment
{
    public class QuoteRepository: IQuoteRepository
    {public string quoteString()
        {
            var kanyeURL = "https://api.kanye.rest";
            var client = new HttpClient();
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;
        }
    }
}
