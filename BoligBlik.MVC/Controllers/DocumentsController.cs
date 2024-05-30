using BoligBlik.MVC.Features.Documents;
using BoligBlik.MVC.Features.Documents.Interfaces;
using BoligBlik.MVC.Models.Documents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BoligBlik.MVC.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(IDocumentService documentService, ILogger<DocumentsController> logger)
        {
            _documentService = documentService;
            _logger = logger;
        }

        public async Task<IActionResult> Upload(DocumentViewModel documentViewModel, IFormFile fileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _documentService.UploadDocumentAsync(documentViewModel, fileUpload);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Document could not be uploaded.");
                }
            }
            return View(documentViewModel);
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

