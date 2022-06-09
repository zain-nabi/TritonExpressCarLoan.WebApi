using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.LoanDocument
{
    public  interface ICarLoanDocument
    {
        Task<bool> InsertQuote(Application.Model.Quote.Quote model);
        Task<bool> UpdateQuote(Application.Model.Quote.Quote model);
        Task<List<Application.Model.Quote.Quote>> GetQuotesByEmail(string Email);
        Task<Application.Model.Quote.Quote> GetQuotesByID(int QuoteID);
        Task<List<Application.Model.Quote.Quote>> GetAllQuotes();
        Task<bool> DeleteQuote(Application.Model.Quote.Quote model);
    }
}
