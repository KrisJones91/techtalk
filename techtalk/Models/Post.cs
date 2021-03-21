

namespace techtalk.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Img { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Saves { get; set; }
        public Profile Creator { get; set; }

    }

}