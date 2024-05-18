using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoligBlik.MVC.Data;
using BoligBlik.MVC.Models.Addresses;

namespace BoligBlik.MVC.Views.Address
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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

            var addressviewmodel = await _context.AddressViewModel.FirstOrDefaultAsync(m => m.Id == id);

            if (addressviewmodel == null)
            {
                return NotFound();
            }
            else
            {
                AddressViewModel = addressviewmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressviewmodel = await _context.AddressViewModel.FindAsync(id);
            if (addressviewmodel != null)
            {
                AddressViewModel = addressviewmodel;
                _context.AddressViewModel.Remove(AddressViewModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
