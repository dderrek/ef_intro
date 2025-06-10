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

        public Guid AddPost([FromBody] Post post)
        {
            bloggingDbContext.Posts.Add(post);
            bloggingDbContext.SaveChanges();
            return Guid.Empty;
        }

        public void AddBlog(Blog blog)
        {
            this.bloggingDbContext.Blogs.Add(blog);
            bloggingDbContext.SaveChanges();
        }
    }
}
