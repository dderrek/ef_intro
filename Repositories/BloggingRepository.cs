namespace EFGetStarted.Repositories
{
    public class BloggingRepository
    {
        private readonly BloggingDbContext bloggingDbContext;
        public BloggingRepository(BloggingDbContext bloggingDbContext)
        {
            this.bloggingDbContext = bloggingDbContext;
        }

        public List<Post> GetPosts()
        {
            return bloggingDbContext.Posts.ToList();
        }

        internal List<Blog> GetBlogs()
        {
            return bloggingDbContext.Blogs.ToList();
        }
    }
}
