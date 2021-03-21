

using System;
using System.Collections.Generic;
using techtalk.Models;
using techtalk.Repositories;

namespace techtalk.Services
{
    public class CommentsService
    {

        private readonly PostsRepository _pr;
        private readonly CommentsRepository _cr;
        public CommentsService(CommentsRepository cr, PostsRepository pr)
        {
            _pr = pr;
            _cr = cr;
        }
        internal Comment GetById(int id)
        {
            Comment comment = _cr.GetById(id);
            if (comment == null)
            {
                throw new Exception("invalid Id");
            }
            return comment;
        }

        internal Comment Create(Comment newComment)
        {
            newComment.Id = _cr.Create(newComment);
            return newComment;
        }

        internal Comment Edit(Comment updated, string id)
        {
            Comment original = GetById(updated.Id);
            if (original.CreatorId != id) { throw new Exception("Access Denied: You can only edit content you have created."); }
            updated.Body = updated.Body == null ? original.Body : updated.Body;

            return _cr.Edit(updated);
        }

        internal object Delete(int id, string userId)
        {
            Comment original = _cr.GetById(id);
            if (original == null) { throw new Exception("Invalid ID"); }
            if (original.CreatorId != userId) { throw new Exception("Access Denied: You can only delete content you have created."); }
            _cr.Remove(id);
            return "Successfully Deleted";
        }

        internal IEnumerable<Comment> GetCommentsByPostId(int id)
        {
            return _cr.GetCommentsbyPostId(id);
        }
    }
}
