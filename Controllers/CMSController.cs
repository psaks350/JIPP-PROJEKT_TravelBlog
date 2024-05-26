using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using TravelBlog.Repository;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Controllers
{
    public class CMSController : Controller
    {
        private readonly BlogManager _manager;
        public CMSController(BlogManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Galeria()
        {
            var  GalleryItemList = await _manager.GetGalleryItems();
            return View(GalleryItemList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(GalleryItemModel galleryitem)
        {
            try
            {
                await _manager.AddGalleryItemAsync(galleryitem);
                return RedirectToAction("Galeria");
            }
            catch (Exception e)
            {

                return View(galleryitem);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var itemToDelete = await _manager.GetGalleryItem(id);
            if (itemToDelete != null)
            {
                return View(itemToDelete);
            }
            else
            {
                return RedirectToAction("Galeria");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveConfirm(int id)
        {
            try
            {
                await _manager.RemoveGalleryItem(id);
                return RedirectToAction("Galeria");
            }
            catch (Exception e)
            {
                return RedirectToAction("Remove", id);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var itemToEdit = await _manager.GetGalleryItem(id);
            if (itemToEdit != null)
            {
                return View(itemToEdit);
            }
            else
            {
                return RedirectToAction("Galeria");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GalleryItemModel item)
        {
            await _manager.UpdateGalleryItem(item);
            return RedirectToAction("Galeria");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var item = await _manager.GetGalleryItem(id);
            return View(item);
        }
    }
}
