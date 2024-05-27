using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Data;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    public class PhotosController : Controller
    {
        public IActionResult Index()
        {
            List<Photo> photos = PhotoManager.GetAllPhotos();
            return View("Index", photos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            PhotoFormModel model = new PhotoFormModel();
            model.Photo = new Photo();
            model.Categories = PhotoManager.GetAllCategories();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PhotoFormModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.ImageFile != null && viewModel.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(viewModel.ImageFile.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.ImageFile.CopyTo(stream);
                    }

                    viewModel.Photo.Image = $"/images/{fileName}";
                }

                PhotoManager.AddPhotoWithCategories(viewModel);

                return RedirectToAction("Index");
            }

            viewModel.Categories = PhotoManager.GetAllCategories();
            return View(viewModel);
        }
    }
}
