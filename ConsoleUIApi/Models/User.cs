using ConsoleUIApi.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUIApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static async Task<int> GetUserId(HttpClient httpClient)
        {           
            var httpResponse = await httpClient.GetAsync(UriString.userUri);   
            
            var users = new List<User>();
            users = await UserValidation(httpResponse, users);

            var userId = UserIdCycle(users);
            return userId;
        }

        public static async Task<List<User>> UserValidation(HttpResponseMessage httpResponse, List<User> users)
        {
            
            if (httpResponse.IsSuccessStatusCode)
            {
                var contentString = await httpResponse.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<User>>(contentString);          
            }
            return users;
        }

        public static int UserIdCycle(List<User>users)
        {
            int userId = 0;
            foreach (var user in users)
            {
                if (user.Name.ToLower() == "mrs. dennis schulist")
                {
                    userId = user.Id;
                    return userId;
                }               
            }
            return userId;
        }   
    }
}
