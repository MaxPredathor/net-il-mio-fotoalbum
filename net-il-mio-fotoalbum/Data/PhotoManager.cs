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
    }
}
