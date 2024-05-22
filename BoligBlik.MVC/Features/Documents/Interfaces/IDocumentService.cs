using BoligBlik.MVC.Models.Documents;

namespace BoligBlik.MVC.Features.Documents.Interfaces
{
    public interface IDocumentService
    {
        List<DocumentViewModel> GetAllDocuments();
        Task UploadDocumentAsync(DocumentViewModel model, IFormFile fileUpload);
    }
}
