using EFGetStarted.Models;

namespace EFGetStarted
{
    public class BloggingService
    {
        private readonly BloggingDbContext bloggingDbContext;

        public BloggingService(BloggingDbContext bloggingDbContext)
        {
            this.bloggingDbContext = bloggingDbContext;
        }

        public bool AddPost(PostCreate post)
        {
            var matchingBlog = bloggingDbContext.Blogs.Where(x => x.BlogId == post.BlogId).FirstOrDefault();
            if (matchingBlog == null)
            {
                return false;
            }
            var newEntry = new Post
            {
                PostId = post.PostId,
                Content = post.Content,
                Title = post.Title,
                BlogId = post.BlogId,
                Blog = matchingBlog
            };
            var createdEntry = bloggingDbContext.Posts.Add(newEntry);
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
