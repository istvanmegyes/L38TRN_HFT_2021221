using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Repository
{
    public class SongRepository
    {
        public CommentRepository(DbContext ctx) : base(ctx) { }

        public override Comment GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.CommentId == id);
        }

        public void UpdateContent(int id, string newContent)
        {
            var comment = GetOne(id);
            comment.Content = newContent;
            ctx.SaveChanges();
        }

        public void AddNewComment(Comment comment)
        {
            ctx.Add(comment);
            ctx.SaveChanges();
        }

        public void DeleteCommentById(int id)
        {
            var toDelete = GetOne(id);
            ctx.Remove(toDelete);
            ctx.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            var toUpdate = GetOne(comment.CommentId);

            toUpdate.Content = comment.Content;
            // etc. for additional properties

            ctx.SaveChanges();
        }
    }
}
