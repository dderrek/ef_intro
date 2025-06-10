using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFGetStarted
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        // public Blog Blog { get; set; }

        internal class PostConfigurationBuilder
        {
            public void Configure(EntityTypeBuilder<Post> builder)
            {
                // builder.HasOne(c => c.Blog).WithOne().HasForeignKey("FkBlog").IsRequired();
            }
        }
    }

}