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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
