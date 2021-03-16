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
    public class Album
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public static async Task<List<Album>> GetAllAlbums(HttpClient httpClient, int userId)
        {
            var httpResponse = await httpClient.GetAsync(UriString.albumUri);          
            var albums = new List<Album>();
            
            var validatedAlbums = AlbumValidation(httpResponse, albums);
            return await validatedAlbums;
        }


        public static async Task<List<Album>> AlbumValidation(HttpResponseMessage httpResponse, List<Album> albums)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                var contentString = await httpResponse.Content.ReadAsStringAsync();
                albums = JsonConvert.DeserializeObject<List<Album>>(contentString);
            }
            return albums;
        }

        public static void PrintAlbumsToConsole(List<Photo> photos, List<Album> userAlbums)
        {
            foreach (var userAlbum in userAlbums)
            {
                foreach (var photo in photos)
                {
                    if (userAlbum.Id == photo.AlbumId)
                    {
                        Console.WriteLine(photo.Url);
                    }
                }
            }
        }
    }
}
