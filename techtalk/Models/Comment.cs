

namespace techtalk.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public string Likes { get; set; }

        public string CreatorId { get; set; }
        public int PostId { get; set; }
        public Profile Creator { get; set; }

    }


    public class PostCommentModel : Comment
    {
        public int PostCommentId { get; set; }
    }
}