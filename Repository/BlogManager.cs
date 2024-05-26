using TravelBlog.Data;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Data.Migrations;

namespace TravelBlog.Repository
{
    public class BlogManager
    {
        private readonly ApplicationDbContext _context;

        public BlogManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddEmailAsync(EmailModel emailModel)
        {
            try
            {
                await _context.AddAsync(emailModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                emailModel.Id = 0;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> AddGalleryItemAsync(GalleryItemModel galleryitemModel)
        {
            try
            {
                await _context.AddAsync(galleryitemModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                galleryitemModel.Id = 0;
                await _context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<GalleryItemModel> GetGalleryItem(int id)
        {
            return await _context.GalleryItems.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<GalleryItemModel>> GetGalleryItems()
        {
            var galleryItems = await _context.GalleryItems.ToListAsync();
            return galleryItems;
        }
        public async Task<BlogManager> RemoveGalleryItem(int id)
        {
            var itemToDelete = await GetGalleryItem(id);
            if (itemToDelete != null)
            {
                _context.GalleryItems.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
            return this;
        }
        public async Task<BlogManager> UpdateGalleryItem(GalleryItemModel galerryitemModel)
        {
            _context.GalleryItems.Update(galerryitemModel);
            await _context.SaveChangesAsync();
            return this;
        }
    }
}
