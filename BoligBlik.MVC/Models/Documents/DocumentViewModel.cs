namespace BoligBlik.MVC.Models.Documents
{
    public class DocumentViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public IFormFile FileUpload { get; set; }
        public string Acces { get; set; }
    }
}
