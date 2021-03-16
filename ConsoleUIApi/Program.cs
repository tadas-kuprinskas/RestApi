using ConsoleUIApi.Models;
using ConsoleUIApi.Models.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleUIApi
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var httpClient = ObjectFactory.CreateHttpClient();

                int userId = await User.GetUserId(httpClient);

                var albums = await Album.GetAllAlbums(httpClient, userId);
                var userAlbums = albums.Where(a => a.UserId == userId).ToList();

                var photos = await Photo.GetAllUrls(httpClient);

                PrintToFile.PrintResultsToFile(photos, userAlbums);

                Album.PrintAlbumsToConsole(photos, userAlbums);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
