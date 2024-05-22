using BoligBlik.MVC.Features.Documents.Interfaces;
using BoligBlik.MVC.Models.Documents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<IActionResult> Upload(DocumentViewModel model, IFormFile fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _documentService.UploadDocumentAsync(model, fileUpload);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Document could not be uploaded.");
                }
            }
            return View(model);
        }

    public IActionResult GetAll([FromServices] IDocumentService documentService)
        {
            List<DocumentViewModel> documents = new List<DocumentViewModel>();

            try
            {
                documents = documentService.GetAllDocuments();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Documents could not be loaded.");
            }

            return View(documents);
        }
    }
}

