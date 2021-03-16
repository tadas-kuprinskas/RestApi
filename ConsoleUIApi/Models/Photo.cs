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
    public class Photo
    {
        public string Url { get; set; }
        public int AlbumId { get; set; }

        public static async Task<List<Photo>> GetAllUrls(HttpClient httpClient)
        {
            var httpResponse = await httpClient.GetAsync(UriString.photoUri);
            var photos = new List<Photo>();

            var validatedPhotos = PhotoValidation(httpResponse, photos);
            return await validatedPhotos;
        }

        public static async Task<List<Photo>> PhotoValidation(HttpResponseMessage httpResponse, List<Photo> photos)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                var contentString = await httpResponse.Content.ReadAsStringAsync();
                photos = JsonConvert.DeserializeObject<List<Photo>>(contentString);
            }
            return photos;
        }
    }
}
