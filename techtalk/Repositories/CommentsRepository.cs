
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using techtalk.Models;

namespace techtalk.Repositories
{
    public class CommentsRepository
    {
        private readonly IDbConnection _db;
        public CommentsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Comment GetById(int id)
        {
            string sql = @"
            SELECT 
            v.*,
            pro.*
            FROM vaults v
            JOIN profiles pro ON v.creatorId = pro.id
            WHERE v.id = @id;";
            return _db.Query<Comment, Profile, Comment>(sql, (comment, profile) =>
            {
                comment.Creator = profile;
                return comment;

            }, new { id }, splitOn: "id").FirstOrDefault();
        }

        internal int Create(Comment newComment)
        {
            string sql = @"
            INSERT INTO Comments
            (body, likes, creatorId)
            VALUES
            (@Body, @Likes, @CreatorId);
            SELECT LAST_INSERT_ID()";
            return _db.ExecuteScalar<int>(sql, newComment);
        }

        internal Comment Edit(Comment updated)
        {
            string sql = @"
            UPDATE Comments
            SET
            body = @Body
            WHERE id = @Id;";
            _db.Execute(sql, updated);
            return updated;
        }

        internal void Remove(int id)
        {
            string sql = "DELETE FROM comments WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Comment> GetCommentsbyPostId(int id)
        {
            string sql = @"
            SELECT 
            c.*,
            p.*,
            pro.*
            FROM comments c
            JOIN profile pro ON comment.creatorId = pro.id
            WHERE pro.id = @id;";
            return _db.Query<Comment, Profile, Comment>(sql, (comment, profile) => { comment.Creator = profile; return comment; }, new { id }, splitOn: "id");
        }
    }
}