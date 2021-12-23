using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Post[] postsToSeed = new Post[10];
            for (int i = 1; i < 11; i++ )
            {
                postsToSeed[i - 1] = new Post
                {
                    Id = i,
                    Title = $"Post {i}",
                    Content = $"This is some example cpntent for post {i}. The content is very interesting an I just wanted it to be two sentences long."
                };
            }

            modelBuilder.Entity<Post>().HasData(postsToSeed);
        }
    }
}
