

namespace techtalk.Models
{
    public class PostComment
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
    }

}