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

        public bool DeletePost(int postId)
        {
            var postToDelete = bloggingDbContext.Posts.Where(x => x.PostId == postId).FirstOrDefault();
            if (postToDelete == null)
            {
                // TODO: hier etwas besseres returnen
                return false;
            }

            bloggingDbContext.Posts.Remove(postToDelete);
            return bloggingDbContext.SaveChanges() == 1;
        }

        public bool DeleteBlog(int blogId)
        {
            var blogToDelete = bloggingDbContext.Blogs.Where(x => x.BlogId == blogId).FirstOrDefault();
            if (blogToDelete == null)
            {
                // TODO: hier etwas besseres returnen
                return false;
            }

            bloggingDbContext.Blogs.Remove(blogToDelete);
            return bloggingDbContext.SaveChanges() == 1;
        }
    }
}
