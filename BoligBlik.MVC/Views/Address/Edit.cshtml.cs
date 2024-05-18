using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoligBlik.MVC.Data;
using BoligBlik.MVC.Models.Addresses;

namespace BoligBlik.MVC.Controllers
{
    public class EditModel : PageModel
    {
        private readonly BoligBlik.MVC.Data.ApplicationDbContext _context;

        public EditModel(BoligBlik.MVC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddressViewModel AddressViewModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressviewmodel =  await _context.AddressViewModel.FirstOrDefaultAsync(m => m.Id == id);
            if (addressviewmodel == null)
            {
                return NotFound();
            }
            AddressViewModel = addressviewmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AddressViewModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressViewModelExists(AddressViewModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AddressViewModelExists(Guid id)
        {
            return _context.AddressViewModel.Any(e => e.Id == id);
        }
    }
}
