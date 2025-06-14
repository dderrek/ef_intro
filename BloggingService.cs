using Microsoft.AspNetCore.Mvc;

namespace EFGetStarted
{
    public class BloggingService
    {
        private readonly BloggingDbContext bloggingDbContext;

        public BloggingService(BloggingDbContext bloggingDbContext)
        {
            this.bloggingDbContext = bloggingDbContext;
        }

        public bool AddPost([FromBody] Post post)
        {
            var createdEntry = bloggingDbContext.Posts.Add(post);
            return bloggingDbContext.SaveChanges() == 1;
        }

        public bool AddBlog(Blog blog)
        {
            var createdEntry = bloggingDbContext.Blogs.Add(blog);
            return bloggingDbContext.SaveChanges() == 1;
        }
    }
}
