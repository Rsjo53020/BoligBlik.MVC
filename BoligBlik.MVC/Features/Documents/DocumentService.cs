using BoligBlik.MVC.Features.Documents.Interfaces;
using BoligBlik.MVC.Models.Documents;

namespace BoligBlik.MVC.Features.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly string _uploadsBasePath = "wwwroot/Assets/Documents";
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(ILogger<DocumentService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Read All Documents from root
        /// </summary>
        /// <returns></returns>
        public List<DocumentViewModel> GetAllDocuments()
        {
            var documents = new List<DocumentViewModel>();

            try
            {
                var files = Directory.GetFiles(_uploadsBasePath).ToList();

                foreach (var fileName in files)
                {
                    var documentName = Path.GetFileNameWithoutExtension(fileName);
                    var document = new DocumentViewModel { Title = documentName };
                    documents.Add(document);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Documents could not be loaded.");
                return new List<DocumentViewModel>();
            }

            return documents;
        }

        /// <summary>
        /// Create / Upload a Document with file path
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public async Task UploadDocumentAsync(DocumentViewModel model, IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), _uploadsBasePath, fileUpload.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }
            }
            else
            {
                _logger.LogError("No file was uploaded.");
            }
        }
    }
}
