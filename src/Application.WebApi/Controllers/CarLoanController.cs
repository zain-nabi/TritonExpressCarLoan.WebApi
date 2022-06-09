using Application.Interface.LoanDocument;
using Application.Model.Quote;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarLoanController : ControllerBase
    {
        private readonly ICarLoanDocument _carLoan;

        public CarLoanController(ICarLoanDocument carLoan)
        {
            _carLoan = carLoan;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<bool> Create(Quote model)
        {
            return await _carLoan.InsertQuote(model);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<bool> Update(Quote model)
        {
            return await _carLoan.UpdateQuote(model);
        }

        [Route("GetQuotesByEmail")]
        [HttpGet]
        public async Task<List<Quote>> GetQuotesByEmail(string Email)
        {
            return await _carLoan.GetQuotesByEmail(Email);
        }

        [Route("GetQuotesByID")]
        [HttpGet]
        public async Task<Quote> GetQuotesByID(int QuoteID)
        {
            return await _carLoan.GetQuotesByID(QuoteID);
        }

        [Route("GetAllQuotes")]
        [HttpGet]
        public async Task<List<Quote>> GetAllQuotes()
        {
            return await _carLoan.GetAllQuotes();
        }

        [Route("Delete")]
        [HttpPut]
        public async Task<bool> Delete(Quote model)
        {
            return await _carLoan.DeleteQuote(model);
        }
    }
}
