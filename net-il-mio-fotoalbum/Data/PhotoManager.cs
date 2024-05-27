using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Data
{
    public static class PhotoManager
    {
        public static List<Photo> GetAllPhotos()
        {
            using PhotoAlbumContext db = new PhotoAlbumContext();
            return db.Photos.ToList();
        }
        public static List<Category> GetAllCategories()
        {
            using PhotoAlbumContext db = new PhotoAlbumContext();
            return db.Categories.ToList();
        }
        public static void AddPhotoWithCategories(PhotoFormModel model)
        {
            using PhotoAlbumContext db = new PhotoAlbumContext();
            model.Categories = db.Categories
                .Where(c => model.SelectedCategories.Contains(c.Id))
                .ToList();

            db.Add(model.Photo);
            db.SaveChanges();
        }
        public static Photo GetPhotoById(int id)
        {
            using PhotoAlbumContext db = new PhotoAlbumContext();
            return db.Photos.Include(p => p.Categories)
               .FirstOrDefault(m => m.Id == id);
        }

        public static void UpdateCategories(PhotoFormModel model, int id)
        {
            using PhotoAlbumContext db = new PhotoAlbumContext();
            var existingPhoto = db.Photos
                    .Include(p => p.Categories)
                    .First(p => p.Id == id);

            existingPhoto.Title = model.Photo.Title;
            existingPhoto.Description = model.Photo.Description;
            existingPhoto.IsVisible = model.Photo.IsVisible;
            existingPhoto.Image = model.Photo.Image;

            existingPhoto.Categories.Clear();
            existingPhoto.Categories = db.Categories
                .Where(c => model.SelectedCategories.Contains(c.Id))
                .ToList();

            db.Update(existingPhoto);
            db.SaveChanges();
        }
        public static bool DeletePhoto(int id)
        {
            try
            {
                using PhotoAlbumContext db = new PhotoAlbumContext();
                var photoToDelete = db.Photos.FirstOrDefault(p => p.Id == id);
                if (photoToDelete == null)
                    return false;

                db.Remove(photoToDelete);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
