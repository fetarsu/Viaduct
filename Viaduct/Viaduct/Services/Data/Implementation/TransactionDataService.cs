using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FreshMvvm;
using Viaduct.Models;
using Constants = Viaduct.Resources.Constants;

namespace Viaduct.Services.Data.Implementation
{
    public class TransactionDataService : ITransactionDataService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        private readonly string RestUrl = string.Concat(Constants.Settings.apiUrl, "Transaction/");

        List<Transaction> transactions = new List<Transaction>();
        Transaction transaction = new Transaction();


        public TransactionDataService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Transaction>> ReadAllTransactionsAsync()
        {
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    transactions = JsonSerializer.Deserialize<List<Transaction>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return transactions;
        }

        public async Task<Transaction> ReadTransactionAsync(int id)
        {
            Uri uri = new Uri(string.Format($"{RestUrl}id/", id));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    transaction = JsonSerializer.Deserialize<Transaction>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return transaction;
        }

        public async Task<List<Transaction>> ReadTransactionsFromOneDay(string date)
        {
            Uri uri = new Uri($"{RestUrl}date/{date}");

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    transactions = JsonSerializer.Deserialize<List<Transaction>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return transactions;
        }

        public async Task SaveTransactionAsync(Transaction item, bool isNewItem = false)
        {
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Transaction>(item, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\Transaction successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}