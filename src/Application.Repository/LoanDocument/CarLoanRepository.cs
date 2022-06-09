using Application.Interface.LoanDocument;
using Application.Model.Quote;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.LoanDocument
{
    public class CarLoanRepository : ICarLoanDocument
    {
        private readonly IConfiguration _config;
        public CarLoanRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public async Task<List<Quote>> GetQuotesByEmail(string Email)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_GetQuoteByEmail", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        List<Quote> Quotes = new List<Quote>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            var quote = new Quote()
                            {
                                QuoteID = Convert.ToInt32(dr["QuoteID"]),
                                Name = dr["Name"].ToString(),
                                Surname = dr["Surname"].ToString(),
                                Email = dr["Email"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Address = dr["Address"].ToString(),
                                Amount = Convert.ToDecimal(dr["Amount"]),
                                CreatedOn = Convert.ToDateTime(dr["CreatedOn"])
                            };
                            Quotes.Add(quote);
                        }


                        return Quotes;
                    }

                }
            }
        }

        public async Task<Quote> GetQuotesByID(int QuoteID)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_GetQuotesByID", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuoteID", QuoteID);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var quote = new Quote()
                        {
                            QuoteID = Convert.ToInt32(dt.Rows[0]["QuoteID"]),
                            Name = dt.Rows[0]["Name"].ToString(),
                            Surname = dt.Rows[0]["Surname"].ToString(),
                            Email = dt.Rows[0]["Email"].ToString(),
                            Phone = dt.Rows[0]["Phone"].ToString(),
                            Address = dt.Rows[0]["Address"].ToString(),
                            Amount = Convert.ToDecimal(dt.Rows[0]["Amount"]),
                            CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"])
                        };

                        return quote;
                    }

                }
            }
        }

        public async Task<bool> InsertQuote(Quote model)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_InsertQuote", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Surname", model.Surname);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd.Parameters.AddWithValue("@CreatedOn", model.CreatedOn);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public async Task<bool> UpdateQuote(Quote model)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_Update_Quote", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuoteID", model.QuoteID);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Surname", model.Surname);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd.Parameters.AddWithValue("@CreatedOn", model.CreatedOn);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public async Task<List<Quote>> GetAllQuotes()
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_GetAllQuotes", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        List<Quote> Quotes = new List<Quote>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            var quote = new Quote()
                            {
                                QuoteID = Convert.ToInt32(dr["QuoteID"]),
                                Name = dr["Name"].ToString(),
                                Surname = dr["Surname"].ToString(),
                                Email = dr["Email"].ToString(),
                                Phone = dr["Phone"].ToString(),
                                Address = dr["Address"].ToString(),
                                Amount = Convert.ToDecimal(dr["Amount"]),
                                CreatedOn = Convert.ToDateTime(dr["CreatedOn"])
                            };
                            Quotes.Add(quote);
                        }


                        return Quotes;
                    }

                }
            }
        }

        public async Task<bool> DeleteQuote(Quote model)
        {
            using (SqlConnection sqlcon = new SqlConnection(this._config.GetConnectionString("ISLoans")))
            {
                using (SqlCommand cmd = new SqlCommand("proc_Delete_Quote", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuoteID", model.QuoteID);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@Surname", model.Surname);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd.Parameters.AddWithValue("@CreatedOn", model.CreatedOn);
                    cmd.Parameters.AddWithValue("@DeletedOn", model.DeletedOn);
                    sqlcon.Open();
                    int rowAffected = cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }
    }
}
