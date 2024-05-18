using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BoligBlik.MVC.Data;
using BoligBlik.MVC.Models.Addresses;

namespace BoligBlik.MVC.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly BoligBlik.MVC.Data.ApplicationDbContext _context;

        public IndexModel(BoligBlik.MVC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AddressViewModel> AddressViewModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AddressViewModel = await _context.AddressViewModel.ToListAsync();
        }
    }
}
