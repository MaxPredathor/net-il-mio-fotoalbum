using Microsoft.AspNetCore.Mvc.Rendering;

namespace net_il_mio_fotoalbum.Models
{
    public class PhotoFormModel
    {
        public Photo Photo { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int>? SelectedCategories { get; set; } = new List<int>();
        public IFormFile ImageFile { get; set; }
    }
}
