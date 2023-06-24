using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace TestesUnitários.Mocking
{
    public class VideoService
    {
        public string ReadVideoTitle(IFileReader fileReader)
        {
            var str = fileReader.Read("video.txt");

            var video = JsonConvert.DeserializeObject<Video>(str);/* Caso essa conversão da string em Json Object 
                falhe, ou a string não esteja no formato correto, não vamos obter um objeto do tipo Video
                e sim obter null (Por isso existe uma if abaixo) para retornar uma mensagem.
             */

            if (video == null)
            {
                return "Error parsing the video";
            }

            return video.Title;
        }



    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    { 
        public DbSet<Video> Videos { get; set;}
    }

}
