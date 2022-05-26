using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Viaduct.Models;
using Viaduct.Resources;

namespace Viaduct.Services.Data.Implementation
{
    public class UserService : IUserService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        //private readonly string CreatedRestUrl = string.Concat(Constants.Settigns.RestUrl, "/user/{0}");
        private readonly string CreatedRestUrl = (Constants.Settigns.RestUrl);

        public List<User> Items { get; private set; }

        public UserService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task SaveUserAsync(User item, bool isNewItem = false)
        {
            Uri uri = new Uri(string.Format(CreatedRestUrl, string.Empty));

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
    }
}
