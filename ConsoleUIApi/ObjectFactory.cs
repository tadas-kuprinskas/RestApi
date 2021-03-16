using ConsoleUIApi.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUIApi
{
    public static class ObjectFactory
    {
        public static HttpClient CreateHttpClient()
        {
            return new HttpClient();
        }      
    }
}
