using TravelBlog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace TravelBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<EmailModel> Emails { get; set; }
        public DbSet<GalleryItemModel> GalleryItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
