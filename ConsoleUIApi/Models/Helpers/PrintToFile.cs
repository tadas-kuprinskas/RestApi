using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUIApi.Models.Helpers
{
    public class PrintToFile
    {
        public const string CFr = "..\\..\\..\\Results.txt";

        public static void PrintResultsToFile(List<Photo> photos, List<Album> userAlbums)
        {
            DeleteIfFIleExists();

            using (var fr = File.AppendText(CFr))
            {
                foreach (var userAlbum in userAlbums)
                {
                    foreach (var photo in photos)
                    {
                        if (userAlbum.Id == photo.AlbumId)
                        {
                            fr.WriteLine(photo.Url);
                        }
                    }
                }
            }
        }

        public static void DeleteIfFIleExists()
        {
            if (File.Exists(CFr))
                File.Delete(CFr);
        }

    }
}
