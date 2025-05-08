namespace Construction_site.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
    }
}
