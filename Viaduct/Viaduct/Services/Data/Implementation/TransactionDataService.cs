﻿using System;
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
    public class TransactionService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        private readonly string RestUrl = string.Concat(Constants.Settings.apiUrl, "Transaction/");

        public List<Transaction> Items { get; private set; }

        public TransactionDataService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<User>> ReadAllUsersAsync()
        {
            var Users = new List<User>();

            Uri uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Users = JsonSerializer.Deserialize<List<User>>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Users;
        }

        public async Task<User> ReadUserAsync(string id)
        {
            Uri uri = new Uri(string.Format($"{RestUrl}id/", id));
            var User = new User();

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    User = JsonSerializer.Deserialize<User>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return User;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            Uri uri = new Uri($"{RestUrl}login/{login}");
            var User = new User();

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    User = JsonSerializer.Deserialize<User>(content, serializerOptions);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return User;
        }

        public async Task SaveUserAsync(User item, bool isNewItem = false)
        {
            Uri uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<User>(item, serializerOptions);
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
                    Debug.WriteLine(@"\User successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteUserAsync(string id)
        {
            Uri uri = new Uri(string.Format(RestUrl, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\User successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}