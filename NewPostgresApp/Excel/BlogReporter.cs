using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NewPostgresApp
{
    public class BlogReporter
    {
        public BlogReport GetReport(ApplicationContext db)
        {
            //вытягиваю списки из базы
            var writers = db.Writers.ToList();
            var posts = db.Posts.ToList();

            return new BlogReport
            {
               Writer = writers,
               Post = posts
            };
        }
    }
}
